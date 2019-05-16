using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject crosshair;
    void Start()
    {
        crosshair.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.childCount > 0)
        {
            crosshair.gameObject.SetActive(true);
        }
    }
}
