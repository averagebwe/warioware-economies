using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public List<int> minigamesBuildIndexList = new List<int>();
    public List<int> shuffledList = new List<int>();
    public int playedGames, passedGames, groupCounter;
    public int gameFails;

    void Awake()
    {
        for (int i = 3; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            minigamesBuildIndexList.Add(i);
        }
        shuffledList = minigamesBuildIndexList;
        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        gameFails = 0;
        playedGames = 0;
        passedGames = 0;
        groupCounter = 0;
        Shuffle();
        LoadMini();
    }


    public void LoadMini()
    {
        Debug.Log(gameFails);
        if (gameFails < 3)
            SceneManager.LoadScene(shuffledList[groupCounter]);
        else if (gameFails >= 3)
            SceneManager.LoadScene("GameOver");
            
    }

    // Fisher-Yates shuffle algorithm
    public void Shuffle()
    {
        for (int i = minigamesBuildIndexList.Count - 1; i >= 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int tmp = shuffledList[j];
            shuffledList[j] = shuffledList[i];
            shuffledList[i] = tmp;
        }
    }
}
