using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public GameObject meteoritePrefab;  // Prefab del meteorito
    public int poolSize = 5;            // Tamaño máximo del pool
    public float spawnInterval = 2f;    // Intervalo de tiempo para spawnear meteoritos
    public Transform playerTransform;   // Referencia al jugador para dirección contraria
    public float yRange = 5f;           // Límite superior e inferior en el eje Y para el spawn

    private List<GameObject> meteoritePool;  // Pool de meteoritos
    private float timer = 0f;                // Temporizador para generar meteoritos
    private Vector2 spawnBounds;             // Rango de spawn en el eje Y

    void Start()
    {
        // Inicializa el pool de meteoritos
        meteoritePool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject meteorite = Instantiate(meteoritePrefab);
            meteorite.SetActive(false);
            meteoritePool.Add(meteorite);
        }

        // Establece los límites de spawn en Y
        spawnBounds = new Vector2(-yRange, yRange);
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Si ha pasado el tiempo del intervalo de spawn, genera un nuevo meteorito
        if (timer >= spawnInterval)
        {
            SpawnMeteorite();
            timer = 0f; // Reinicia el temporizador
        }
    }

    void SpawnMeteorite()
    {
        // Buscar un meteorito inactivo en el pool
        for (int i = 0; i < meteoritePool.Count; i++)
        {
            if (!meteoritePool[i].activeInHierarchy)
            {
                // Activar el meteorito y colocarlo en una posición aleatoria en Y
                meteoritePool[i].SetActive(true);
                meteoritePool[i].transform.position = new Vector3(3f, Random.Range(spawnBounds.x, spawnBounds.y), 0f);

                // Establecer dirección hacia la izquierda, contraria al jugador
                Vector2 direction = (playerTransform.position - meteoritePool[i].transform.position).normalized;
                meteoritePool[i].GetComponent<Rigidbody2D>().velocity = direction * 2f;

                break; // Sale del bucle después de activar un meteorito
            }
        }
    }

    // Método para desactivar el meteorito y devolverlo al pool
    public void ReturnToPool(GameObject meteorite)
    {
        meteorite.SetActive(false);
        meteorite.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}


