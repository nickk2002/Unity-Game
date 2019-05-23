using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform m_Camera;
    private Vector3 m_CameraForward;
    private bool m_Jump;
    void Start()
    {
        if(Camera.main != null)
        {
            m_Camera = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("ThirdPersonCamera Script cannot find the Main Camera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Jump)
            m_Jump = Input.GetButtonDown("Jump");
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        m_CameraForward = Vector3.Scale(m_CameraForward, new Vector3(1, 0, 1)).normalized;
    }
}
