using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 1.5f;     // The time in seconds between each attack.
    public float attackDamage = 10f;               // The amount of health taken away per attack.


    Animator anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.

    //GameObject wall;
    BreakableEnv envWall;
    bool wallInRange;

    void Start()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
            anim.SetBool("IsAttacking", true);
        }

        if (other.transform.tag == "BreakableEnvironment")
        {
            wallInRange = true;
            anim.SetBool("IsAttacking", true);
            envWall = other.gameObject.GetComponent<EnvManager>().envWall;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
            anim.SetBool("IsAttacking", false);
        }

        if (other.transform.tag == "BreakableEnvironment")
        {
            wallInRange = false;
            anim.SetBool("IsAttacking", false);
            //envWall = other.gameObject.GetComponent<BreakableEnv>();
        }
    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            // ... attack. (attacking happens as an animation event)
            //ZombieAttack();
        }
        
        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            anim.SetTrigger("PlayerDead");
        }
    }


    public void ZombieAttack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0 && playerInRange)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
        if (wallInRange)
        {
            if(envWall.GetCurrentHealth() > 0)
            {
                //damage the wall
                envWall.EnvTakeDamage(attackDamage);
            }
            
        }  
    }
}
