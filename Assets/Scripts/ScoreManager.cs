using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Dictionary<string, string> highScores = new Dictionary<string, string>();
    private string filePath = @"D:\studying\course diploma\2 term\warioware-economies\Assets\Files\leaderboard.txt";

    // Start is called before the first frame update
    void Start()
    {
        foreach (string line in File.ReadLines(filePath))
        {
            string[] scoreLine = line.Split(';');
            highScores[scoreLine[0]] = scoreLine[1];
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
