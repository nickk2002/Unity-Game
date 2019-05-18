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
            if(itemNumber >= 0)
                itemNumber--;
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
        
        if (Input.GetKeyDown(KeyCode.Tab))
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
    private void SwitchWeaponNumberKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

        }

    }
    private void InspectWeapon()
    {
        if (Camera.main.transform.childCount == 0)
            return;
        Vector3 rotation = selectedWeapon.Prefab.transform.rotation.eulerAngles;
        float value = 15;
        Vector3 modifiedRotation = new Vector3(rotation.x,rotation.y + 15, rotation.z);
        if (Input.GetKey(KeyCode.F) && selectedWeapon != null)
        {            
            objectWeapon.transform.eulerAngles = Vector3.Lerp(rotation,modifiedRotation, inspectTIme);
            Debug.Log("Insepcting");
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
        Debug.Log("Cursor is : " + Cursor.visible);
    }
}
