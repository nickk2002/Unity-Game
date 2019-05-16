using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int itemNumber;  
    private Weapon selectedWeapon,foundWeapon;
    public int indexWeapon = -1;
    private GameObject objectWeapon = null;
    private float curentY;
    [SerializeField] float scrollTime = 0.5f,inspectTIme = 0;
    private float nextScroll;
    [SerializeField] Inventory inventory,allInventory;


    // Update is called once per frame
    private void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.gameObject.GetComponent<InventoryItem>() != null)
        {
            foundWeapon = null;
            InventoryItem itembox = otherCollider.gameObject.transform.GetComponent<InventoryItem>();
            GiveItem(itembox.Type, itembox.Amount);
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

        Debug.Log(itemNumber);
        if (!inventory.Find(currentWeapon))
        {
            itemNumber++;
            Debug.Log("New weapon" + currentWeapon.itemName);
            selectedWeapon = currentWeapon;
            inventory.AddItem(selectedWeapon,type);
        }

        selectedWeapon.AddAmmuntion(amount);
        selectedWeapon.LoadClip();
    }
    private void RemoveItem(InventoryItem.ItemType type)
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
        inventory.RemoveItem(currentWeapon);
    }
    private void ToggleInventory()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (allInventory.gameObject.active)
            {
                allInventory.gameObject.SetActive(false);
                Cursor.visible = false;
            }
            else
            {
                allInventory.gameObject.SetActive(true);
                Cursor.visible = true;
            }
        }

    }
    void WeaponActive()
    {
        if (Camera.main.transform.childCount == 0)
            return;
        objectWeapon = Camera.main.transform.GetChild(indexWeapon).gameObject;
        objectWeapon.SetActive(true);
        for (int i = 0; i < Camera.main.transform.childCount; i++)
        {
            if (i != indexWeapon)
            {
                Camera.main.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void SwitchWeapon()
    {
        if (Camera.main.transform.childCount == 0)
            return;
        
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
        if (Camera.main.transform.childCount == 0)
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
        GameObject weaponsInventory = GameObject.Find("Weapons");
        if (weaponsInventory == null)
            Debug.LogError("not found Weapons");
        foreach (Transform child in weaponsInventory.transform)
        {
            child.gameObject.SetActive(false);
        }
        itemNumber = 0;
        allInventory.gameObject.SetActive(false);
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
