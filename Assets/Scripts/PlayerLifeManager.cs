using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLifeManager : MonoBehaviour
{
    public ShipData ship;     
    public int currentHealth;  
    public TextMeshProUGUI healthText; 

    void Start()
    {
        currentHealth = ship.health;
        UpdateHealthText();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth = Mathf.Max(currentHealth - damageAmount, 0);
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, ship.health);
        UpdateHealthText();
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    private void Die()
    {
        Debug.Log($"{ship.shipName} ha sido destruido!");
        gameObject.SetActive(false);
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = $"{currentHealth} / {ship.health}";
        }
    }
}
