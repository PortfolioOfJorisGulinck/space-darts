using UnityEngine;

// Keeps the state of properties between different scenes. Design pattern: Singleton
public class StateManager : MonoBehaviour
{
    public static StateManager Instance { get; private set; }

    public string MissionName { get; set; } = "Undefined";
    public int NumberOfAttempts { get; set; } = 1;
    public float TimePassed { get; set; } = 0f;
    public bool TargetDestroyed { get; set; } = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Resets the state to its default values
    public void ResetToDefault()
    {
        MissionName = "Undefined";
        NumberOfAttempts = 1;
        TimePassed = 0f;
        TargetDestroyed = false;
        Debug.Log("Resetting state of the game to its default values...");
    }
}
