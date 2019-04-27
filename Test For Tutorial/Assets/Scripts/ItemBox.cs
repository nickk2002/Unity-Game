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

    [Header("Visuals")]
    private GameObject floatingObject;
    private float curentyRotation = 0.0f,x,z;
    [SerializeField] float rotationSpeed,updownSpeed = 1,maxDist;

    public ItemType Type { get { return itemtype; } }
    public int Amount { get { return itemAmount; } }


    void Start()
    {
        
    }
    void LateUpdate()
    {
        foreach (Transform child in transform)
        {
            floatingObject = child.gameObject;
            if (floatingObject == null)
                return;
            /*if (Mathf.Abs(curentY - initialY) >= maxDist)
                updownSpeed = -updownSpeed;
            floatingObject.transform.rotation * new Vector3(0, curentY, 0) * Time.deltaTime*/
            floatingObject.transform.localRotation = Quaternion.Euler(0, curentyRotation * Time.deltaTime,transform.localRotation.z);
            Debug.Log(floatingObject.transform.rotation);
            curentyRotation = curentyRotation + rotationSpeed;
        }
    }


}
