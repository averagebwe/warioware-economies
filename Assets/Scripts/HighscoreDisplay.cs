using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI leaderText;
    private GameObject scoreControl;
    private string textBoxString;
    private Dictionary<string, string> scoreDict;


    void Awake()
    {
        scoreControl = GameObject.FindWithTag("ScoreManager");
        scoreDict = scoreControl.GetComponent<ScoreManager>().highScores;

        foreach (KeyValuePair<string, string> line in scoreDict)
        {
            textBoxString += string.Format("{0} - {1}\n", line.Key, line.Value);
        }

        leaderText.text = textBoxString;
        Debug.Log(textBoxString);
    }
}
