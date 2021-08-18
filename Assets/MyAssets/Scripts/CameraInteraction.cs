using UnityEngine;
using UnityEngine.UI;

// Manages the interaction between the camera and the objects in de the game
public class CameraInteraction : MonoBehaviour
{
    [SerializeField]
    private int uiDistance = 100000;

    private ReticleManager reticleManager;
    private GameObject lookAtButton = null;

    void Start()
    {
        reticleManager = GameObject.Find("Reticle").GetComponent<ReticleManager>();
    }

    void Update()
    {
        CheckingUIObject();
        CheckingTargetObject();
    }

    private void CheckingUIObject()
    {
        RaycastHit hit;
        int layerMask = 1 << 5; //UI Mask
        if (Physics.Raycast(transform.position, transform.forward, out hit, uiDistance, layerMask))
        {
            Debug.Log("CameraUIInteraction: UI object hit!");
            reticleManager.MakeReticleYellow();
            lookAtButton = hit.transform.gameObject;
        }
        else
        {
            lookAtButton = null;
            reticleManager.MakeReticleWhite();
        }

        if (lookAtButton != null && (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetKey(KeyCode.Space)))
        {
            Debug.Log("CameraUIInteraction: Button clicked");
            lookAtButton.GetComponent<Button>().onClick.Invoke();
        }
    }

    private void CheckingTargetObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, uiDistance))
        {
            if (hit.transform.gameObject.tag.Equals("Target"))
            {
                Debug.Log("CameraUIInteraction: Target object hit!");
                reticleManager.MakeReticleYellow();
            }
        }
        else
        {
            reticleManager.MakeReticleWhite();
        }
    }
}
