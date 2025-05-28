using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreUI : MonoBehaviour
{
    [SerializeField] GameObject leaderboardPanel;


    public void OpenTab()
    {
        leaderboardPanel.SetActive(true);
    }


    public void CloseTab()
    {
        leaderboardPanel.SetActive(false);
    }
}
