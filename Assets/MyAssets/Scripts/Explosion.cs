using UnityEngine;

// Manages the explosion of the planet when hit by the rocket
public class Explosion : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Rocket")
        {
            Explode();
            StateManager.Instance.TargetDestroyed = true;
        }
    }

    public void Explode()
    {
        gameObject.SetActive(false);
        explosion.SetActive(true);
        Debug.Log("Target exploded!");
    }
}
