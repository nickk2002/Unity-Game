using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50.0f;

    public void TakeDamage(float amount)
    {
        Debug.Log("Current Health : " + health + "Damage taken : " + amount);
        health -= amount;
        if(health <= 0f)
            Destroy(gameObject);
    }
}
