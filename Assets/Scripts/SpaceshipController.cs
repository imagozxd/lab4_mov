using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public InputController inputController;
    public float movementSpeed = 5f;

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
            Debug.Log("Disparando balas..."); // Aqu� podr�as llamar a la l�gica para instanciar una bala.
        }
    }
}
        
    
