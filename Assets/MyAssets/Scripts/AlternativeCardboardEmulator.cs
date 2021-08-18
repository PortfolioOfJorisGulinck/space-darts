using UnityEngine;

// Alternative simulation of the headmovement with the right mouse btn
public class AlternativeCardboardEmulator : MonoBehaviour
{
    private const float MOUSE_SENSITIVITY_X = 5.0f;
    private const float MOUSE_SENSITIVITY_Y = 5.0f;
    private float rotationY = 0.0f;

    [SerializeField]
    private float speedNormal = 10.0f;

    [SerializeField]
    private float speedFast = 50.0f;

    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    void Update()
    {
        // rotation when the right mouse btn is pressed       
        if (Input.GetMouseButton(1))
        {
            float rotX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * MOUSE_SENSITIVITY_X;
            rotationY += Input.GetAxis("Mouse Y") * MOUSE_SENSITIVITY_Y;
            rotationY = Mathf.Clamp(rotationY, -89.5f, 89.5f);
            transform.localEulerAngles = new Vector3(-rotationY, rotX, 0.0f);
        }
    }
}
