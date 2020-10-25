using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterSheetUI : MonoBehaviour
{
    public GameObject HealthValue;
    public GameObject ManaValue;
    public GameObject ArmorValue;
    public GameObject PhyAttackValue;
    public GameObject MagAttackValue;
    public GameObject CritValue;
    public GameObject CharacterSheetPanel;
    public GameObject backImage;

    GameObject player;                          // Reference to the player GameObject.
    PlayerCharacterManager playerManager;
    PlayerCharacterSheet playerCharacterSheet;

    // Start is called before the first frame update
    void Start()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerManager = player.GetComponent<PlayerCharacterManager>();
        playerCharacterSheet = playerManager.GetPlayerCharacterSheet();

        HealthValue.GetComponent<Text>().text = playerCharacterSheet.GetStamina().ToString();
        ManaValue.GetComponent<Text>().text = playerCharacterSheet.GetMagic().ToString();
        ArmorValue.GetComponent<Text>().text = playerCharacterSheet.GetArmor().ToString();
        PhyAttackValue.GetComponent<Text>().text = playerCharacterSheet.GetPhyAttack().ToString();
        MagAttackValue.GetComponent<Text>().text = playerCharacterSheet.GetMagAttack().ToString();
        CritValue.GetComponent<Text>().text = playerCharacterSheet.GetCrit().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(CharacterSheetPanel.activeInHierarchy)
            {
                CharacterSheetPanel.SetActive(false);
                backImage.SetActive(false);
            }
            else if(!CharacterSheetPanel.activeInHierarchy)
            {
                CharacterSheetPanel.SetActive(true);
                backImage.SetActive(true);
                UpdateCharacterSheetVisuals();
            }
        }
    }

    public void UpdateCharacterSheetVisuals()
    {
        HealthValue.GetComponent<Text>().text = playerCharacterSheet.GetCurrentHealth().ToString() + "/" + playerCharacterSheet.GetStamina().ToString();
        ManaValue.GetComponent<Text>().text = playerCharacterSheet.GetCurrentMana().ToString() + "/" + playerCharacterSheet.GetMagic().ToString();
        ArmorValue.GetComponent<Text>().text = playerCharacterSheet.GetArmor().ToString();
        PhyAttackValue.GetComponent<Text>().text = playerCharacterSheet.GetPhyAttack().ToString();
        MagAttackValue.GetComponent<Text>().text = playerCharacterSheet.GetMagAttack().ToString();
        CritValue.GetComponent<Text>().text = playerCharacterSheet.GetCrit().ToString();
    }
}
