using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private ShipData selectedShip;

    private void Awake()
    {
        // Hacer que el GameManager sea un Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para asignar la nave seleccionada
    public void SetSelectedShip(ShipData ship)
    {
        selectedShip = ship;
        Debug.Log("Nave seleccionada en GameManager: " + selectedShip.shipName);
    }

    // Método para obtener la nave seleccionada en la siguiente escena
    public ShipData GetSelectedShip()
    {
        return selectedShip;
    }
}
