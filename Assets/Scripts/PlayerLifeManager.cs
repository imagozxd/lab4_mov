using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerLifeManager : MonoBehaviour
{
    public ShipData ship;       // Informaci�n del barco, como la vida m�xima y el nombre
    public int currentHealth;   // Vida actual del jugador
    public TextMeshPro healthText;     // Referencia al componente Text que mostrar� la vida

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = ship.health;
        UpdateHealthText();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthText();            

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // M�todo para curar
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > ship.health)
        {
            currentHealth = ship.health;
        }

        UpdateHealthText();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void Die()
    {
        Debug.Log(ship.shipName + " ha sido destruido!");
        gameObject.SetActive(false); 
    }

    // M�todo para actualizar el texto de la vida
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth + " / " + ship.health;
        }
    }
}
