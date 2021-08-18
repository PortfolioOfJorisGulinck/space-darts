using UnityEngine;

// Manages the reticle color
public class ReticleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject whiteDot;

    [SerializeField]
    private GameObject yellowDot;

    public void MakeReticleWhite()
    {
        whiteDot.SetActive(true);
        yellowDot.SetActive(false);
    }

    public void MakeReticleYellow()
    {
        whiteDot.SetActive(false);
        yellowDot.SetActive(true);
    }
}
