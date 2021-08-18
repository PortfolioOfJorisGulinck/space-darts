using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Manages the onscreen user interface while playing an expedition
public class GameCanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject lockedTargetText;

    [SerializeField]
    private GameObject speedSliderObject;

    [SerializeField]
    private Slider speedSlider;

    [SerializeField]
    private Button retryBtn;

    [SerializeField]
    private Button exitBtn;

    [SerializeField]
    private Button saveScoreBtn;

    [SerializeField]
    private TextMeshProUGUI winningText;

    [SerializeField]
    private TextMeshProUGUI attemptsUI;

    [SerializeField]
    private TextMeshProUGUI timeUI;

    public void ShowSpeed(float speed)
    {
        speedSlider.value = speed;
    }

    public void ShowLockedOnTargetText()
    {
        lockedTargetText.SetActive(true);
        speedSliderObject.SetActive(true);
    }

    public void HideLockedOnTargetText()
    {
        lockedTargetText.SetActive(false);
        speedSliderObject.SetActive(false);
    }

    public void ShowWinningObjects()
    {
        retryBtn.gameObject.SetActive(false);
        winningText.gameObject.SetActive(true);
        saveScoreBtn.gameObject.SetActive(true);
    }

    public void DisplayTime(float timePassed)
    {
        timeUI.text = "Time: " + Mathf.Round(timePassed).ToString();
    }

    public void DisplayAttempts(int numberOfAttempts)
    {
        attemptsUI.text = "Attempts: " + numberOfAttempts;
    }
}

