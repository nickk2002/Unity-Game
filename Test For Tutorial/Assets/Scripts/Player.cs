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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventory.gameObject.SetActive(true);
        else if (Input.GetKeyUp(KeyCode.I))
            inventory.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider otherCollider)
    {
        Debug.Log("DA");
        if(otherCollider.gameObject.transform.parent.GetComponent<ItemBox>() != null)
        {
            Debug.Log(otherCollider.name);
            ItemBox itembox = otherCollider.gameObject.transform.parent.GetComponent<ItemBox>();         
            GiveItem(itembox.Type, itembox.Amount);
            Destroy(otherCollider.gameObject);
        }
    }
    private void GiveItem(ItemBox.ItemType type,int amount) {  
        if(type == ItemBox.ItemType.Pistol)
        {
            Weapon curweapon = null;
           
            for(int i = 0; i < Weapons.Count; i++)
            {
                if (Weapons[i] is Pistol)
                    curweapon = Weapons[i];
            }

            if (curweapon == null)
            {
                curweapon = new Pistol();
                selectedWeapon = curweapon;
                Weapons.Add(selectedWeapon);
                inventory.AddItem(selectedWeapon);
            }
            selectedWeapon.AddAmmuntion(amount);
            selectedWeapon.LoadClip();
        }
        if (type == ItemBox.ItemType.AK47)
        {
            Weapon curweapon = null;
            for (int i = 0; i < Weapons.Count; i++)
            {
                if (Weapons[i] is AK47)
                    curweapon = Weapons[i];
            }

            if (curweapon == null)
            {
                curweapon = new AK47();
                selectedWeapon = curweapon;
                Weapons.Add(selectedWeapon);
                inventory.AddItem(selectedWeapon);
            }
            selectedWeapon.AddAmmuntion(amount);
            selectedWeapon.LoadClip();
        }
    }
}
