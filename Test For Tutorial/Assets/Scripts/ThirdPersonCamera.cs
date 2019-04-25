using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ThirdPersonCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform PlayerPosition;
    private Vector3 PlayerVec;

    void Start()
    {
        if (Camera.main != null) {
            PlayerPosition = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("Main Camera not found!");
            PlayerVec = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        this.transform.position = PlayerPosition.position;
        Debug.Log(PlayerPosition.position);
    }
}
