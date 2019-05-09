using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;

public class ItemBoxes : MonoBehaviour
{   
    public enum ItemType
    {
        Pistol,
        AK47,
        UMP45,
        M4A1
    }

    [Header("Values")]
    [SerializeField] ItemType itemtype;
    [SerializeField] int itemAmount;
    [SerializeField] int minX,maxX,minZ,maxZ;
    [SerializeField] GameObject Prefab;
    public Transform[] PrefabTransform;
    private float positionY = 1.593f;
    GameObject Generated;

    public ItemType Type { get { return itemtype; } }
    public int Amount { get { return itemAmount; } }


    private int GetRandom(int left,int right)
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
        Generated = Instantiate(Prefab, position, Prefab.transform.rotation);
        Generated.transform.parent = this.transform;
        //Debug.Log("Tatal : " + Generated.transform.parent);
        Generated.AddComponent<RotationY>();
        Generated.AddComponent<BoxCollider>();
        Generated.GetComponent<BoxCollider>().isTrigger = true;
    }
    void Start()
    {
        PrefabTransform = new Transform[itemAmount];
        for(int i = 0; i < itemAmount; i++)
        {
            CreatePrefab();
            PrefabTransform[i] = Prefab.transform;
        }
    }
    void Update()
    {

    }
}
