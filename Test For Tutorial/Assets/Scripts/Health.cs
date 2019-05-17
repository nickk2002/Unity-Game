using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 50.0f;
    public GameObject DeadScreen;

    public void TakeDamage(float amount)
    {
        Debug.Log("Current Health : " + health + "Damage taken : " + amount);
        health -= amount;
        if (health <= 0f)
        {
            if (gameObject == GameObject.Find("FPSController"))
            {
                DeadScreen.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
