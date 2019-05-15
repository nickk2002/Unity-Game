using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {
    public enum ItemType
    {
        Pistol,
        AK47,
        UMP45,
        M4A1
    }

    [Header("Values")]
    public ItemType itemtype;
    [SerializeField] int itemAmount;
    [SerializeField] GameObject Prefab;
    public Transform[] PrefabTransform;
    int positionY;

    public ItemType Type { set { itemtype = value; } get { return itemtype; } }
    public int Amount { get { return itemAmount; } }

    void Update()
    {

    }
}
