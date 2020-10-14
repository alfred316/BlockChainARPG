﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float startingHealth = 100f;            // The amount of health the enemy starts the game with.
    public float currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
    //public AudioClip deathClip;                 // The sound to play when the enemy dies.


    Animator anim;                              // Reference to the animator.
    //AudioSource enemyAudio;                     // Reference to the audio source.
    //ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    EnemyLootDrop lootDrop;
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.


    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        //enemyAudio = GetComponent<AudioSource>();
        //hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    private void Start()
    {
        lootDrop = new EnemyLootDrop();
    }

    void Update()
    {
        // If the enemy should be sinking...
        if (isSinking)
        {
            // ... move the enemy down by the sinkSpeed per second.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(float amount, Vector3 hitPoint)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        // Play the hurt sound effect.
        //enemyAudio.Play();

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;
        anim.SetTrigger("IsDamaged");
        // Set the position of the particle system to where the hit was sustained.
        //hitParticles.transform.position = hitPoint;

        // And play the particles.
        //hitParticles.Play();
        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            // ... the enemy is dead.
            Death();
        }
    }


    void Death()
    {
        // The enemy is dead.
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        capsuleCollider.isTrigger = true;

        // Tell the animator that the enemy is dead.
        anim.SetTrigger("Dead");

        //drop loot
        //EnemyLootDrop lootDrop = new EnemyLootDrop();
        //PlayerItem loot = lootDrop.CommonLootDrop();
        int tmp = lootDrop.BasicEnemyDrop();
        switch(tmp)
        {
            case 0:
                //instantiate loot obj, loot obj has script that when player collides will generate their loot
                //green
                GameObject commonloot = Resources.Load<GameObject>("Loot/Common/CommonLoot") as GameObject;
                Instantiate(commonloot,transform.position, Quaternion.identity);
                break;
            case 1:
                //blue
                GameObject rareloot = Resources.Load<GameObject>("Loot/Rare/RareLoot") as GameObject;
                Instantiate(rareloot, transform.position, Quaternion.identity);
                break;
            case 2:
                //purple
                GameObject epicloot = Resources.Load<GameObject>("Loot/Epic/EpicLoot") as GameObject;
                Instantiate(epicloot, transform.position, Quaternion.identity);
                break;
            case 3:
                //legendary
                GameObject leggoloot = Resources.Load<GameObject>("Loot/Legendary/LegendaryLoot") as GameObject;
                Instantiate(leggoloot, transform.position, Quaternion.identity);
                break;
            case -1:
                GameObject errorloot = Resources.Load<GameObject>("Loot/Common/CommonLoot") as GameObject;
                Instantiate(errorloot, transform.position, Quaternion.identity);
                //error
                break;
        }
        //maybe just instantiate the object here, have a script on that object that picks loot based on its rarity?
        //rng to instantiate object here



        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();
    }


    public void StartSinking()
    {
        // Find and disable the Nav Mesh Agent.
        GetComponent<NavMeshAgent>().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent<Rigidbody>().isKinematic = true;

        // The enemy should no sink.
        isSinking = true;

        // Increase the score by the enemy's score value.
        //ScoreManager.score += scoreValue;

        // After 2 seconds destory the enemy.
        Destroy(gameObject, 2f);
    }
}
