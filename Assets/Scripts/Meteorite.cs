using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    private MeteoriteSpawner meteoriteSpawner;
    private BulletPool bulletPool;

    void Start()
    {
        meteoriteSpawner = FindObjectOfType<MeteoriteSpawner>();
        bulletPool = FindObjectOfType<BulletPool>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            bulletPool.ReturnBullet(other.gameObject);
            meteoriteSpawner.ReturnToPool(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            meteoriteSpawner.ReturnToPool(gameObject);
            other.gameObject.GetComponent<PlayerLifeManager>().TakeDamage(1);
        }
    }

    void Update()
    {
        if (transform.position.x < -3f)
        {
            meteoriteSpawner.ReturnToPool(gameObject);
        }
    }
}



