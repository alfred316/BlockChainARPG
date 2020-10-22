using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerCharacterManager playerCharacterManager;

    //public float timeBetweenAttacks = 1.5f;     // The time in seconds between each attack.
    [SerializeField] float attackDamage;               // The amount of health taken away per attack.
    public float range = 10f;
    bool enemyInRange = false;
    int attackableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
    SphereCollider meleeBubble;
    Animator anim;                              // Reference to the animator component.
    Ray hitRay;                                   // A ray from the sword end forwards.
    RaycastHit meleeHit;                            // A raycast hit to get information about what was hit.
    public GameObject rayStart;
    List<GameObject> enemies;
    public AudioSource playerAttack;
    private void Awake()
    {
        playerCharacterManager = GetComponent<PlayerCharacterManager>();

        // Setting up the references.
        anim = GetComponent<Animator>();
        meleeBubble = GetComponent<SphereCollider>();
        
    }

    void Start()
    {
        attackDamage = playerCharacterManager.GetPlayerCharacterSheet().GetPhyAttack();
        attackDamage = 5f + attackDamage * 1.5f;
        // Create a layer mask for the Shootable layer.
        attackableMask = LayerMask.GetMask("Attackable");
    }

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy In Range");
            // ... an enemy is in range.
            enemyInRange = true;
        }

    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject.tag == "Enemy")
        {
            // ... an enemy is no longer in range.
            enemyInRange = false;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            anim.SetBool("IsAttacking", true);
            
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }

    }

    public void Attack()
    {
        Debug.Log("Attack Event");
        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        hitRay.origin = rayStart.transform.position;
        hitRay.direction = rayStart.transform.forward;

        

        // Perform the raycast against gameobjects on the attackable layer and if it hits something...
        if (Physics.Raycast(hitRay, out meleeHit, range, attackableMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * meleeHit.distance, Color.yellow);
            Debug.Log("HIT: " + meleeHit.transform.name);
            // Try and find an EnemyHealth script on the gameobject hit.
            EnemyHealth enemyHealth = meleeHit.collider.GetComponent<EnemyHealth>();

            // If the EnemyHealth component exist...
            if (enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage(attackDamage, meleeHit.point);
            }

            
        }
        // If the raycast didn't hit anything on the attackable layer...
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //flail around
        }
        playerAttack.Play();
    }

    public void AOEAttack()
    {

    }
}
