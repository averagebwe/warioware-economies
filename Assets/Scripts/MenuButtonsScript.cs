using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsScript : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Loader");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
