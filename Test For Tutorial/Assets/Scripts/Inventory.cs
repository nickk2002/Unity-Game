using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : InventoryItem
{

    private const int allSlots = 5;
    private int enabledSlots;
    private Sprite [] ItemSprites = new Sprite [allSlots];
    [SerializeField] GameObject reference;
    
    void Start()
    {
        enabledSlots = 0;
    }
    private void SelectWeapon(Weapon weapon)
    {
        Debug.Log(weapon.itemName);
        if (Camera.main.transform.childCount > 0)
        {
            GameObject obj = Camera.main.transform.GetChild(0).gameObject;
            obj.transform.parent = null;
            Destroy(obj);
        }
        GameObject Generated;
        Generated = Instantiate(weapon.Prefab);
        Generated.transform.parent = Camera.main.transform;
        Generated.transform.localPosition = weapon.Prefab.transform.position;
        Generated.transform.localEulerAngles = weapon.Prefab.transform.rotation.eulerAngles;
    }
    private void DisplayWeaponAndBullets(int index,Weapon weapon)
    {
        //Debug.Log("Suntem la indexul : " + index);
        GameObject slotImage = transform.GetChild(index * 2).GetChild(0).gameObject;
        GameObject slotBullets = transform.GetChild(index * 2 + 1).GetChild(0).gameObject;
        
        Image iconSprite = slotImage.GetComponent<Image>();
        iconSprite.sprite = weapon.itemSprite;
        Image iconBullets = slotBullets.GetComponent<Image>();
        iconBullets.sprite = weapon.bulletSprite;
    }

    public void AddItem(Weapon weapon)
    {
        if (weapon.itemSprite != null) {
            Sprite ceva = weapon.itemSprite;
            ItemSprites[enabledSlots] = ceva;
            DisplayWeaponAndBullets(enabledSlots, weapon);
            SelectWeapon(weapon);
            ++enabledSlots;
        }   
    }
}
