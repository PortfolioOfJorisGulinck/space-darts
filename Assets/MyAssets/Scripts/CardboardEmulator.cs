using UnityEngine;

// Emulates the head movements of the VR device 
public class CardboardEmulator : MonoBehaviour
{
    // INSTRUCTIONS:
    // alt move mouse: yaw (rond y-as) / pitch (rond x-as)
    // ctrl move mouse: roll (rond z-as)

    private const float HEAD_MOVEMENT_FORCE = 500;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Vector3 rotation = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            Camera.main.transform.Rotate(rotation * HEAD_MOVEMENT_FORCE * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            Vector3 rotation = new Vector3(0, 0, Input.GetAxis("Mouse X"));
            Camera.main.transform.Rotate(rotation * HEAD_MOVEMENT_FORCE * Time.deltaTime);
        }
        else
        {
            Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 0);
        }
    }
}
