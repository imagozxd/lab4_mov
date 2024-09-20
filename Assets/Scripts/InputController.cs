using UnityEngine;

public class InputController : MonoBehaviour
{
    private Gyroscope gyroscope;
    [SerializeField] private bool gyroEnabled;

    // Variables para manejar tap y double tap
    private float tapTimer = 0f;
    private float doubleTapMaxDelay = 0.3f;
    private int tapCount = 0;
    private Vector2 lastTapPosition; // Posición del último tap

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

    public Vector2 GetLastTapPosition()
    {
        return lastTapPosition;
    }

    public bool IsSingleTap()
    {
        return tapCount == 1 && tapTimer <= doubleTapMaxDelay;
    }
}
