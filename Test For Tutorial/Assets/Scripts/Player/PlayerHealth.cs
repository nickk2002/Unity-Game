using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float health = 50.0f;
    public TextMeshProUGUI healthPanel;

    private void Start()
    {
        
    }
    private void Update()
    {
        healthPanel.text = "Health : " + health;   
    }
    public void TakeDamage(float amount)
    {
        Debug.Log("Current Health : " + health + "Damage taken : " + amount);
        health -= amount;
        if (health <= 0f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
