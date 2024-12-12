using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public GameObject meteoritePrefab;
    public int poolSize = 5;
    public float spawnInterval = 2f;
    public Transform playerTransform;
    public float yRange = 5f;

    private List<GameObject> meteoritePool;
    private float timer = 0f;
    private Vector2 spawnBounds;
    private int nextMeteoriteIndex = 0;
    private Dictionary<GameObject, Rigidbody2D> meteoriteRigidbodies;

    void Start()
    {
        meteoritePool = new List<GameObject>();
        meteoriteRigidbodies = new Dictionary<GameObject, Rigidbody2D>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject meteorite = Instantiate(meteoritePrefab);
            meteorite.SetActive(false);
            meteoritePool.Add(meteorite);
            meteoriteRigidbodies[meteorite] = meteorite.GetComponent<Rigidbody2D>();
        }

        spawnBounds = new Vector2(-yRange, yRange);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMeteorite();
            timer = 0f;
        }
    }

    void SpawnMeteorite()
    {
        GameObject meteorite = meteoritePool[nextMeteoriteIndex];
        nextMeteoriteIndex = (nextMeteoriteIndex + 1) % poolSize;

        if (!meteorite.activeInHierarchy)
        {
            meteorite.SetActive(true);
            meteorite.transform.position = new Vector3(3f, Random.Range(spawnBounds.x, spawnBounds.y), 0f);

            Vector2 direction = (playerTransform.position - meteorite.transform.position).normalized;
            meteoriteRigidbodies[meteorite].velocity = direction * 2f;
        }
    }

    public void ReturnToPool(GameObject meteorite)
    {
        meteorite.SetActive(false);
        meteoriteRigidbodies[meteorite].velocity = Vector2.zero;
    }
}



