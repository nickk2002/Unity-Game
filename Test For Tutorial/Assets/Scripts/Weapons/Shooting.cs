using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera fpsCamera;
    private float time;
    [SerializeField] float damage = 10.0f;
    [SerializeField] float range = 100.0f;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.57f);
    private float nextFire = 0.0f;
      
    private void Start()
    {
        fpsCamera = Camera.main;
    }
    private IEnumerator Shoot()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit))
        {
            
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("start waiting");
                yield return shotDuration;
                Debug.Log("not waiting");
            }
            
        }
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            StartCoroutine(Shoot());
            nextFire += Time.deltaTime;
        }
    }
}
