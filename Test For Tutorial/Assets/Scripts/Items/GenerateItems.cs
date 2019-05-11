using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography; 

public class GenerateItems : MonoBehaviour
{
    [SerializeField] InventoryItem.ItemType type;
    [SerializeField] int itemAmount;
    [SerializeField] int minX, maxX, minZ, maxZ;
    [SerializeField] GameObject Prefab;
    public Transform[] PrefabTransform;
    int positionY;
    GameObject Generated, Refence;

    private int GetRandom(int left, int right)
    {
        if (right == left)
            return left;
        while (true)
        {
            RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider();
            byte[] gen = new byte[5];
            rg.GetBytes(gen);
            int value = BitConverter.ToInt32(gen, 0);

            int diff = right - left, remainder = Math.Abs(value % diff);
            if (value < right - remainder)
                return left + remainder;
        }
    }

    private void CreatePrefab()
    {
        Vector3 position = new Vector3(GetRandom(minX, maxX), positionY, GetRandom(minZ, maxZ));
        Generated = Instantiate(Prefab) as GameObject;
        Generated.transform.parent = this.transform;
        Generated.transform.localPosition = position;
        //Debug.Log("at Position : " + Generated.transform.localPosition);
        Generated.transform.rotation = Prefab.transform.rotation;
        //Debug.Log("Tatal : " + Generated.transform.parent);
        Generated.AddComponent<RotationY>();
        Generated.AddComponent<SphereCollider>();
        Generated.GetComponent<SphereCollider>().isTrigger = true;
        Generated.GetComponent<SphereCollider>().radius *= 3;
        Generated.AddComponent<InventoryItem>().itemtype = type;
        
    }
    void Start()
    {
        Refence = GameObject.Find("Where");
        PrefabTransform = new Transform[itemAmount];
        for (int i = 0; i < itemAmount; i++)
        {
            CreatePrefab();
            PrefabTransform[i] = Prefab.transform;
        }
    }
}
