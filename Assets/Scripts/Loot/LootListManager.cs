using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootListManager
{

    public List<List<string>> lootList;
    public int size = 11;
    List<string> item;

    // Start is called before the first frame update
    public LootListManager()
    {
        lootList = new List<List<string>>();

        //item.Add()
        //0
        item = new List<string>() { "-1", "notfound", "notfound", "0", "0", "0", "0", "0", "0" };
        lootList.Add(item);
        //1
        item = new List<string>() { "0", "common", "Chain_Mail", "5", "0", "4", "3", "0", "1" };
        lootList.Add(item);
        //2
        item = new List<string>() { "1", "common", "Long_Staff", "3", "5", "2", "1", "3", "2" };
        lootList.Add(item);
        //3
        item = new List<string>() { "2", "common", "Shortsword", "3", "1", "2", "4", "2", "3" };
        lootList.Add(item);
        //4
        item = new List<string>() { "3", "common", "Shield", "4", "2", "5", "1", "1", "1" };
        lootList.Add(item);
        //5
        item = new List<string>() { "4", "rare", "Kite_Shield", "7", "3", "8", "1", "1", "1" };
        lootList.Add(item);
        //6
        item = new List<string>() { "5", "rare", "Mythril_Flail", "5", "2", "2", "6", "3", "4" };
        lootList.Add(item);
        //7
        item = new List<string>() { "6", "rare", "Pointy_Hat", "5", "7", "4", "3", "6", "4" };
        lootList.Add(item);
        //8
        item = new List<string>() { "7", "epic", "Drape_of_Might", "8", "8", "5", "7", "7", "5" };
        lootList.Add(item);
        //9
        item = new List<string>() { "8", "epic", "Wand_of_Wonders", "7", "8", "0", "0", "10", "10", };
        lootList.Add(item);
        //10
        item = new List<string>() { "9", "epic", "Shimmering_Glaive", "7", "5", "3", "10", "0", "10" };
        lootList.Add(item);
        //11
        item = new List<string>() { "10", "legendary", "Flame_Howl", "15", "15", "15", "15", "15", "25" };
        lootList.Add(item);

        Debug.Log("lootlist: " + lootList[1][2]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
