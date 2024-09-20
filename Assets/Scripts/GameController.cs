using UnityEngine;

public class GameController : MonoBehaviour
{
    void Start()
    {
        ShipData selectedShip = GameManager.Instance.GetSelectedShip();

        // Instanciar la nave seleccionada en el juego
        if (selectedShip != null)
        {
            Instantiate(selectedShip.shipPrefab, Vector3.zero, Quaternion.identity);
            Debug.Log("Nave en juego: " + selectedShip.shipName);
        }
        else
        {
            Debug.LogWarning("No se ha seleccionado ninguna nave.");
        }
    }
}
