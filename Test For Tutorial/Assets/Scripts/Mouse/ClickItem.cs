using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickItem : MonoBehaviour
{
    public GameObject weaponsInventory;

    private int FreeIndex()
    {
        for(int i = 0; i < weaponsInventory.transform.childCount; i++)
        {
            GameObject child = weaponsInventory.transform.GetChild(i).gameObject;
            if (!child.gameObject.active)
                return i;
        }
        return -1;
    }
    private void SelectWeapon(Weapon weapon)
    {
        GameObject Generated;
        Generated = Instantiate(weapon.Prefab);
        Generated.transform.parent = Camera.main.transform;
        Generated.transform.localPosition = weapon.Prefab.transform.position;
        Generated.transform.localEulerAngles = weapon.Prefab.transform.rotation.eulerAngles;
        
    }
    private void PutWeaponRight()
    {
        if (FreeIndex() == -1)
            return;
        GameObject curentChild = weaponsInventory.transform.GetChild(FreeIndex()).gameObject;
        curentChild.SetActive(true);
        curentChild.GetComponent<Image>().sprite = transform.GetComponent<Image>().sprite;
        InventoryItem.ItemType type =  this.transform.parent.gameObject.GetComponent<InventoryItem>().Type;
        
        Debug.Log("The type is : " + type);
        Weapon currentWeapon = null;
        if (type == InventoryItem.ItemType.Pistol)
            currentWeapon = new Pistol();
        else if (type == InventoryItem.ItemType.AK47)
            currentWeapon = new AK47();
        else if (type == InventoryItem.ItemType.UMP45)
            currentWeapon = new UMP45();
        else if (type == InventoryItem.ItemType.M4A1)
            currentWeapon = new M4A1();
        SelectWeapon(currentWeapon);
    }
    private void Start()
    {
        weaponsInventory = GameObject.Find("Weapons");
        if (weaponsInventory == null)
            Debug.LogError("not found Weapons");
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PutWeaponRight();
        }
    }
}
