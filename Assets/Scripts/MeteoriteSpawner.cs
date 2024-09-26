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

    void Start()
    {

        meteoritePool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject meteorite = Instantiate(meteoritePrefab);
            meteorite.SetActive(false);
            meteoritePool.Add(meteorite);
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

        for (int i = 0; i < meteoritePool.Count; i++)
        {
            if (!meteoritePool[i].activeInHierarchy)
            {
                meteoritePool[i].SetActive(true);
                meteoritePool[i].transform.position = new Vector3(3f, Random.Range(spawnBounds.x, spawnBounds.y), 0f);

                Vector2 direction = (playerTransform.position - meteoritePool[i].transform.position).normalized;
                meteoritePool[i].GetComponent<Rigidbody2D>().velocity = direction * 2f;

                break; 
            }
        }
    }
    public void ReturnToPool(GameObject meteorite)
    {
        meteorite.SetActive(false);
        meteorite.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}


