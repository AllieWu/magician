using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Combat Settings")]
    public float cooldown;
    private float nextSlot0Time, nextSlot1Time, nextSlot2Time, nextSlot3Time, nextSlot4Time;
    public Spell[] hand;
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

    [Header("Health Settings")]
    public float maxHealth;
    public float currentHealth;
    public Slider healthBar;

    [Header("Other")]
    public GameObject hud;
    public bool CanOpenTeleporter = false;
    public bool CanOpenJobChanger = false;

    [Header("Job Info")]
    public List<BaseJob> jobs;
    public List<int> spellids;

    // playerLevel to be read from SaveScript
    // currentHealth to be read from SaveScript

    private void Start()
    {
        jobs = new List<BaseJob>();
        // start off as a wizard monk 
        jobs.Add(new Wizard());
        jobs.Add(new Monk());

        foreach (BaseJob job in jobs)
        {
            job.initialize(); // initialize job class's spells and name
            spellids.AddRange(job.spellids); // update player's available spells
        }
        spellids.ForEach(id => Debug.Log(id.ToString() + ", "));

        //initialize savescript variables
        //xpBar.value = (currentXP - previousLevelXP) / (nextLevelXP - previousLevelXP);

        location = GetComponent<Transform>();
        nextSlot0Time = nextSlot1Time = nextSlot2Time = nextSlot3Time = nextSlot4Time = Time.time;
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

        //Setting up health
        currentHealth = maxHealth;
        healthBar.value = CalculateHealth();

        //Setting up combat and spells
        hand = new Spell[5];
        ChangeSlot(0, "Fireball"); //default spells in the hand for now
        ChangeSlot(1, "Tsunami"); 
        ChangeSlot(2, "Teleport"); 
        ChangeSlot(3, "KnockbackPunch");
        ChangeSlot(4, "FireArrow");
    }

    private void Update()
    {
        point = cam.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = point - location.position;
        projRotation = Quaternion.LookRotation(Vector3.forward, lookDirection);

        // LOOK FOR ANY KEY PRESSES
        // SPELLS
        if (Input.GetKeyDown(InputManager.IM.Spell1))
            CastSpell(0);
        else if (Input.GetKeyDown(InputManager.IM.Spell2))
            CastSpell(1);
        else if (Input.GetKeyDown(InputManager.IM.Spell3))
            CastSpell(2);
        else if (Input.GetKeyDown(InputManager.IM.Spell4))
            CastSpell(3);
        else if (Input.GetKeyDown(InputManager.IM.Spell5))
            CastSpell(4);
        else if (Input.GetKeyDown(KeyCode.Space)) // Teleportation!
            gameObject.GetComponent<Teleport>().Cast();

        // 'CHEAT' CODES - ADDING INVENTORY ITEMS & QUESTS 
        else if (Input.GetKey(InputManager.IM.Adddefaultitem))
            Inventory.instance.Add(ScriptableObject.CreateInstance<Item>());
        else if (Input.GetKey(InputManager.IM.Adddefaultquest))
            Quests.instance.Add(ScriptableObject.CreateInstance<Quest>());
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
            movement = new Vector3(moveHorizontal, moveVertical);

            body.AddForce(movement.normalized * speed * Time.deltaTime);
        }

    }

    private float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    public void DealDamage(float damageDealt)
    {
        if (!dead)
        {
            currentHealth -= damageDealt;

            if (currentHealth <= 0)
                Die();

            healthBar.value = CalculateHealth();
        }
    }

    private void Die()
    {
        currentHealth = 0;
        dead = true;
    }

    public void AddXP(int XP)
    {
        currentXP += XP;

        while (currentXP > nextLevelXP)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            Inventory.instance.Add(other.gameObject.GetComponent<Drop>().GetItem());
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Teleporter"))
        {
            Debug.Log("Collided with Teleporter");
            hud.GetComponent<HUD>().OpenMessagePanel("");
            CanOpenTeleporter = true;
        }
        else if (other.gameObject.CompareTag("JobChanger"))
        {
            Debug.Log("Collided with Job Changer");
            hud.GetComponent<HUD>().OpenMessagePanel("");
            CanOpenJobChanger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Teleporter"))
        {
            hud.GetComponent<HUD>().CloseMessagePanel("");
            CanOpenTeleporter = false;
        }
        else if (other.gameObject.CompareTag("JobChanger"))
        {
            hud.GetComponent<HUD>().CloseMessagePanel("");
            CanOpenJobChanger = false;
        }
    }

    public void SavePlayerData()
    {
        Save mySave = new Save()
        {
            _currentXP = currentXP,
            _currentHealth = currentHealth,
            _maxHealth = maxHealth,
            _nextLevelXP = nextLevelXP,
            _playerLevel = playerLevel,
            _previousLevelXP = previousLevelXP,
            _itemsDict = Inventory.instance.GetInvData()
        };

        SaveData.Save<Save>(mySave, "save1");

    }

    public void LoadPlayerData()
    {
        Save playerData = SaveData.Load<Save>("save1");

        currentXP = playerData._currentXP;
        currentHealth = playerData._currentHealth;
        maxHealth = playerData._maxHealth;
        nextLevelXP = playerData._nextLevelXP;
        previousLevelXP = playerData._previousLevelXP;
        playerLevel = playerData._playerLevel;
        Inventory.instance.SetInvData(playerData._itemsDict);
        Inventory.instance.UpdateKeys();
    }


    /* SPELL CASTING FUNCTIONS */
    public void CastSpell(int n)
    {
        if (n == 0)
        {
            if (Time.time > nextSlot0Time)
            {
                hand[n].Cast();
                nextSlot0Time = Time.time + hand[n].cooldown;
            }
        }
        else if (n == 1)
        {
            if (Time.time > nextSlot1Time)
            {
                hand[n].Cast();
                nextSlot1Time = Time.time + hand[n].cooldown;
            }
        }
        else if (n == 2)
        {
            if (Time.time > nextSlot2Time)
            {
                hand[n].Cast();
                nextSlot2Time = Time.time + hand[n].cooldown;
            }
        }
        else if (n == 3)
        {
            if (Time.time > nextSlot3Time)
            {
                hand[n].Cast();
                nextSlot3Time = Time.time + hand[n].cooldown;
            }
        }
        else if (n == 4)
        {
            if (Time.time > nextSlot4Time)
            {
                hand[n].Cast();
                nextSlot4Time = Time.time + hand[n].cooldown;
            }
        }
    }

    public void ChangeSlot(int indexToChange, string newSpell)
    {
        hand[indexToChange] = (Spell)gameObject.GetComponent(newSpell);
    }
}