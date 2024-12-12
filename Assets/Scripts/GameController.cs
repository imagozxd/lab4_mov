using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform spawnPoint; 

    void Start()
    {
        ShipData selectedShip = GameManager.Instance.GetSelectedShip();

        if (selectedShip != null && spawnPoint != null)
        {
            GameObject newShip = Instantiate(selectedShip.shipPrefab, spawnPoint.position, Quaternion.Euler(0, 0, -90));

            Debug.Log("Nave en juego: " + selectedShip.shipName);
        }
        else
        {
            Debug.LogWarning(spawnPoint == null ? "No se ha asignado un punto de aparición en el Inspector." : "No se ha seleccionado ninguna nave.");
        }
    }
}

