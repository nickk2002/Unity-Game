using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{   
    public enum ItemType
    {
        Pistol,
        AK47
    }
    [Header("Values")]
    [SerializeField] ItemType itemtype;
    [SerializeField] int itemAmount;

    [Header("Visuals")]
    private GameObject floatingObject;
    private float curentyRotation = 0.0f,initialY,curentY;
    [SerializeField] float rotationSpeed,updownSpeed,maxDist;
    private int clipAmmunition = 0;

    public ItemType Type { get { return itemtype; } }
    public int Amount { get { return itemAmount; } }


    void Start()
    {
        floatingObject = transform.GetChild(0).gameObject;
        initialY = floatingObject.transform.position.y;
        curentY = initialY;
    }
    void Update()
    {
        if (floatingObject == null)
            return;
        if (Mathf.Abs(curentY - initialY) >= maxDist)
            updownSpeed = -updownSpeed;
        floatingObject.transform.position = new Vector3(floatingObject.transform.position.x, curentY, floatingObject.transform.position.z);
        floatingObject.transform.rotation = Quaternion.Euler(floatingObject.transform.rotation.x, curentyRotation, floatingObject.transform.rotation.z);
        curentyRotation = curentyRotation + rotationSpeed * Time.deltaTime;
        curentY += updownSpeed * Time.deltaTime;
    }

}
