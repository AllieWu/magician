using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : EnemyGeneral
{

    //enemy variables
    Grid grid;

    Vector2[] path;
    private Transform target;
    int targetIndex;

    private bool inRange = false;
    private bool pause = false;
    private bool attacking = false;

    private IEnumerator pathing;
    private IEnumerator followPathCoroutine;
    private IEnumerator closeAttackCoroutine;

    private GameObject attackColliderObject;
    private CircleCollider2D attackCollider;
    private CustomSecondTrigger triggerObject;

    private Rigidbody2D rb2d;

    void Start()
    {


        //level = gameObject.GetComponent<InforScript>().level;
        // ^^ example of how info script information could work
        // info script information would be calc'd in info script to remove clutter

        //level = 2;
        maxHealth = Mathf.Ceil(10 + level ^ (3/2));
        xp = 10 * level;
        damage = 2 * level;
        currentHealth = maxHealth;
        dead = false;
        enemyHealthBar.fillAmount = currentHealth / maxHealth;


        //enemy movement and attack
        inRange = true;
        pathing = RefreshPath();
        followPathCoroutine = FollowPath();

        rb2d = GetComponent<Rigidbody2D>();

        target = GameObject.Find("Player").transform;

        attackColliderObject = new GameObject();
        attackColliderObject.transform.parent = transform;
        attackColliderObject.transform.localPosition = new Vector2(0, 0);
        attackCollider = attackColliderObject.AddComponent<CircleCollider2D>();
        attackCollider.isTrigger = true;
        attackCollider.radius = 1;
        triggerObject = attackColliderObject.AddComponent<CustomSecondTrigger>();
        triggerObject.Sendee = gameObject;
    }

    // Deals damage to the player if they come into contact with the enemy
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().DealDamage(damage); 
        }
    }

    // Deals damage every so often if the player if they stay in contact with the enemy
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //implement this
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            StartCoroutine(pathing);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            StopCoroutine(pathing);
            StopCoroutine(followPathCoroutine);
        }
    }

    IEnumerator RefreshPath()
    {
        Vector2 targetPositionOld = (Vector2)target.position + Vector2.up; // ensure != to target.position initially

        while (true)
        {
            if (inRange)
            {
                if (targetPositionOld != (Vector2)target.position)
                {
                    targetPositionOld = (Vector2)target.position;

                    path = Pathfinding.RequestPath(transform.position, target.position);
                    StopCoroutine("FollowPath");
                    StartCoroutine("FollowPath");
                }

                yield return new WaitForSeconds(.25f);
            }
            else
            {
                StopCoroutine("FollowPath");
                yield return new WaitForSeconds(.25f);
            }
        }
    }

    IEnumerator FollowPath()
    {
        if (path.Length > 0)
        {
            targetIndex = 0;
            Vector2 currentWaypoint = path[0];

            while (inRange)
            {
                if ((Vector2)transform.position == currentWaypoint)
                {
                    targetIndex++;
                    if (targetIndex >= path.Length)
                    {
                        yield break;
                    }
                    currentWaypoint = path[targetIndex];
                }

                if (!pause)
                {

                    transform.position = Vector2.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
                }
                yield return null;

            }
        }
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube((Vector3)path[i], Vector3.one *.5f);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }

    IEnumerator AttackClose(Vector3 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 0);
        yield return new WaitForSeconds(0.5f);
        Vector2 direction = targetPosition - transform.position;
        rb2d.AddForce(direction.normalized * 60 * Time.deltaTime);
        yield return new WaitForSeconds(1);
        StartCoroutine(pathing);
        pause = false;
        attacking = false;
    }

    public void attackAction(Collider2D col)
    {
        if (!attacking)
        {
            attacking = true;
            pause = true;
            closeAttackCoroutine = AttackClose(col.gameObject.transform.position);
            StartCoroutine(closeAttackCoroutine);
        }
    }

    public void DealDamage(float damageDealt)
    {
        if (!dead)
        {
            currentHealth -= damageDealt;
            enemyHealthBar.fillAmount = currentHealth / maxHealth;

            if (currentHealth <= 0)
            {
                StopCoroutine(pathing);
                StopCoroutine(followPathCoroutine);
                Die();
            }
        }
    }

    public void StartDOT(int damageTimes, float damageAmount)
    {
        StartCoroutine(DoDOT(damageTimes, damageAmount));
    }

    public IEnumerator DoDOT(int damageTimes, float damageAmount)
    {
        int damageCount = 0;
        while (damageCount < damageTimes)
        {
            DealDamage(damageAmount);
            //Debug.Log("Burning...");
            yield return new WaitForSeconds(1);
            damageCount++;
        }
        //Debug.Log("Done Burning");
    }
}

public class CustomSecondTrigger : MonoBehaviour
{
    private GameObject sendee;
    public GameObject Sendee
    {
        get { return sendee; }
        set { sendee = value; }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Sendee.SendMessage("attackAction", col);
        }
    }
}