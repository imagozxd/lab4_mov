using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public int initialPoolSize = 10; // Tamaño inicial del pool
    public int maxInactiveBullets = 10; // Máximo de balas inactivas permitidas
    private List<GameObject> bullets; // Lista de balas disponibles

    void Awake()
    {
        bullets = new List<GameObject>();

        // Crear el pool inicial de balas
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateBullet();
        }
    }

    private GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false); // Desactivar la bala al instanciarla
        bullets.Add(bullet);
        return bullet;
    }

    public GameObject GetBullet()
    {
        // Buscar una bala inactiva
        foreach (var bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        // Si no hay balas inactivas, crear una nueva
        return CreateBullet();
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false); // Desactivar la bala y devolverla al pool
        CheckInactiveBullets(); // Verificar si se debe eliminar balas inactivas
    }

    private void CheckInactiveBullets()
    {
        int inactiveCount = 0;

        // Contar balas inactivas
        foreach (var bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                inactiveCount++;
            }
        }

        // Si el número de balas inactivas excede el límite, destruir las extras
        if (inactiveCount > maxInactiveBullets)
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    Destroy(bullets[i]); // Destruir la bala inactiva
                    bullets.RemoveAt(i); // Eliminarla de la lista
                }

                // Salir si ya se han eliminado suficientes balas
                if (bullets.Count - inactiveCount <= maxInactiveBullets)
                    break;
            }
        }
    }
}
