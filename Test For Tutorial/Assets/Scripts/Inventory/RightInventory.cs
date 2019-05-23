using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightInventory : MonoBehaviour
{
    List<Weapon> Weapons;
    public Player player;
    void Awake()
    {
        Weapons = new List<Weapon>();
        Debug.Log("Start");
    }

    public bool Find(Weapon weapon)
    {
        Debug.Log(weapon);
        for (int i = 0; i < Weapons.Count; i++)
        {
            if (Weapons[i].itemName == weapon.itemName)
                return true;
        }
        return false;
    }
    private int FreeIndex()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject child = this.transform.GetChild(i).gameObject;
            if (!child.gameObject.activeSelf)   
                return i;
        }
        return -1;
    }
    private void SelectWeapon(Weapon weapon)
    {
        GameObject Generated;
        Generated = Instantiate(weapon.Prefab);
        Generated.transform.parent = Camera.main.transform;
        RotationY comp = Generated.GetComponent<RotationY>();
        Destroy(comp);
        Generated.transform.localPosition = weapon.Prefab.transform.position;
        Generated.transform.localEulerAngles = weapon.Prefab.transform.rotation.eulerAngles;
    }
    public void AddItem(InventoryItem.ItemType type)
    {
        Weapon currentWeapon = null;
        if (type == InventoryItem.ItemType.Pistol)
            currentWeapon = new Pistol();
        else if (type == InventoryItem.ItemType.AK47)
            currentWeapon = new AK47();
        else if (type == InventoryItem.ItemType.UMP45)
            currentWeapon = new UMP45();
        else if (type == InventoryItem.ItemType.M4A1)
            currentWeapon = new M4A1();
       
        if(FreeIndex() != -1 && !Find(currentWeapon))
        {
            Debug.Log(currentWeapon + " is being put on the right plane");  
            Debug.Log("Index free : " + FreeIndex());
            if (player.indexWeapon == -1)
                player.indexWeapon++;

            GameObject curentChild = this.transform.GetChild(FreeIndex()).gameObject;
            curentChild.SetActive(true);
            curentChild.GetComponent<Image>().sprite = currentWeapon.itemSprite;
            Weapons.Add(currentWeapon);
            SelectWeapon(currentWeapon);
        }
    }
}
