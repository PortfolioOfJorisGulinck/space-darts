using UnityEngine;

// Starts the game scenes
public class NewExpeditionManager : MonoBehaviour
{
    SceneLoaderManager sceneLoaderManager;

    private void Start()
    {
        sceneLoaderManager = GameObject.Find("SceneLoader").GetComponent<SceneLoaderManager>();
    }

    public void StartMoonExpedition() 
    {
        sceneLoaderManager.LoadNextScene("LaunchMoonScene");
        StateManager.Instance.MissionName = "Moon";
        Debug.Log("LaunchMoonScene started...");
    }

    public void StartMarsExpedition()
    {
        sceneLoaderManager.LoadNextScene("LaunchMarsScene");
        StateManager.Instance.MissionName = "Mars";
        Debug.Log("LaunchMarsScene started...");
    }

    public void StartJupiterExpedition()
    {
        sceneLoaderManager.LoadNextScene("LaunchJupiterScene");
        StateManager.Instance.MissionName = "Jupiter";
        Debug.Log("LaunchJupiterScene started...");
    }
}
