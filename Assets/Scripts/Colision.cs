using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    private int meteoritesDestroyed = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            meteoritesDestroyed++;

            Destroy(gameObject);

            Destroy(collision.gameObject);

            Debug.Log("Meteoritos destruidos: " + meteoritesDestroyed);
        }
    }

    public int GetMeteoritesDestroyed()
    {
        return meteoritesDestroyed;
    }
}
