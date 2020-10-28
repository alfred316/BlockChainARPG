using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    

    public float startingHealth;                            // The amount of health the player starts the game with.
    public float currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    //public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

    PlayerCharacterManager playerCharacterManager;
    Animator anim;                                              // Reference to the Animator component.
    //AudioSource playerAudio;                                    // Reference to the AudioSource component.
    PlayerMovement playerMovement;                              // Reference to the player's movement.
    //PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
    public GameObject deathUI;
    public GameObject leaderboardUI;

    // Start is called before the first frame update
    void Awake()
    {
        playerCharacterManager = GetComponent<PlayerCharacterManager>();

        //startingHealth = playerCharacterManager.GetPlayerCharacterSheet().GetStamina();

        // Setting up the references.
        anim = GetComponent<Animator>();
        //playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        //playerShooting = GetComponentInChildren<PlayerShooting>();

        // Set the initial health of the player.
        currentHealth = startingHealth;
    }

    private void Start()
    {
        startingHealth = playerCharacterManager.GetPlayerCharacterSheet().GetStamina();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerCharacterManager.GetPlayerCharacterSheet().GetCurrentHealth(); //+ 0.05f based on 3hps 
        //playerCharacterManager.GetPlayerCharacterSheet().SetCurrentHealth(currentHealth);
        healthSlider.value = currentHealth;
        healthSlider.maxValue = playerCharacterManager.GetPlayerCharacterSheet().GetStamina();
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }

    public void TakeDamage(float amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;
        float armor = playerCharacterManager.GetPlayerCharacterSheet().GetArmor();
        // Reduce the current health by the damage amount.
        if(armor < amount)
        {
            currentHealth = currentHealth - (amount - armor);
        }
        else if (armor >= amount)
        {
            currentHealth = currentHealth - 1;
        }
        //currentHealth = currentHealth - (amount - armor);
        playerCharacterManager.GetPlayerCharacterSheet().SetCurrentHealth(currentHealth);
        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
        charSheetUI.UpdateCharacterSheetVisuals();

        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off any remaining shooting effects.
        //playerShooting.DisableEffects();

        // Tell the animator that the player is dead.
        anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        // Turn off the movement and shooting scripts.
        playerMovement.enabled = false;
        //playerShooting.enabled = false;

        deathUI.SetActive(true);
        leaderboardUI.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("CaveZombies");
    }
}
