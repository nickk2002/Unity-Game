using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Weapon> Weapons;  
    private Weapon selectedWeapon,foundWeapon;
    private int indexWeapon = -1;
    private GameObject objectWeapon = null;
    private float curentY;
    [SerializeField] float scrollTime = 0.5f,inspectTIme = 0;
    private float nextScroll;
    [SerializeField] Inventory inventory;


    // Update is called once per frame
    private void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.gameObject.GetComponent<InventoryItem>() != null)
        {
            foundWeapon = null;
            InventoryItem itembox = otherCollider.gameObject.transform.GetComponent<InventoryItem>();
            GiveItem(itembox.Type, itembox.Amount);
            Debug.Log(itembox.gameObject.name);
            //if (foundWeapon == null)
                ///Destroy(otherCollider.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<InventoryItem>() != null)
        {
            InventoryItem obj = other.gameObject.GetComponent<InventoryItem>();
            RemoveItem(obj.Type);
        }
    }
    private void GiveItem(InventoryItem.ItemType type,int amount) {
        Weapon currentWeapon = null;
        if (type == InventoryItem.ItemType.Pistol)
            currentWeapon = new Pistol();
        else if (type == InventoryItem.ItemType.AK47)
            currentWeapon = new AK47();
        else if (type == InventoryItem.ItemType.UMP45)
            currentWeapon = new UMP45();
        else if (type == InventoryItem.ItemType.M4A1)
            currentWeapon = new M4A1();

        for (int i = 0; i < Weapons.Count; i++)
        {
            if (Weapons[i].itemName == currentWeapon.itemName)
            {
                foundWeapon = Weapons[i];
                //objectWeapon = transform.GetChild(0).GetChild(i).gameObject;
            }
        }
       
        if (foundWeapon == null)
        {
            selectedWeapon = currentWeapon;
            Weapons.Add(selectedWeapon);
            inventory.AddItem(selectedWeapon);
        }
        if (indexWeapon == -1)
        {
            indexWeapon = Weapons.Count - 1;
        }
        selectedWeapon.AddAmmuntion(amount);
        selectedWeapon.LoadClip();
    }
    private void RemoveItem(InventoryItem.ItemType type)
    {
        GameObject loot = inventory.transform.GetChild(1).gameObject;
        foreach(Transform child in loot.transform)
        {

        }
    }
    private void ToggleInventory()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventory.gameObject.active)
            {
                inventory.gameObject.SetActive(false);
                Cursor.visible = false;
            }
            else
            {
                inventory.gameObject.SetActive(true);
                Cursor.visible = true;
                Debug.Log("Cursor is visible");
            }
        }

    }
    void WeaponActive()
    {
        if (indexWeapon == -1)
            return;
        objectWeapon = Camera.main.transform.GetChild(indexWeapon).gameObject;
        objectWeapon.SetActive(true);
        for (int i = 0; i < Weapons.Count; i++)
            if (i != indexWeapon)
            {
                ///Debug.Log("finally");
                Camera.main.transform.GetChild(i).gameObject.SetActive(false);
            }
    }
    private void SwitchWeapon()
    {

        if (indexWeapon == -1) {
            ///Debug.Log("No weapons");
            return;
        }
        //Debug.Log("WE have a weapon at index : " + indexWeapon)
        Camera.main.transform.GetChild(indexWeapon).gameObject.SetActive(true);
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && nextScroll >= scrollTime)
        {
            indexWeapon++;
            indexWeapon %= Camera.main.transform.childCount;
            nextScroll = 0;
            
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && nextScroll >= scrollTime)
        {
            indexWeapon--;
            if (indexWeapon < 0)
                indexWeapon = Camera.main.transform.childCount - 1;
            nextScroll = 0;
        }
        nextScroll += Time.deltaTime;
        
    }
    private void InspectWeapon()
    {
        if (selectedWeapon == null)
            return;
        Quaternion rotation = selectedWeapon.Prefab.transform.rotation;
        Quaternion modifiedRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + curentY, transform.rotation.eulerAngles.x);
        if (Input.GetKey(KeyCode.F) && selectedWeapon != null)
        {            
            objectWeapon.transform.localRotation = Quaternion.Slerp(rotation,modifiedRotation, inspectTIme);
            if (curentY >= -100)
            {
                curentY -= 5.0f;
                inspectTIme += Time.deltaTime;
            }
            else
            {
                inspectTIme -= Time.deltaTime;
            }
        }
    }

    void Start()
    {
        Weapons = new List<Weapon>();
        inventory.gameObject.SetActive(false);
        /*foreach(Transform child in inventory.transform)
        {
            foreach (Transform slot in child.transform)
                slot.gameObject.SetActive(false);
        }*/
        nextScroll = scrollTime;
        Cursor.visible = false;
    }
    void Update()
    {
        ToggleInventory();
        SwitchWeapon();
        WeaponActive();
        InspectWeapon();
    }
}
