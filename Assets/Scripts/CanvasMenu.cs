using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenu : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private SceneGlobalManager sceneManager; // Referencia al SceneGlobalManager

    void Start()
    {
        startGameButton.onClick.AddListener(() => StartGame());

        quitButton.onClick.AddListener(() => QuitGame());
    }

    void StartGame()
    {
        sceneManager.LoadAdditiveScene();
    }

    void QuitGame()
    {
        Application.Quit();

    }
}
