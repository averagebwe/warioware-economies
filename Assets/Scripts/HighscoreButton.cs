using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighscoreButton : MonoBehaviour
{
    private GameObject controller, addUI;
    public TMP_InputField nameField;
    private string nickname;
    private int score, intScore;
    private GameObject scoreControl;
    private Dictionary<string, string> scoreDict;


    public void GoToMainMenu()
    {
        addUI = GameObject.FindWithTag("AdditionalUI");
        controller = GameObject.FindWithTag("GameController");
        score = controller.GetComponent<SceneController>().passedGames;
        Destroy(addUI);
        Destroy(controller);
        scoreControl = GameObject.FindWithTag("ScoreManager");
        scoreDict = scoreControl.GetComponent<ScoreManager>().highScores;

        nickname = nameField.text;
        if (nickname != "")
        {
            if ((scoreDict.ContainsKey(nickname) && int.Parse(scoreDict[nickname]) < score) || scoreDict.ContainsKey(nickname) == false)
            {
                scoreControl.GetComponent<ScoreManager>().highScores[nickname] = score.ToString();
            }
        }

        SceneManager.LoadScene("MainMenu");
    }
}
