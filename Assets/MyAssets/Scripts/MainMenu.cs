using UnityEngine;

// Responsible for Quitting the game
public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitting the program");
        Application.Quit();
    }
}
