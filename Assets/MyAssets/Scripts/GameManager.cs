using System;
using UnityEngine;

// Manages the overall game
public class GameManager : MonoBehaviour
{
    private SceneLoaderManager sceneLoaderManager;
    private GameCanvasManager canvasManager;
    private HighScoreManager highScoreManager;

    private bool gameIsWon;
    private bool gameIsStopped;

    void Start()
    {
        canvasManager = GameObject.Find("GameCanvas").GetComponent<GameCanvasManager>();
        highScoreManager = GameObject.Find("GameController").GetComponent<HighScoreManager>();
        sceneLoaderManager = GameObject.Find("SceneLoader").GetComponent<SceneLoaderManager>();
    }

    void Update()
    {
        if (!gameIsStopped)
        {
            StateManager.Instance.TimePassed += Time.deltaTime;
        }

        canvasManager.DisplayTime(StateManager.Instance.TimePassed);
        canvasManager.DisplayAttempts(StateManager.Instance.NumberOfAttempts);
    }

    public void CoinCollected(GameObject coin)
    {
        gameIsWon = true;
        Destroy(coin);
        canvasManager.ShowWinningObjects();
    }

    public void TargetHit()
    {
        if (gameIsWon)
        {
            gameIsStopped = true;
        }
    }

    public void SaveWinningGame()
    {
        int attempts = StateManager.Instance.NumberOfAttempts;

        int time = (int) StateManager.Instance.TimePassed;

        string expeditionName = StateManager.Instance.MissionName;

        DateTime date = DateTime.Now;
        string dateString = date.ToString("MM/dd/yyyy h:mm:ss");

        //highScoreManager.CreateStartDataOfHighScores();
        highScoreManager.SaveHighScore(attempts, time, expeditionName, dateString);

        StateManager.Instance.ResetToDefault();
        sceneLoaderManager.LoadNextScene("MenuScene");
    }

    public void Retry()
    {
        StateManager.Instance.NumberOfAttempts++;
        StateManager.Instance.TargetDestroyed = false;

        switch (StateManager.Instance.MissionName)
        {
            case "Moon":
                sceneLoaderManager.LoadNextScene("LaunchMoonScene");
                break;
            case "Mars":
                sceneLoaderManager.LoadNextScene("LaunchMarsScene");
                break;
            case "Jupiter":
                sceneLoaderManager.LoadNextScene("LaunchJupiterScene");
                break;
            default:
                sceneLoaderManager.LoadNextScene("MenuScene");
                break;
        }
    }

    public void Exit()
    {
        StateManager.Instance.ResetToDefault();
        sceneLoaderManager.LoadNextScene("MenuScene");
    }
}
