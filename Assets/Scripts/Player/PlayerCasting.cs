using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCasting : MonoBehaviour
{
    float timer;                                    // A timer to determine when to fire.
    PlayerCharacterManager playerCharacterManager;
    [SerializeField] float attackDamage;
    Animator anim;                              // Reference to the animator component.
    int attackableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
    Ray castRay;                                   // A ray from the sword end forwards.
    RaycastHit magicHit;                            // A raycast hit to get information about what was hit.
    public GameObject rayStart;
    public int damagePerCast = 20;                  // The damage inflicted by each bullet.
    public float timeBetweenCasts = 1.5f;        // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.
    public float startingMana;
    public float currentMana;
    public float manaCost = 15f;
    public Slider manaSlider;
    public AudioSource fireballSound;

    private void Awake()
    {
        playerCharacterManager = GetComponent<PlayerCharacterManager>();

        // Setting up the references.
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        attackDamage = playerCharacterManager.GetPlayerCharacterSheet().GetMagAttack();
        attackDamage = 5f + attackDamage * 1.5f;
        startingMana = playerCharacterManager.GetPlayerCharacterSheet().GetMagic();
        currentMana = startingMana;
        
        attackableMask = LayerMask.GetMask("Attackable");
    }

    // Update is called once per frame
    void Update()
    {
        currentMana = playerCharacterManager.GetPlayerCharacterSheet().GetCurrentMana(); //+ 0.083f based on 5mps
        //playerCharacterManager.GetPlayerCharacterSheet().SetCurrentMana(currentMana);
        manaSlider.value = currentMana / 100.0f;
        manaSlider.maxValue = playerCharacterManager.GetPlayerCharacterSheet().GetMagic() / 100.0f;
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the Fire1 button is being press and it's time to fire...
        if (Input.GetMouseButton(1) && timer >= timeBetweenCasts && currentMana > 0)
        {
            // ... shoot the gun.
            Cast();
        }
    }

    void Cast()
    {
        // Reset the timer.
        timer = 0f;

        currentMana -= manaCost;
        playerCharacterManager.GetPlayerCharacterSheet().SetCurrentMana(currentMana);
        manaSlider.value = currentMana / 100.0f;

        CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
        charSheetUI.UpdateCharacterSheetVisuals();
        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        //castRay.origin = rayStart.transform.position;
        //castRay.direction = rayStart.transform.forward;

        GameObject fireBall = Resources.Load<GameObject>("Spells/Fireball") as GameObject;
        Instantiate(fireBall, rayStart.transform.position, rayStart.transform.rotation);

        fireballSound.Play();
        //clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * 5);

        /*
        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if (Physics.Raycast(castRay, out magicHit, range, attackableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            EnemyHealth enemyHealth = magicHit.collider.GetComponent<EnemyHealth>();

            // If the EnemyHealth component exist...
            if (enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage(damagePerCast, magicHit.point);
            }

            // Set the second position of the line renderer to the point the raycast hit.
            //gunLine.SetPosition(1, magicHit.point);
        }
        // If the raycast didn't hit anything on the shootable layer...
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            //gunLine.SetPosition(1, castRay.origin + castRay.direction * range);
        }
        */
    }
}
