using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    public List<GameObject> UiItems;
    public GameObject PlayerInventoryPanel;
    public GameObject backImage;

    GameObject player;                          // Reference to the player GameObject.
    PlayerCharacterManager playerManager;
    PlayerCharacterSheet playerCharacterSheet;
    int itemCount;

    // Start is called before the first frame update
    void Start()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerManager = player.GetComponent<PlayerCharacterManager>();
        playerCharacterSheet = playerManager.GetPlayerCharacterSheet();
        itemCount = playerCharacterSheet.GetInventory().GetItemCount();
        UpdatePlayerInventoryVisuals();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (PlayerInventoryPanel.activeInHierarchy)
            {
                PlayerInventoryPanel.SetActive(false);
                backImage.SetActive(false);
            }
            else if (!PlayerInventoryPanel.activeInHierarchy)
            {
                PlayerInventoryPanel.SetActive(true);
                backImage.SetActive(true);
                UpdatePlayerInventoryVisuals();
            }
        }
    }

    public void UpdatePlayerInventoryVisuals()
    {
        itemCount = playerCharacterSheet.GetInventory().GetItemCount();
        if (itemCount > 0)
        {
            List<PlayerItem> items = playerCharacterSheet.GetInventory().GetAllItems();
            for(int i = 0; i < items.Count; i++)
            {
                UiItems[i].GetComponent<Text>().text = items[i].GetName();
            }
            for(int j = items.Count; j < items.Count - 4; j++)
            {
                UiItems[j].GetComponent<Text>().text = "Empty";
            }
        }
        else
        {
            for (int p = 0; p < 4 ; p++)
            {
                UiItems[p].GetComponent<Text>().text = "Empty";
            }
        }
    }

    public void RemoveItem1()
    {
        itemCount = playerCharacterSheet.GetInventory().GetItemCount();
        if(itemCount > 0)
        {
            Debug.Log("dropping item 1");
            List<PlayerItem> items = playerCharacterSheet.GetInventory().GetAllItems();
            //UiItems[0].GetComponent<Text>().text = "Empty";
            float stamina = playerCharacterSheet.GetStamina() - items[0].GetStamina();
            playerCharacterSheet.SetStamina(stamina);
            float currentHealth = playerCharacterSheet.GetCurrentHealth() - items[0].GetStamina();
            playerCharacterSheet.SetCurrentHealth(currentHealth);
            float mana = playerCharacterSheet.GetMagic() - items[0].GetMana();
            playerCharacterSheet.SetMagic(mana);
            float currentMana = playerCharacterSheet.GetCurrentMana() - items[0].GetMana();
            playerCharacterSheet.SetCurrentMana(currentMana);
            float armor = playerCharacterSheet.GetArmor() - items[0].GetArmor();
            playerCharacterSheet.SetArmor(armor);
            float phyAttack = playerCharacterSheet.GetPhyAttack() - items[0].GetPhyAtack();
            playerCharacterSheet.SetPhyAttack(phyAttack);
            float magAttack = playerCharacterSheet.GetMagAttack() - items[0].GetMagAttack();
            playerCharacterSheet.SetMagAttack(magAttack);
            float crit = playerCharacterSheet.GetCrit() - items[0].GetCrit();
            playerCharacterSheet.SetCrit(crit);


            playerCharacterSheet.GetInventory().RemoveItemFromInventory(items[0]);
            CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
            charSheetUI.UpdateCharacterSheetVisuals();
            UpdatePlayerInventoryVisuals();
        }
    }

    public void RemoveItem2()
    {
        itemCount = playerCharacterSheet.GetInventory().GetItemCount();
        if (itemCount > 0)
        {
            List<PlayerItem> items = playerCharacterSheet.GetInventory().GetAllItems();
            //UiItems[1].GetComponent<Text>().text = "Empty";
            float stamina = playerCharacterSheet.GetStamina() - items[1].GetStamina();
            playerCharacterSheet.SetStamina(stamina);
            float currentHealth = playerCharacterSheet.GetCurrentHealth() - items[1].GetStamina();
            playerCharacterSheet.SetCurrentHealth(currentHealth);
            float mana = playerCharacterSheet.GetMagic() - items[1].GetMana();
            playerCharacterSheet.SetMagic(mana);
            float currentMana = playerCharacterSheet.GetCurrentMana() - items[1].GetMana();
            playerCharacterSheet.SetCurrentMana(currentMana);
            float armor = playerCharacterSheet.GetArmor() - items[1].GetArmor();
            playerCharacterSheet.SetArmor(armor);
            float phyAttack = playerCharacterSheet.GetPhyAttack() - items[1].GetPhyAtack();
            playerCharacterSheet.SetPhyAttack(phyAttack);
            float magAttack = playerCharacterSheet.GetMagAttack() - items[1].GetMagAttack();
            playerCharacterSheet.SetMagAttack(magAttack);
            float crit = playerCharacterSheet.GetCrit() - items[1].GetCrit();
            playerCharacterSheet.SetCrit(crit);


            playerCharacterSheet.GetInventory().RemoveItemFromInventory(items[1]);
            CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
            charSheetUI.UpdateCharacterSheetVisuals();
            UpdatePlayerInventoryVisuals();
        }
    }

    public void RemoveItem3()
    {
        itemCount = playerCharacterSheet.GetInventory().GetItemCount();
        if (itemCount > 0)
        {
            List<PlayerItem> items = playerCharacterSheet.GetInventory().GetAllItems();
            //UiItems[2].GetComponent<Text>().text = "Empty";
            float stamina = playerCharacterSheet.GetStamina() - items[2].GetStamina();
            playerCharacterSheet.SetStamina(stamina);
            float currentHealth = playerCharacterSheet.GetCurrentHealth() - items[2].GetStamina();
            playerCharacterSheet.SetCurrentHealth(currentHealth);
            float mana = playerCharacterSheet.GetMagic() - items[2].GetMana();
            playerCharacterSheet.SetMagic(mana);
            float currentMana = playerCharacterSheet.GetCurrentMana() - items[2].GetMana();
            playerCharacterSheet.SetCurrentMana(currentMana);
            float armor = playerCharacterSheet.GetArmor() - items[2].GetArmor();
            playerCharacterSheet.SetArmor(armor);
            float phyAttack = playerCharacterSheet.GetPhyAttack() - items[2].GetPhyAtack();
            playerCharacterSheet.SetPhyAttack(phyAttack);
            float magAttack = playerCharacterSheet.GetMagAttack() - items[2].GetMagAttack();
            playerCharacterSheet.SetMagAttack(magAttack);
            float crit = playerCharacterSheet.GetCrit() - items[2].GetCrit();
            playerCharacterSheet.SetCrit(crit);


            playerCharacterSheet.GetInventory().RemoveItemFromInventory(items[2]);
            CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
            charSheetUI.UpdateCharacterSheetVisuals();
            UpdatePlayerInventoryVisuals();
        }
    }

    public void RemoveItem4()
    {
        itemCount = playerCharacterSheet.GetInventory().GetItemCount();
        if (itemCount > 0)
        {
            List<PlayerItem> items = playerCharacterSheet.GetInventory().GetAllItems();
            //UiItems[3].GetComponent<Text>().text = "Empty";
            float stamina = playerCharacterSheet.GetStamina() - items[3].GetStamina();
            playerCharacterSheet.SetStamina(stamina);
            float currentHealth = playerCharacterSheet.GetCurrentHealth() - items[3].GetStamina();
            playerCharacterSheet.SetCurrentHealth(currentHealth);
            float mana = playerCharacterSheet.GetMagic() - items[3].GetMana();
            playerCharacterSheet.SetMagic(mana);
            float currentMana = playerCharacterSheet.GetCurrentMana() - items[3].GetMana();
            playerCharacterSheet.SetCurrentMana(currentMana);
            float armor = playerCharacterSheet.GetArmor() - items[3].GetArmor();
            playerCharacterSheet.SetArmor(armor);
            float phyAttack = playerCharacterSheet.GetPhyAttack() - items[3].GetPhyAtack();
            playerCharacterSheet.SetPhyAttack(phyAttack);
            float magAttack = playerCharacterSheet.GetMagAttack() - items[3].GetMagAttack();
            playerCharacterSheet.SetMagAttack(magAttack);
            float crit = playerCharacterSheet.GetCrit() - items[3].GetCrit();
            playerCharacterSheet.SetCrit(crit);


            playerCharacterSheet.GetInventory().RemoveItemFromInventory(items[3]);
            CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
            charSheetUI.UpdateCharacterSheetVisuals();
            UpdatePlayerInventoryVisuals();
        }
    }
}
