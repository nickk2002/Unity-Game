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
            Debug.Log("CliCked : " + this.gameObject);
            inventory.AddItem(this.gameObject);
        }
    }
}
