using UnityEngine;

// Calculates the attraction force of the planets 
public class Attractor : MonoBehaviour
{
    // Gravitational constant
    const float G = 0.6674f;

    private Rigidbody rbOfPlanet;

    [SerializeField]
    private Rigidbody rocket;

    private void Start()
    {
        rbOfPlanet = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!StateManager.Instance.TargetDestroyed)
        {
            Attract(rocket);
        }
    }

    void Attract(Rigidbody rbOfRocket)
    {
        // Calculates the direction of the rocket 
        // D = vect Planet - vect Rocket
        // D = (Px - Rx, Py - Ry, Pz - Rz)
        Vector3 direction = rbOfPlanet.position - rbOfRocket.position;

        // Calculates the distance of the rocket 
        // d = ||vect Planet - vect Rocket||
        // d = Wortel(Dx² + Dy² + Dz²)
        float distance = direction.magnitude;

        // Formula: F = ((m1 * m2) / d²) * G
        float forceMagnitude = (rbOfPlanet.mass * rbOfRocket.mass) / Mathf.Pow(distance, 2) * G;

        // Calculates the attraction force and directon
        // vector norm = vector / ||vector|| = vector met magnitude 1
        Vector3 force = direction.normalized * forceMagnitude;

        rbOfRocket.AddForce(force);
    }
}
