using UnityEngine;

// Manages the rocket
public class RocketManager : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameCanvasManager gameCanvas;

    private const float MAX_SPEED = 200f;
    private const float MAX_GAZE_TIME = 5f;
    private float speed = 0f;
    private GameObject target;

    private bool rocketLaunched;
    private bool lockOnStatus;
    private float lockOnTimer;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
    }

    void Update()
    {
        LockOnTargetWithRayCast();

        if (lockOnStatus && !rocketLaunched)
        {
            // start timing the gazetime and show it on the speedslider
            if (lockOnTimer > MAX_GAZE_TIME)
            {
                lockOnTimer = 0f;
            }
            else
            {
                lockOnTimer += Time.deltaTime;
            }
            gameCanvas.ShowSpeed(lockOnTimer / MAX_GAZE_TIME);
        }

        if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetKey(KeyCode.Space))
        {
            // Spacebar down or Google trigger pressed, start launching!
            CalculateRocketSpeed(lockOnTimer);
            rocketLaunched = true;
            Debug.Log("Rocket launched!");
        }

        // Move our position a step closer to the target every frame
        if (rocketLaunched && target != null)
        {
            Launch(target.transform);

            // Shows the speed that was given during launch
            gameCanvas.ShowLockedOnTargetText();
            gameCanvas.ShowSpeed(speed / MAX_SPEED);
        }
    }

    private void Launch(Transform target)
    {
        // Calculate distance to move
        float step = speed * Time.deltaTime;

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    // Checks if the collision is with a coin or a target
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Coin"))
        {
            gameManager.CoinCollected(other.gameObject);
            Debug.Log("Coin hit!");
        }

        if (other.tag.Equals("Target"))
        {
            rocketLaunched = false;
            gameManager.TargetHit();
            Debug.Log("Target hit!");

            // stops the rocket from attracting towarts other planets
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Checks if the camera/reticle hits the target
    private void LockOnTargetWithRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.Log("RocketManager: Hit something!");
            
            if (hit.transform.gameObject.tag.Equals("Target"))
            {
                Debug.Log("RocketManager: Target object hit!");

                target = hit.transform.gameObject;
                LockTarget();
            }
        }
        else
        {
            UnLockTarget();
        }
    }

    private void CalculateRocketSpeed(float holdTime)
    {
        float holdTimeNormalized = holdTime / MAX_GAZE_TIME;
        speed =  holdTimeNormalized * MAX_SPEED;
    }


    private void LockTarget()
    {
        lockOnStatus = true;
        gameCanvas.ShowLockedOnTargetText();
        Debug.Log("Target locked!");
    }

    private void UnLockTarget()
    {
        lockOnStatus = false;
        lockOnTimer = 0;
        gameCanvas.HideLockedOnTargetText();
        Debug.Log("Target unlocked!");
    }
}

