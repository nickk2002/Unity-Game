using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIdamage : MonoBehaviour
{
    public GameObject player;
    public float maximumDistance;
    public float botDamage;
    public float damageTime = 1.0f;
    public float nextDamage = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if(player != null && Vector3.Distance(transform.position,player.transform.position) <= maximumDistance)
        {
            nextDamage += Time.deltaTime;
            if (nextDamage > damageTime)
            {
                Debug.Log("min distance reached");
                Health health = player.GetComponent<Health>();
                if (health)
                    health.TakeDamage(botDamage);
                nextDamage = 0;
            }
        }
        
    }
}
