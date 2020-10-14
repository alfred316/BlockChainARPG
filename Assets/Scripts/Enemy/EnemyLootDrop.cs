using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyLootDrop 
{
    //reads file and loads data from it based on id
    //static string path = "Assets/Resources/Loot/LootList.txt";
    //StreamReader reader = new StreamReader(path);

    public EnemyLootDrop(){}

    //0 = green, 1 = blue, 2 = purple, 3 = legendary
    public int BasicEnemyDrop()
    {
        //basic enemy: 80% green, 15% blue, 5% purple
        int tmp = Random.Range(1, 100);
        if(tmp >= 1 && tmp <= 80)
        {
            //green
            return 0;
        }
        else if(tmp >= 81 && tmp <= 95)
        {
            //blue
            return 1;
        }
        else if(tmp >= 96 && tmp <= 100)
        {
            //EPIC
            return 2;
        }

        return -1;
    }

    public int EliteEnemyDrop()
    {
        //intermediate enemy: 50% green, 35% blue, 15% purple
        int tmp = Random.Range(1, 100);
        if (tmp >= 1 && tmp <= 50)
        {
            //green
            return 0;
        }
        else if (tmp >= 51 && tmp <= 85)
        {
            //blue
            return 1;
        }
        else if (tmp >= 86 && tmp <= 100)
        {
            //EPIC
            return 2;
        }

        return -1;
    }

    public int BossEnemyDrop()
    {
        //hard enemy: 30% green, 40% blue, 29% purple, 1% orange
        int tmp = Random.Range(1, 100);
        if (tmp >= 1 && tmp <= 30)
        {
            //green
            return 0;
        }
        else if (tmp >= 31 && tmp <= 70)
        {
            //blue
            return 1;
        }
        else if (tmp >= 71 && tmp <= 98)
        {
            //EPIC
            return 2;
        }
        else if (tmp >= 99 && tmp <= 100)
        {
            //L E G E N D A R Y
            return 3;
        }
        return -1;
    }

    public PlayerItem CommonLootDrop()
    {
        //random number based on ids of items
        int tmp = Random.Range(0, 3);

        return new PlayerItem(tmp);
        
    }

    public PlayerItem RareLootDrop()
    {
        // Instantiate random number generator using system-supplied value as seed.
        int tmp = Random.Range(4, 6);

        return new PlayerItem(tmp);


    }

    public PlayerItem EpicLootDrop()
    {
        // Instantiate random number generator using system-supplied value as seed.
        int tmp = Random.Range(7, 9);

        return new PlayerItem(tmp);


    }

    public PlayerItem LegendaryLootDrop()
    {
        // Instantiate random number generator using system-supplied value as seed.
        int tmp = 10;

        return new PlayerItem(tmp);
    }
}
