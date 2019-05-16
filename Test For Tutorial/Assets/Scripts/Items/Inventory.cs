using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private const int allSlots = 5;
    private List<Weapon> Items;
    private int enabledSlots;
    private GameObject slotPrefab;
    private Material inventoryMaterial;

    public object InventoryItem { get; internal set; }

    void Start()
    {
        Items = new List<Weapon>();
        enabledSlots = 0;
        slotPrefab = Resources.Load("Prefabs/UI/Loot") as GameObject;
        inventoryMaterial = Resources.Load<Material>("Prefabs/Materials/Inventory");
        if (slotPrefab != null)
            Debug.Log("SlotPreafab has loadede succesfully!");
        else
            Debug.LogError("SlotPrefab not loaded!");
        Debug.Log(inventoryMaterial);
    }
    public bool Find(Weapon weapon)
    {
        for(int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemName == weapon.itemName)
                return true;
        }
        return false;
    }
    private void DisplayImage(int index,Weapon weapon, InventoryItem.ItemType type)
    {
        GameObject slotImage = Instantiate(slotPrefab,slotPrefab.transform.position,slotPrefab.transform.rotation) as GameObject;
        Debug.Log("Instatiated");
        GameObject loot = this.gameObject;
        slotImage.transform.SetParent(loot.transform,false);
        slotImage.transform.localScale = slotPrefab.transform.localScale;
        slotImage.GetComponent<InventoryItem>().Type = type;
        Image iconSprite = slotImage.transform.GetChild(0).gameObject.GetComponent<Image>();
        slotImage.transform.GetChild(1).gameObject.GetComponent<Text>().text = weapon.itemName;
        iconSprite.sprite = weapon.itemSprite;
    }
        
    public void AddItem(Weapon weapon,InventoryItem.ItemType type)
    {
        if (weapon.itemSprite != null) {
            DisplayImage(enabledSlots, weapon, type);
            Items.Add(weapon);
            ++enabledSlots;
        }   
    }
    public void RemoveItem(Weapon weapon)
    {
        GameObject loot = this.gameObject;
        foreach (Transform child in loot.transform)
        {
            GameObject slot = child.GetChild(1).gameObject;
            if (slot.GetComponent<Text>().text == weapon.itemName && weapon != null)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].itemName == weapon.itemName)
                    {
                        Debug.Log("Removed weapon : " + weapon.itemName);
                        Items.RemoveAt(i);
                        Debug.Log("Weapons Size : " + Items.Count);
                        break;
                    }

                }
                Destroy(child.gameObject);
            }

        }
    }
}
