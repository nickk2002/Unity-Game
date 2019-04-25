using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class GameCamera : MonoBehaviour
{

    [SerializeField] GameObject target;
    [SerializeField] Vector3 translationoffset;
    [SerializeField] Vector3 followoffset;
    void Start()
    {
        translationoffset = target.transform.position - transform.position;
        //followoffset = Vector3.Scale(followoffset, new Vector3(1,0,1)).normalized;
    }
    void Update()
    {
    }
    void FixedUpdate()
    {
        transform.position = target.transform.position - followoffset;
        transform.LookAt(target.transform.position + translationoffset);
    }
}
