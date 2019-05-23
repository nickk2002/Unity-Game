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
    public  float timeBetweenShots = .25f;
    public AudioClip musicClipShoot,musicClipHit;
    public AudioSource musicSource;

    private void Start()
    {
        fpsCamera = Camera.main;
        
    }
    private void Shoot()
    {

        RaycastHit hit;
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward,out hit,Mathf.Infinity))
        {  
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                
                Debug.Log("has hit");
                musicSource.clip = musicClipHit;
                musicSource.Play();
                enemy.TakeDamage(damage);
            }
        }
    }
    void Update()
    {
        
        nextFire += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && nextFire >= timeBetweenShots && Camera.main.transform.childCount > 0)
        {
            nextFire = 0.0f;
            musicSource.clip = musicClipShoot;
            musicSource.Play();
            Shoot();
        }
    }
}
