using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Weapon> Weapons;  
    private Weapon selectedWeapon;
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
        if(otherCollider.gameObject.transform.parent != null && otherCollider.gameObject.transform.parent.GetComponent<ItemBoxes>() != null)
        {
            Debug.Log(otherCollider.name);
            ItemBoxes itembox = otherCollider.gameObject.transform.parent.GetComponent<ItemBoxes>();         
            GiveItem(itembox.Type, itembox.Amount);
            Destroy(otherCollider.gameObject);
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
        Weapon foundWeapon = null;
           
        for(int i = 0; i < Weapons.Count; i++)
            if (Weapons[i].itemName == currentWeapon.itemName)
                foundWeapon = Weapons[i];
        if (foundWeapon == null)
        {
            selectedWeapon = currentWeapon;
            Weapons.Add(selectedWeapon);
            inventory.AddItem(selectedWeapon);
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
        
        if (Input.GetKeyDown(KeyCode.F) && selectedWeapon != null)
        {   
            Vector3 rotation = selectedWeapon.Prefab.transform.rotation.eulerAngles;
            rotation.y += 10.0f;

        }

    }
    void Update()
    {
        ShowInventory();
    }
}
