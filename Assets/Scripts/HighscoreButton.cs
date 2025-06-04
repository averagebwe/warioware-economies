using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreButton : MonoBehaviour
{
    private GameObject controller, addUI;
    private int score;
    public void GoToMainMenu()
    {
        addUI = GameObject.FindWithTag("AdditionalUI");
        controller = GameObject.FindWithTag("GameController");
        Destroy(addUI);
        Destroy(controller);
        SceneManager.LoadScene("MainMenu");
    }
}
