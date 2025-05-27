using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public List<int> minigamesBuildIndexList = new List<int>();
    public List<int> shuffledList = new List<int>();
    public int passedGames, groupCounter;

    void Awake()
    {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            minigamesBuildIndexList.Add(i);
        }
        Debug.Log(minigamesBuildIndexList.Count);
        shuffledList = minigamesBuildIndexList;
        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        passedGames = 0;
        groupCounter = 0;
        Shuffle();
        LoadMini();
    }


    public void LoadMini()
    {
        SceneManager.LoadScene(shuffledList[groupCounter]);
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
