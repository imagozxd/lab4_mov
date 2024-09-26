using UnityEngine;
using UnityEngine.UI; // Necesario para usar Text

public class Canvas : MonoBehaviour
{
    public Text scoreText; 
    private float score = 0f; 

    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = "score : " + Mathf.FloorToInt(score).ToString();
    }
    public void SaveScore()
    {
        PlayerPrefs.SetFloat("score", score);
        PlayerPrefs.Save();
    }
}
