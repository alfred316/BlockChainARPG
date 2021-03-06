﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerCharacterManager playerManager = collision.transform.GetComponent<PlayerCharacterManager>();
            PlayerCharacterSheet playerCharacterSheet = playerManager.GetPlayerCharacterSheet();
            if (transform.tag == "Health")
            {
                if(playerCharacterSheet.GetCurrentHealth() < playerCharacterSheet.GetStamina())
                {
                    float currentHealth = playerCharacterSheet.GetCurrentHealth() + 10;
                    playerCharacterSheet.SetCurrentHealth(currentHealth);
                }

                CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
                charSheetUI.UpdateCharacterSheetVisuals();
                PlayerInventoryUI playerInventoryUI = GameObject.FindGameObjectWithTag("PlayerInventoryUI").GetComponent<PlayerInventoryUI>();
                playerInventoryUI.UpdatePlayerInventoryVisuals();

            }
            if(transform.tag == "Mana")
            {
                if(playerCharacterSheet.GetCurrentMana() < playerCharacterSheet.GetMagic())
                {
                    float currentMana = playerCharacterSheet.GetCurrentMana() + 10;
                    playerCharacterSheet.SetCurrentMana(currentMana);
                }

                CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
                charSheetUI.UpdateCharacterSheetVisuals();
                PlayerInventoryUI playerInventoryUI = GameObject.FindGameObjectWithTag("PlayerInventoryUI").GetComponent<PlayerInventoryUI>();
                playerInventoryUI.UpdatePlayerInventoryVisuals();
            }
            if(transform.tag == "BigPowerup")
            {
                float phyAttack = playerCharacterSheet.GetPhyAttack() + 25;
                playerCharacterSheet.SetPhyAttack(phyAttack);
                float magAttack = playerCharacterSheet.GetMagAttack() + 25;
                playerCharacterSheet.SetMagAttack(magAttack);

                CharacterSheetUI charSheetUI = GameObject.FindGameObjectWithTag("CharacterSheetUI").GetComponent<CharacterSheetUI>();
                charSheetUI.UpdateCharacterSheetVisuals();
                PlayerInventoryUI playerInventoryUI = GameObject.FindGameObjectWithTag("PlayerInventoryUI").GetComponent<PlayerInventoryUI>();
                playerInventoryUI.UpdatePlayerInventoryVisuals();
            }
            if(transform.tag == "RebuildWall")
            {
                GameObject[] walls = GameObject.FindGameObjectsWithTag("WallSpawnpoint");
                foreach(GameObject env in walls)
                {
                    //MeshRenderer mesh = env.GetComponent<MeshRenderer>();
                    //BoxCollider col = env.GetComponent<BoxCollider>();
                    Debug.Log("found walls");
                    //if (col.enabled == false && mesh.enabled == false)
                    if(env.transform.childCount == 0)
                    {
                        Debug.Log("Rebuilding Wall");
                        //env.SetActive(true);
                        //mesh.enabled = true;
                        //col.enabled = true;
                        //GameObject breakmeWall = Resources.Load<GameObject>("Props/BreakableDoor") as GameObject;
                        //Instantiate(breakmeWall, env.transform.position, Quaternion.identity);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
