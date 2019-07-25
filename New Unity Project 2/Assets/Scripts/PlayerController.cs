using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Combat Settings")]
    public float cooldown;
    private float nextFireTime1, nextFireTime2, nextFireTime3;
    private Transform location;
    private Quaternion projRotation;
    public GameObject projectile;
    public Vector3 lookDirection;
    private Camera cam;
    private Vector3 point;
    public bool dead;

    [Header("XP Settings")]
    public Slider xpBar;
    public Text xpInfo;
    public int currentXP, nextLevelXP, previousLevelXP, playerLevel;

    [Header("Movement Settings")]
    public float speed;                                             // Player's Movement Speed
    private float moveHorizontal, moveVertical;                     // x input, y input
    public Vector3 movement;                                        // Where the player wants to move, where the player does move based on obstacles, where the obstacles are
    public Rigidbody2D body;                                        // The object being moved

    // playerLevel to be read from SaveScript
    // currentHealth to be read from SaveScript

    private void Start()
    {
        //initialize savescript variables

        //xpBar.value = (currentXP - previousLevelXP) / (nextLevelXP - previousLevelXP);

        location = GetComponent<Transform>();
        nextFireTime1 = Time.time;
        nextFireTime2 = Time.time;
        nextFireTime3 = Time.time;
        cam = Camera.main;

        //Setting up XP Bar
        currentXP = 0;
        playerLevel = 1;
        nextLevelXP = (int)Mathf.Floor(Mathf.Pow(playerLevel + 10, (float)1.75)) - 30;
        previousLevelXP = 0;
        xpBar.value = (currentXP) / (nextLevelXP);
        xpInfo.text = "Level: " + playerLevel + "     XP: " + currentXP + "/" + nextLevelXP;

        body = GetComponent<Rigidbody2D>();
        dead = false;
    }

    private void Update()
    {
        point = cam.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = point - location.position;
        projRotation = Quaternion.LookRotation(Vector3.forward, lookDirection);

        if (Input.GetAxisRaw("Fire1") != 0 && Time.time > nextFireTime1)
        {
            Instantiate(projectile, location.position + lookDirection.normalized, projRotation);
            nextFireTime1 = Time.time + cooldown;
        }
        else if (Input.GetAxisRaw("Fire2") != 0 && Time.time > nextFireTime2)
        {
            gameObject.GetComponent<FireballSpell>().Cast();
            nextFireTime2 = Time.time + gameObject.GetComponent<FireballSpell>().cooldown;
        }
        else if (Input.GetAxisRaw("Fire3") != 0 && Time.time > nextFireTime3)
        {
            gameObject.GetComponent<TsunamiSpell>().Cast();
            nextFireTime3 = Time.time + gameObject.GetComponent<TsunamiSpell>().cooldown;
            //Debug.Log(gameObject.GetComponent<TsunamiSpell>().cooldown);
        }
    }

    private void FixedUpdate()
    {
        if(!dead)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
            movement = new Vector3(moveHorizontal, moveVertical);

            body.AddForce(movement.normalized * speed * Time.deltaTime);
        }
        
    }

    public void AddXP(int XP)
    {
        currentXP += XP;

        while(currentXP > nextLevelXP)
        {
            playerLevel++;
            nextLevelXP = (int)Mathf.Floor(Mathf.Pow(playerLevel + 10, (float)1.75)) - 30;
            previousLevelXP = (int)Mathf.Floor(Mathf.Pow(playerLevel + 9, (float)1.75)) - 30;
        }

        xpBar.value = (float)(currentXP - previousLevelXP) / (nextLevelXP - previousLevelXP);
        //Debug.Log((float)(currentXP - previousLevelXP) / (nextLevelXP - previousLevelXP));
        //Debug.Log(xpBar.value);
        xpInfo.text = "Level: " + playerLevel + "     XP: " + currentXP + "/" + nextLevelXP;
    }
}