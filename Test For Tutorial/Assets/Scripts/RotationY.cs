using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationY : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float rotationSpeed = 1;
    private float curentY;
    private float time = 0.0f;
    void Start()
    {
        ///Debug.Log("Rotation :" + transform.rotation.eulerAngles.x + " and " + transform.rotation.eulerAngles.z);
        curentY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion fromRotation = transform.localRotation, toRotaion = Quaternion.Euler(transform.rotation.eulerAngles.x, curentY, transform.rotation.eulerAngles.z);
        transform.localRotation = Quaternion.Slerp(fromRotation, toRotaion, time);
        curentY += rotationSpeed;
        time += Time.deltaTime;
    }
}
