using UnityEngine;

[CreateAssetMenu(fileName = "NewShipData", menuName = "Spaceship/ShipData")]
public class ShipData : ScriptableObject
{
    public string shipName;          // Nombre de la nave
    public Sprite shipImage;         // Imagen de la nave para el menú de selección
    public GameObject bulletPrefab;  // Prefab de la bala
    public GameObject shipPrefab;    // Prefab de la nave

    public float speed;              // Velocidad de la nave
    public int health;               // Vida de la nave
}
