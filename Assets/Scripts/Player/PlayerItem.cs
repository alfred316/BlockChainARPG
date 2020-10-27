using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class PlayerItem 
{
    private int _id;
    private string _rarity;
    private string _name;
    private float _stamina;
    private float _mana;
    private float _armor;
    private float _phyattack;
    private float _magattack;
    private float _crit;
    private bool _equipped; //false/unequipped true/equipped
    private bool _inbag;
    public PlayerItem(int id)
    {
        LootListManager lootList = new LootListManager();
        //reads file and loads data from it based on id
        //string path = "Assets/Resources/LootList.txt";
        //StreamReader reader = new StreamReader(path);
        string tmp = lootList.lootList[1][2];
        Debug.Log("item from lootList: " + tmp);
        //UnityWebRequest www = UnityWebRequest.Get("https://raw.githubusercontent.com/alfred316/alfred316.github.io/master/other/LootList.txt");
        //string data = www.downloadHandler.text;
        //Debug.Log("data is: " + data);
        //GetText();
        for(int i = 0; i < lootList.size; i++)
        {
            if (int.Parse(lootList.lootList[i][0]) == id)
            {
                //found item
                Debug.Log("found item, adding: " + lootList.lootList[i][2]);
                _id = id;
                _rarity = lootList.lootList[i][1];
                _name = lootList.lootList[i][2];
                _stamina = float.Parse(lootList.lootList[i][3]);
                _mana = float.Parse(lootList.lootList[i][4]);
                _armor = float.Parse(lootList.lootList[i][5]);
                _phyattack = float.Parse(lootList.lootList[i][6]);
                _magattack = float.Parse(lootList.lootList[i][7]);
                _crit = float.Parse(lootList.lootList[i][8]);
                _equipped = false;
                _inbag = false;
                break;
            }
        }
        
        /*
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            Debug.Log("LINE: " + line);
            //string line = reader.ReadLine();
            //Debug.Log("LINE: " + line);
            string[] words = line.Split(' ');
            if(int.Parse(words[0]) == id)
            {
                //found item
                _id = id;
                _rarity = words[1];
                _name = words[2];
                _stamina = float.Parse(words[3]);
                _mana = float.Parse(words[4]);
                _armor = float.Parse(words[5]);
                _phyattack = float.Parse(words[6]);
                _magattack = float.Parse(words[7]);
                _crit = float.Parse(words[8]);
                _equipped = false;
                _inbag = false;
                break;
            }

        }
        */
        
    }
    /*
    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://jsonplaceholder.typicode.com/posts/1");

        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log("in gettext");
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            //byte[] results = www.downloadHandler.data;
        }
    }
    */
    //getters
    public int GetId()
    {
        return _id;
    }

    public string GetRarity()
    {
        return _rarity;
    }

    public string GetName()
    {
        return _name;
    }

    public float GetStamina()
    {
        return _stamina;
    }

    public float GetMana()
    {
        return _mana;
    }

    public float GetArmor()
    {
        return _armor;
    }

    public float GetPhyAtack()
    {
        return _phyattack;
    }

    public float GetMagAttack()
    {
        return _magattack;
    }

    public float GetCrit()
    {
        return _crit;
    }

    public bool IsEquipped()
    {
        return _equipped;
    }

    public bool IsInBag()
    {
        return _inbag;
    }

    //setters

    public void PutInBag()
    {
        _inbag = true;
    }

    public void RemoveFromBag()
    {
        _inbag = false;
    }
}
