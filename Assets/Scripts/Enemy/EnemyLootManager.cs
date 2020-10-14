using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLootManager : MonoBehaviour
{
    [SerializeField] private PlayerItem loot;
    EnemyLootDrop lootDrop;
    // Start is called before the first frame update
    void Start()
    {
        lootDrop = new EnemyLootDrop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerCharacterManager playerManager = collision.transform.GetComponent<PlayerCharacterManager>();
            PlayerCharacterSheet playerCharacterSheet = playerManager.GetPlayerCharacterSheet();
            if (transform.tag == "CommonLoot")
            {
                loot = lootDrop.CommonLootDrop();
                bool addItem = playerManager.GetPlayerCharacterSheet().GetInventory().AddItemToInventory(loot);
                //add item stats to character sheet
                if(addItem)
                {
                    float stamina = playerCharacterSheet.GetStamina() + loot.GetStamina();
                    playerCharacterSheet.SetStamina(stamina);
                    float currentHealth = playerCharacterSheet.GetCurrentHealth() + loot.GetStamina();
                    playerCharacterSheet.SetCurrentHealth(currentHealth);
                    float mana = playerCharacterSheet.GetMagic() + loot.GetMana();
                    playerCharacterSheet.SetMagic(mana);
                    float currentMana = playerCharacterSheet.GetCurrentMana() + loot.GetMana();
                    playerCharacterSheet.SetCurrentMana(currentMana);
                    float armor = playerCharacterSheet.GetArmor() + loot.GetArmor();
                    playerCharacterSheet.SetArmor(armor);
                    float phyAttack = playerCharacterSheet.GetPhyAttack() + loot.GetPhyAtack();
                    playerCharacterSheet.SetPhyAttack(phyAttack);
                    float magAttack = playerCharacterSheet.GetMagAttack() + loot.GetMagAttack();
                    playerCharacterSheet.SetMagAttack(magAttack);
                    float crit = playerCharacterSheet.GetCrit() + loot.GetCrit();
                    playerCharacterSheet.SetCrit(crit);

                    CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
                    charSheetUI.UpdateCharacterSheetVisuals();
                    PlayerInventoryUI playerInventoryUI = GameObject.FindGameObjectWithTag("PlayerInventoryUI").GetComponent<PlayerInventoryUI>();
                    playerInventoryUI.UpdatePlayerInventoryVisuals();
                }

            }

            if (transform.tag == "RareLoot")
            {
                loot = lootDrop.RareLootDrop();
                bool addItem = collision.transform.GetComponent<PlayerCharacterManager>().GetPlayerCharacterSheet().GetInventory().AddItemToInventory(loot);
                if (addItem)
                {
                    float stamina = playerCharacterSheet.GetStamina() + loot.GetStamina();
                    playerCharacterSheet.SetStamina(stamina);
                    float currentHealth = playerCharacterSheet.GetCurrentHealth() + loot.GetStamina();
                    playerCharacterSheet.SetCurrentHealth(currentHealth);
                    float mana = playerCharacterSheet.GetMagic() + loot.GetMana();
                    playerCharacterSheet.SetMagic(mana);
                    float currentMana = playerCharacterSheet.GetCurrentMana() + loot.GetMana();
                    playerCharacterSheet.SetCurrentMana(currentMana);
                    float armor = playerCharacterSheet.GetArmor() + loot.GetArmor();
                    playerCharacterSheet.SetArmor(armor);
                    float phyAttack = playerCharacterSheet.GetPhyAttack() + loot.GetPhyAtack();
                    playerCharacterSheet.SetPhyAttack(phyAttack);
                    float magAttack = playerCharacterSheet.GetMagAttack() + loot.GetMagAttack();
                    playerCharacterSheet.SetMagAttack(magAttack);
                    float crit = playerCharacterSheet.GetCrit() + loot.GetCrit();
                    playerCharacterSheet.SetCrit(crit);

                    CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
                    charSheetUI.UpdateCharacterSheetVisuals();
                    PlayerInventoryUI playerInventoryUI = GameObject.FindGameObjectWithTag("PlayerInventoryUI").GetComponent<PlayerInventoryUI>();
                    playerInventoryUI.UpdatePlayerInventoryVisuals();
                }
            }

            if (transform.tag == "EpicLoot")
            {
                loot = lootDrop.EpicLootDrop();
                bool addItem = collision.transform.GetComponent<PlayerCharacterManager>().GetPlayerCharacterSheet().GetInventory().AddItemToInventory(loot);
                if (addItem)
                {
                    float stamina = playerCharacterSheet.GetStamina() + loot.GetStamina();
                    playerCharacterSheet.SetStamina(stamina);
                    float currentHealth = playerCharacterSheet.GetCurrentHealth() + loot.GetStamina();
                    playerCharacterSheet.SetCurrentHealth(currentHealth);
                    float mana = playerCharacterSheet.GetMagic() + loot.GetMana();
                    playerCharacterSheet.SetMagic(mana);
                    float currentMana = playerCharacterSheet.GetCurrentMana() + loot.GetMana();
                    playerCharacterSheet.SetCurrentMana(currentMana);
                    float armor = playerCharacterSheet.GetArmor() + loot.GetArmor();
                    playerCharacterSheet.SetArmor(armor);
                    float phyAttack = playerCharacterSheet.GetPhyAttack() + loot.GetPhyAtack();
                    playerCharacterSheet.SetPhyAttack(phyAttack);
                    float magAttack = playerCharacterSheet.GetMagAttack() + loot.GetMagAttack();
                    playerCharacterSheet.SetMagAttack(magAttack);
                    float crit = playerCharacterSheet.GetCrit() + loot.GetCrit();
                    playerCharacterSheet.SetCrit(crit);

                    CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
                    charSheetUI.UpdateCharacterSheetVisuals();
                    PlayerInventoryUI playerInventoryUI = GameObject.FindGameObjectWithTag("PlayerInventoryUI").GetComponent<PlayerInventoryUI>();
                    playerInventoryUI.UpdatePlayerInventoryVisuals();
                }
            }

            if (transform.tag == "LegendaryLoot")
            {
                loot = lootDrop.LegendaryLootDrop();
                bool addItem = collision.transform.GetComponent<PlayerCharacterManager>().GetPlayerCharacterSheet().GetInventory().AddItemToInventory(loot);
                if (addItem)
                {
                    float stamina = playerCharacterSheet.GetStamina() + loot.GetStamina();
                    playerCharacterSheet.SetStamina(stamina);
                    float currentHealth = playerCharacterSheet.GetCurrentHealth() + loot.GetStamina();
                    playerCharacterSheet.SetCurrentHealth(currentHealth);
                    float mana = playerCharacterSheet.GetMagic() + loot.GetMana();
                    playerCharacterSheet.SetMagic(mana);
                    float currentMana = playerCharacterSheet.GetCurrentMana() + loot.GetMana();
                    playerCharacterSheet.SetCurrentMana(currentMana);
                    float armor = playerCharacterSheet.GetArmor() + loot.GetArmor();
                    playerCharacterSheet.SetArmor(armor);
                    float phyAttack = playerCharacterSheet.GetPhyAttack() + loot.GetPhyAtack();
                    playerCharacterSheet.SetPhyAttack(phyAttack);
                    float magAttack = playerCharacterSheet.GetMagAttack() + loot.GetMagAttack();
                    playerCharacterSheet.SetMagAttack(magAttack);
                    float crit = playerCharacterSheet.GetCrit() + loot.GetCrit();
                    playerCharacterSheet.SetCrit(crit);

                    CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
                    charSheetUI.UpdateCharacterSheetVisuals();
                    PlayerInventoryUI playerInventoryUI = GameObject.FindGameObjectWithTag("PlayerInventoryUI").GetComponent<PlayerInventoryUI>();
                    playerInventoryUI.UpdatePlayerInventoryVisuals();
                }
            }
            Destroy(gameObject);
        }
    }
}
