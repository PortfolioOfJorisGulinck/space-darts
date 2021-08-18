using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Creates the UI for the high score entries
public class HighScoreTable : MonoBehaviour
{
    // Table of highscores
    private Transform entryContainer;
    private Transform entryTemplate;

    // Rows of highscores
    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);

        // Retreiving saved data from PlayerPrefs
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScoreManager.HighScores highScores = JsonUtility.FromJson<HighScoreManager.HighScores>(jsonString);

        // Sorting the list bij number of attempts
        for (int i = 0; i < highScores.highScoreEntries.Count; i++)
        {
            for (int j = i + 1; j < highScores.highScoreEntries.Count; j++)
            {
                if (highScores.highScoreEntries[j].attempts < highScores.highScoreEntries[i].attempts)
                {
                    // swapping the entry's
                    HighScoreManager.HighScoreEntry tmp = highScores.highScoreEntries[i];
                    highScores.highScoreEntries[i] = highScores.highScoreEntries[j];
                    highScores.highScoreEntries[j] = tmp;
                }
            }
        }

        // Creating the final top 10 scores
        highScoreEntryTransformList = new List<Transform>();
        if (highScores.highScoreEntries.Count > 10)
        {
            for (int i = 0; i < 10; i++)
            {
                CreateHighScoreEntryTransform(highScores.highScoreEntries[i], entryContainer, highScoreEntryTransformList);
            }
        }
        else
        {
            foreach (HighScoreManager.HighScoreEntry highScoreEntry in highScores.highScoreEntries)
            {
                CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
            }
        }
    }

    // Creates the entry transform object 
    private void CreateHighScoreEntryTransform(HighScoreManager.HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float rowHeight = 25f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -rowHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        entryTransform.Find("PosText").GetComponent<TextMeshProUGUI>().text = rank.ToString();

        string attemptsString = highScoreEntry.attempts.ToString();
        entryTransform.Find("AttemptsText").GetComponent<TextMeshProUGUI>().text = attemptsString;

        string timeString = highScoreEntry.time + "s";
        entryTransform.Find("TimeText").GetComponent<TextMeshProUGUI>().text = timeString;

        entryTransform.Find("ExpText").GetComponent<TextMeshProUGUI>().text = highScoreEntry.expeditionName;

        entryTransform.Find("DateText").GetComponent<TextMeshProUGUI>().text = highScoreEntry.date;

        transformList.Add(entryTransform);
    }
}


