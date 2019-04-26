using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : InventoryItem
{

    private const int allSlots = 5;
    private int enabledSlots;
    private Sprite [] ItemSprites = new Sprite [allSlots];
    [SerializeField] GameObject inventory;
    
    void Start()
    {
        enabledSlots = 0;
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventory.SetActive(true);
        else if (Input.GetKeyUp(KeyCode.I))
            inventory.SetActive(false);
    }
    private void DisplayWeaponAndBullets(int index,Weapon weapon)
    {
        Debug.Log("Suntem la indexul : " + index);
        GameObject slotImage = transform.GetChild(index * 2).GetChild(0).gameObject;
        GameObject slotBullets = transform.GetChild(index * 2 + 1).GetChild(0).gameObject;
        
        Image iconSprite = slotImage.GetComponent<Image>();
        iconSprite.sprite = weapon.itemSprite;
        Image iconBullets = slotBullets.GetComponent<Image>();
        iconBullets.sprite = weapon.bulletSprite;
        //slotBullets.transform.parent.GetChild(1).GetComponent<Text>().text = "Contains";
    }
    public void DisplayBulletsUI(Weapon weapon)
    {
        //GameObject BulletsText = transform.GetChild(0).GetChild
    }
    public void AddItem(Weapon weapon)
    {
        if (weapon.itemSprite != null) {
            Sprite ceva = weapon.itemSprite;
            ItemSprites[enabledSlots] = ceva;
            DisplayWeaponAndBullets(enabledSlots, weapon);
            ++enabledSlots;
        }   
    }
}
