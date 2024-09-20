using UnityEngine;
using UnityEngine.UI; // Necesario para usar Text

public class Canvas : MonoBehaviour
{
    public Text scoreText; // Variable pública para el Text UI
    private float score = 0f; // Variable para el score

    void Update()
    {
        // Incrementar el score en base al tiempo transcurrido (Time.deltaTime)
        score += Time.deltaTime;

        // Actualizar el texto del score redondeando el valor
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }
}
