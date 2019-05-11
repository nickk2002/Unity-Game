using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera fpsCamera;
    private float time;
    [SerializeField] float damage = 10.0f;
    [SerializeField] float range = 100.0f;
    private float nextFire;
      
    private void Start()
    {
        fpsCamera = Camera.main;
    }
    private void Shoot()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit,range))
        {
            
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
                ///lastShot = System.DateTime.Now;
            }
            
        }
    }
    void Update()
    {
        float timeBetweenShots = .5f;
        nextFire += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && nextFire >= timeBetweenShots)
        {
            nextFire = 0.0f;
            Shoot();
        }
    }
}
