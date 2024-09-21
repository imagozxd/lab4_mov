using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public InputController inputController;
    public BulletPool bulletPool; // Referencia al BulletPool
    public float movementSpeed = 5f;
    public float bulletSpeed = 10f; // Velocidad de la bala

    void Update()
    {
        // Verificar si el giroscopio est� habilitado
        if (inputController.gyroEnabled)
        {
            // Obtener la rotaci�n del giroscopio
            Vector3 gyroRotation = inputController.GetGyroRotation();

            // Mover la nave en el eje Y basado en la rotaci�n del giroscopio
            float yMovement = gyroRotation.x * movementSpeed * Time.deltaTime;

            // Mover la nave (considerando que el sprite est� girado)
            transform.Translate(yMovement, 0, 0);
        }

        // Detectar si el usuario est� haciendo un hold para disparar
        if (inputController.IsHolding())
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject bullet = bulletPool.GetBullet(); // Obtener una bala del pool
        if (bullet != null)
        {
            bullet.transform.position = transform.position; // Colocar la bala en la posici�n de la nave
            bullet.transform.rotation = Quaternion.identity; // Resetear rotaci�n si es necesario
            bullet.SetActive(true); // Activar la bala

            // A�adir l�gica para mover la bala
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * bulletSpeed; // Suponiendo que la nave mira hacia arriba
            }

            Debug.Log("Bala disparada.");
        }
    }
}
        
    
