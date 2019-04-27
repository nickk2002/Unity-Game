using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemBox : MonoBehaviour
{   
    public enum ItemType
    {
        Pistol,
        AK47,
        UMP45
    }
    [Header("Values")]
    [SerializeField] ItemType itemtype;
    [SerializeField] int itemAmount;
    [SerializeField] GameObject Prefab;
    [SerializeField] Transform[] PrefabTransform;
    public ItemType Type { get { return itemtype; } }
    public int Amount { get { return itemAmount; } }


    void Start()
    {
        for(int i = 0; i < itemAmount; i++)
        {   
            Instantiate(Prefab,PrefabTransform[i].position, PrefabTransform[i].rotation);
            Prefab.transform.SetParent(transform);
            Prefab.gameObject.AddComponent<RotationY>();
        }
    }
    void Update()
    {

    }
}
