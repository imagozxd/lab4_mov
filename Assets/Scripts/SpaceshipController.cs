using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public InputController inputController;
    public float movementSpeed = 5f;

    void Update()
    {
        // Verificar si el giroscopio está habilitado
        if (inputController.gyroEnabled)
        {
            // Obtener la rotación del giroscopio
            Vector3 gyroRotation = inputController.GetGyroRotation();

            // Mover la nave en el eje Y basado en la rotación del giroscopio
            float yMovement = gyroRotation.x * movementSpeed * Time.deltaTime;

            // Mover la nave (considerando que el sprite está girado)
            transform.Translate(yMovement, 0, 0);
        }

        // Detectar si el usuario está haciendo un hold para disparar
        if (inputController.IsHolding())
        {
            Debug.Log("Disparando balas..."); // Aquí podrías llamar a la lógica para instanciar una bala.
        }
    }
}
        
    
