using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {
    public enum ItemType
    {
        Pistol,
        AK47,
        UMP45,
        M4A1
    }
    public ItemType itemtype;
    public GameObject Reference;

    public ItemType Type { set { itemtype = value; } get { return itemtype; } }
    void Start()
    {
        
    }
    void Update()
    {

    }
}
