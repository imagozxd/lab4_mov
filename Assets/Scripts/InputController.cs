using UnityEngine;

public class InputController : MonoBehaviour
{
    private Gyroscope gyroscope;
    public bool gyroEnabled;

    // Variables para manejar tap, double tap y hold
    private float tapTimer = 0f;
    private float doubleTapMaxDelay = 0.3f;
    private int tapCount = 0;
    private Vector2 lastTapPosition; // Posición del último tap
    private float holdThreshold = 0.5f; // Duración mínima para considerar un hold
    private bool isHolding = false; // Si el usuario está haciendo un hold
    private float holdTimer = 0f; // Contador para el tiempo de hold

    void Start()
    {
        gyroEnabled = EnableGyroscope();
    }

    private bool EnableGyroscope()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
            return true;
        }
        else
        {
            Debug.LogWarning("El dispositivo no soporta giroscopio.");
            return false;
        }
    }

    void Update()
    {
        DetectTouchInput();
        HandleTapDoubleTap();
        HandleHold();
    }

    // Detectar el input de toques
    private void DetectTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                tapCount++;
                lastTapPosition = touch.position; // Guardar la posición del toque
                holdTimer = 0f; // Reiniciar el contador de hold
                isHolding = false; // Reiniciar el estado de hold
            }
            else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                holdTimer += Time.deltaTime;
                if (holdTimer >= holdThreshold)
                {
                    isHolding = true;
                    Debug.Log("Hold detectado.");
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isHolding = false;
            }
        }
    }

    private void HandleTapDoubleTap()
    {
        if (tapCount == 1)
        {
            tapTimer += Time.deltaTime;

            if (tapTimer > doubleTapMaxDelay)
            {
                Debug.Log("Tap detectado en la posición: " + lastTapPosition);
                tapCount = 0;
                tapTimer = 0f;
            }
        }
        else if (tapCount == 2)
        {
            Debug.Log("Double Tap detectado.");
            tapCount = 0;
            tapTimer = 0f;
        }

        if (tapCount > 0)
        {
            tapTimer += Time.deltaTime;
            if (tapTimer > doubleTapMaxDelay)
            {
                tapCount = 0;
                tapTimer = 0f;
            }
        }
    }

    private void HandleHold()
    {
        if (isHolding)
        {
            Debug.Log("Hold activo.");
        }
    }

    public Vector2 GetLastTapPosition()
    {
        return lastTapPosition;
    }

    public bool IsSingleTap()
    {
        return tapCount == 1 && tapTimer <= doubleTapMaxDelay;
    }

    public bool IsHolding()
    {
        return isHolding;
    }
    public Vector3 GetGyroRotation()
    {
        return gyroscope.rotationRateUnbiased;
    }
}
