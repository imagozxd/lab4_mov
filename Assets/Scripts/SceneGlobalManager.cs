using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGlobalManager : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "Select"; // Nombre de la escena a cargar de manera aditiva

    public void LoadAdditiveScene()
    {
        if (!IsSceneLoaded(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
            Debug.Log($"Escena {sceneToLoad} cargada de forma aditiva.");
        }
        else
        {
            Debug.Log($"La escena {sceneToLoad} ya está cargada.");
        }
    }

    private bool IsSceneLoaded(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName)
            {
                return true;
            }
        }
        return false; 
    }
}
