using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickItem : MonoBehaviour
{
    private RightInventory inventory;
    

    private void Start()
    {
        inventory = GameObject.Find("Weapons").GetComponent<RightInventory>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inventory.AddItem(this.gameObject);
        }
    }
}
