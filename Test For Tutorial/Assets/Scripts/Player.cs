using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Weapon> Weapons;  
    private Weapon selectedWeapon,foundWeapon;
    private int indexWeapon;
    private GameObject objectWeapon = null;
    private float curentY,time;
    [SerializeField] Inventory inventory;
    void Start()
    {
        Weapons = new List<Weapon>();
        inventory.gameObject.SetActive(false);
        /*Debug.Log("FPS Controller "  + transform.position);
        Debug.Log("FPS Character " + this.transform.GetChild(0).transform.position);
        Debug.Log("FPS Character local positon" + this.transform.GetChild(0).transform.localPosition);
        Debug.Log("AK47 " + this.transform.GetChild(0).GetChild(0).transform.position);
        Debug.Log("Ak47 local positon" + this.transform.GetChild(0).GetChild(0).transform.localPosition);*/

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.gameObject.transform.parent != null && otherCollider.gameObject.transform.parent.GetComponent<ItemBoxes>() != null )
        {
            foundWeapon = null;
            ItemBoxes itembox = otherCollider.gameObject.transform.parent.GetComponent<ItemBoxes>();
            GiveItem(itembox.Type, itembox.Amount);
                
            if (foundWeapon == null)
            {
                Debug.Log(otherCollider.gameObject);
                Debug.Log(objectWeapon);
                Destroy(otherCollider.gameObject);
            }
            
        }
    }
    private void GiveItem(ItemBoxes.ItemType type,int amount) {
        Weapon currentWeapon = null;
        if (type == ItemBoxes.ItemType.Pistol)
            currentWeapon = new Pistol();
        else if (type == ItemBoxes.ItemType.AK47)
            currentWeapon = new AK47();
        else if (type == ItemBoxes.ItemType.UMP45)
            currentWeapon = new UMP45();
        else if (type == ItemBoxes.ItemType.M4A1)
            currentWeapon = new M4A1();
        for (int i = 0; i < Weapons.Count; i++)
        {
            if (Weapons[i].itemName == currentWeapon.itemName)
            {
                foundWeapon = Weapons[i];
                indexWeapon = i;
                objectWeapon = transform.GetChild(0).GetChild(i).gameObject;
                break;
            }
        }
        if (foundWeapon == null)
        {
            Debug.Log("New Weapon");
            selectedWeapon = currentWeapon;
            Weapons.Add(selectedWeapon);
            inventory.AddItem(selectedWeapon);
            objectWeapon = transform.GetChild(0).GetChild(Weapons.Count - 1).gameObject;
        }
        selectedWeapon.AddAmmuntion(amount);
        selectedWeapon.LoadClip();
    }
    void ShowInventory()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
            inventory.gameObject.SetActive(true);
        else if (Input.GetKeyUp(KeyCode.I))
            inventory.gameObject.SetActive(false);
    }
    void InspectWeapon()
    {
        if (selectedWeapon == null)
            return;
        Quaternion rotation = selectedWeapon.Prefab.transform.rotation;
        Quaternion modifiedRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + curentY, transform.rotation.eulerAngles.x);
        if (Input.GetKey(KeyCode.F) && selectedWeapon != null)
        {
            Debug.Log(time);
            
            objectWeapon.transform.localRotation = Quaternion.Slerp(rotation,modifiedRotation, time);
            if (curentY >= -100)
            {
                curentY -= 5.0f;
                time += Time.deltaTime;
            }
        }
        else
        {
            //curentY = 0;
            //objectWeapon.transform.localRotation = Quaternion.Slerp(objectWeapon.transform.rotation,rotation,time);
        }
    }
    void Update()
    {
        ShowInventory();
        InspectWeapon();
    }
}
