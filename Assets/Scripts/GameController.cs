using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform spawnPoint; // Referencia al Transform en el Inspector
    void Start()
    {
        ShipData selectedShip = GameManager.Instance.GetSelectedShip();

        // Instanciar la nave seleccionada en el juego
        if (selectedShip != null && spawnPoint != null)
        {
            // Instanciar la nave en la posición y rotación del Transform del Inspector
            GameObject NewShip = Instantiate(selectedShip.shipPrefab, spawnPoint.position, Quaternion.identity);
            NewShip.transform.rotation = Quaternion.Euler(0, 0, -90);

            Debug.Log("Nave en juego: " + selectedShip.shipName);
        }
        else if (spawnPoint == null)
        {
            Debug.LogWarning("No se ha asignado un punto de aparición en el Inspector.");
        }
        else
        {
            Debug.LogWarning("No se ha seleccionado ninguna nave.");
        }
    }
}
