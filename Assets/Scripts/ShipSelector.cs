using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipSelector : MonoBehaviour
{
    public ShipData[] availableShips;  // Array de naves disponibles
    private ShipData selectedShip;     // Nave seleccionada

    // Referencias a los botones de las naves
    public Button buttonNave1;
    public Button buttonNave2;
    public Button buttonNave3;
    public Button startButton;

    void Start()
    {
        // Asignar eventos a los botones
        buttonNave1.onClick.AddListener(() => SelectShip(0));  // Selecciona nave1
        buttonNave2.onClick.AddListener(() => SelectShip(1));  // Selecciona nave2
        buttonNave3.onClick.AddListener(() => SelectShip(2));  // Selecciona nave3

        // Selecciona la primera nave por defecto
        selectedShip = availableShips[0];
        startButton.onClick.AddListener(StartGame);
    }

    // Método para seleccionar la nave por índice
    public void SelectShip(int index)
    {
        if (index >= 0 && index < availableShips.Length)
        {
            selectedShip = availableShips[index];
            Debug.Log("Nave seleccionada: " + selectedShip.shipName);
        }
        else
        {
            Debug.LogError("Índice de nave no válido.");
        }
    }
    public void StartGame()
    {
        Debug.Log("StartGame called");
        if (selectedShip != null)
        {
            GameManager.Instance.SetSelectedShip(selectedShip);
            SceneManager.LoadScene("GameScene");  // Carga la escena del juego
            Debug.Log("nave creada?");
        }
        else
        {
            Debug.LogError("No se ha seleccionado ninguna nave.");
        }
    }

}
