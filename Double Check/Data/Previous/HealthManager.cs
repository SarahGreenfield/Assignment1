using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image healthBar; // Reference to the UI health bar image
    public float maxHP; // Maximum health points
    public float currentHealth = 100f; // Current health, starting at 100
    
    void Start()
    {
        maxHP = currentHealth; // Set max HP to initial current health
    }

    void Update()
    {
        // Update health bar fill amount, clamped between 0 and 1
        healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHP, 0, 1);

        // Check if player has died
        if (currentHealth <= 0)
        {
            // Reload the game scene (assuming scene index 1 is the game scene)
            SceneManager.LoadSceneAsync(1);
        }
    }

    /// <summary>
    /// Damage the player by the specified amount
    /// </summary>
    /// <param name="damage">Amount of damage to deal</param>
    public void Damage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Max(currentHealth, 0); // Ensure health doesn't go below 0
        }
    }

    /// <summary>
    /// Get the current health of the player
    /// </summary>
    /// <returns>Current health value</returns>
    public float GetHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Set the health of the player to a specific value
    /// </summary>
    /// <param name="health">New health value</param>
    public void SetHealth(float health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHP);
        healthBar.fillAmount = currentHealth / maxHP;
    }
}