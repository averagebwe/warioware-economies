using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreButton : MonoBehaviour
{
    private GameObject controller;
    private int score;
    public void GoToMainMenu()
    {
        controller = GameObject.FindWithTag("GameController");
        score = controller.GetComponent<SceneController>.passedGames;
        SceneManager.LoadScene("MainMenu");
    }
}
