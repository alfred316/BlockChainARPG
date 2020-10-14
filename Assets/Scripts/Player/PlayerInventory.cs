using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory 
{
    private List<PlayerItem> items;
    private int _maxsize;
    private int _itemcount;

    public PlayerInventory()
    {
        items = new List<PlayerItem>();
        _maxsize = 4;
        _itemcount = 0;
    }

    public bool AddItemToInventory(PlayerItem item)
    {
        if(_itemcount < _maxsize)
        {
            //add to list
            items.Add(item);
            //actually tell the item its in the bag
            item.PutInBag();
            _itemcount += 1;
            Debug.Log("NEW ITEM ADDED TO INVENTORY" + item);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveItemFromInventory(PlayerItem item)
    {
        if(_itemcount > 0)
        {
            items.Remove(item);
            _itemcount -= 1;
        }
    }

    public PlayerItem FindItem(int id)
    {
        PlayerItem temp = new PlayerItem(-1);
        foreach(PlayerItem item in items)
        {
            int index = item.GetId();
            if(index == id)
            {
                return item;
            }
        }
        return temp;
    }

    public int GetMaxSize()
    {
        return _maxsize;
    }

    public int GetItemCount()
    {
        return _itemcount;
    }

    public List<PlayerItem> GetAllItems()
    {
        return items;
    }

    
}
