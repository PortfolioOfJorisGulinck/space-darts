using System.Collections.Generic;
using System;
using UnityEngine;

// Manages the scores of the game and its persistence
public class HighScoreManager : MonoBehaviour
{
    public void SaveHighScore(int attempts, int time, string expeditionName, string date)
    {
        // Creating a new HighScoreEntry instance
        HighScoreEntry highScoreEntry = new HighScoreEntry(attempts, time, expeditionName, date);

        // Retreiving saved data from PlayerPrefs
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        // Adding highScoreEntry to List
        highScores.highScoreEntries.Add(highScoreEntry);

        // Saving updated highScores as a string to PlayerPrefs
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
        Debug.Log("HighScore saved");
    }

    // Only used once for the creation of example data. The method can be called in the GameManager script.
    public void CreateStartDataOfHighScores()
    {
        // creating a list with example data
        List<HighScoreEntry> highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry(5, 90, "Moon", "2020/10/05 12:20:15"),
            new HighScoreEntry(4, 110, "Jupiter", "2020/10/15 10:32:42"),
            new HighScoreEntry(7, 180, "Mars", "2020/11/14 9:12:33")
        };
        HighScores highScores = new HighScores { highScoreEntries = highScoreEntryList };

        // Saving list as a string to PlayerPrefs
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(json);
    }

    // Inner class: Represents the list of HighScore entries
    public class HighScores
    {
        public List<HighScoreEntry> highScoreEntries;
    }

    // Inner class: Represents a single HighScore entry
    [Serializable]
    public class HighScoreEntry
    {
        public int attempts;
        public int time;
        public string expeditionName;
        public string date;

        public HighScoreEntry(int attempts, int time, string expeditionName, string date)
        {
            this.attempts = attempts;
            this.time = time;
            this.expeditionName = expeditionName;
            this.date = date;
        }
    }
}
