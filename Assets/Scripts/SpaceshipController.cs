using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public InputController inputController;
    public float movementSpeed = 5f;

    //void Update()
    //{
    //    if (inputController.IsGyroEnabled())
    //    {
    //        // Obtener la rotaci�n del giroscopio
    //        Vector3 gyroRotation = inputController.GetGyroRotation();

    //        // Mover la nave en el eje Y basado en la rotaci�n del giroscopio
    //        float yMovement = gyroRotation.x * movementSpeed * Time.deltaTime;

    //        // tengo el sprite girado ptm 
    //        transform.Translate(yMovement, 0, 0);

    //    }
    //}
}
        
    
