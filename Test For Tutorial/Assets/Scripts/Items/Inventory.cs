using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : InventoryItem
{

    private const int allSlots = 5;
    private int enabledSlots;
    private GameObject slotPrefab;
    private Material inventoryMaterial;

    public object InventoryItem { get; internal set; }

    void Start()
    {
        enabledSlots = 0;
        slotPrefab = Resources.Load("Prefabs/UI/Loot") as GameObject;
        inventoryMaterial = Resources.Load<Material>("Prefabs/Materials/Inventory");
        if (slotPrefab != null)
            Debug.Log("SlotPreafab has loadede succesfully!");
        else
            Debug.LogError("SlotPrefab not loaded!");
        Debug.Log(inventoryMaterial);
    }
    private void SelectWeapon(Weapon weapon)
    {            
        GameObject Generated;
        Generated = Instantiate(weapon.Prefab);
        Generated.transform.parent = Camera.main.transform;
        Generated.transform.localPosition = weapon.Prefab.transform.position;
        Generated.transform.localEulerAngles = weapon.Prefab.transform.rotation.eulerAngles;
    }
    private void DisplayWeaponAndBullets(int index,Weapon weapon)
    {
        GameObject slotImage = Instantiate(slotPrefab,slotPrefab.transform.position,slotPrefab.transform.rotation) as GameObject;
        slotImage.transform.parent = transform.GetChild(1);
        slotImage.transform.localScale = slotPrefab.transform.localScale;
        Image iconSprite = slotImage.transform.GetChild(0).gameObject.GetComponent<Image>();
        slotImage.transform.GetChild(1).gameObject.GetComponent<Text>().text = weapon.itemName;
        iconSprite.sprite = weapon.itemSprite;
    }
        
    public void AddItem(Weapon weapon)
    {
        if (weapon.itemSprite != null) {
            DisplayWeaponAndBullets(enabledSlots, weapon);
            //SelectWeapon(weapon);
            ++enabledSlots;
        }   
    }
}
