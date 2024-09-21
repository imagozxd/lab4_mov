using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f; // Tiempo de vida de la bala
    private float timer;

    void OnEnable()
    {
        timer = 0f; // Reiniciar el temporizador al activar la bala
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            DeactivateBullet();
        }
    }

    private void DeactivateBullet()
    {
        // Devolver la bala al pool
        BulletPool bulletPool = FindObjectOfType<BulletPool>();
        if (bulletPool != null)
        {
            bulletPool.ReturnBullet(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Desactivar la bala al colisionar con algo
        DeactivateBullet();
    }
}
