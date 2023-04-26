using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private GameObject inventory = null;

    public void AddItem(GameObject item)
    {
        inventory = item;
    }

    public void RemoveItem()
    {
        inventory = null;
    }

    public bool IsEmpty()
    {
        if( inventory == null ) { return true; }else { return false; }
    }

    public GameObject Get()
    {
        return inventory;
    }
}
