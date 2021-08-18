using UnityEngine;

// Starts the menu scene
public class StartPage : MonoBehaviour
{
    SceneLoaderManager sceneLoaderManager;

    private void Start()
    {
        sceneLoaderManager = GameObject.Find("SceneLoader").GetComponent<SceneLoaderManager>();
    }

    public void StartMenuScene()
    {
        sceneLoaderManager.LoadNextScene("MenuScene");
        Debug.Log("MenuScene started...");
    }
}
