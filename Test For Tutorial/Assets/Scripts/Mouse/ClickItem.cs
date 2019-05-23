using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickItem : MonoBehaviour
{
    private RightInventory inventory;
    

    private void Start()
    {
        inventory = GameObject.Find("Weapons").GetComponent<RightInventory>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("CliCked : " + this.gameObject + " Inventory : " + inventory);
            
            GameObject loot = this.transform.parent.gameObject;
            InventoryItem inventoyItem = loot.GetComponent<InventoryItem>();
            inventory.AddItem(inventoyItem.Type);
            GameObject toDestory = inventoyItem.Reference;
            Destroy(toDestory);
            Destroy(loot);
        }
    }
}
