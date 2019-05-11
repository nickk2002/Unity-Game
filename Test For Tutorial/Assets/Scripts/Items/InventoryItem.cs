using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {
    protected Sprite imageInventory;///image for the pick up panel
    protected string itemName;///name displayed

    private void Start()
    {
        imageInventory = Resources.Load<Sprite>("/Items" + itemName);
    }
}
