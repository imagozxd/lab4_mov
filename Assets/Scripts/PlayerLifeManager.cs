using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerLifeManager : MonoBehaviour
{
    public ShipData ship;
    public int currentHealth;
    public TextMeshPro healthText; 
    public GameObject deathScreen;
    public Text Score;
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

    // Método para curar
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
        Canvas score = FindObjectOfType<Canvas>();
        if(score != null)
        {
            score.SaveScore();
        }
        Time.timeScale = 0.0f;

        deathScreen.SetActive(true);
        int roundedScore = Mathf.FloorToInt(PlayerPrefs.GetFloat("score"));
        Score.text = "SCORE: " + roundedScore.ToString();
    }

    // Método para actualizar el texto de la vida
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth + " / " + ship.health;
        }
    }
}
