using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController : MonoBehaviour
{
    public List<int> minigamesBuildIndexList = new List<int>();
    public List<int> shuffledList = new List<int>();
    public int playedGames, passedGames, groupCounter, gameFails;
    private int lifes;
    public bool initialCheck = false;
    [SerializeField] public TextMeshProUGUI lifesText;

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
        initialCheck = true;
    }


    public void LoadMini()
    {
        lifes = 3 - gameFails;
        if (lifes > 0)
            SceneManager.LoadScene(shuffledList[groupCounter]);
        else
            SceneManager.LoadScene("GameOver");
        lifesText.text = "<mark=#000000ff>Жизни:<mark>" + lifes.ToString();
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
