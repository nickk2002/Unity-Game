using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography; 

public class GenerateItems : MonoBehaviour
{
    [SerializeField] InventoryItem.ItemType type;
    [SerializeField] GameObject Prefab;
    //int positionY;


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

    private IEnumerator CreatePrefab(Transform chilTransform)
    {
        Vector3 positionObj = chilTransform.position;
        Destroy(chilTransform.gameObject);
        GameObject Generated = Instantiate(Prefab) as GameObject;
        Generated.transform.position = positionObj;
        Generated.transform.rotation = Prefab.transform.rotation;
        yield return new WaitForSeconds(0.01f);
        Generated.transform.SetParent(this.transform);

        if (Generated.GetComponent<RotationY>() != null)
        {
            Generated.AddComponent<SphereCollider>();
            Generated.GetComponent<SphereCollider>().isTrigger = true;
            Generated.GetComponent<SphereCollider>().radius *= 5;
            Generated.AddComponent<InventoryItem>().itemtype = type;
            Generated.AddComponent<Rigidbody>();
            Generated.GetComponent<Rigidbody>().useGravity = false;
        }

    }
    void Start()
    {
        Transform initialTranfrom = this.transform;
        foreach(Transform child in initialTranfrom)
        {
            StartCoroutine(CreatePrefab(child));
        }
    }
}
