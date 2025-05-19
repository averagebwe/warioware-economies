using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI loseText;

    void Start()
    {
        winText.enabled = false;
        loseText.enabled = false;
    }
    

    public void ShowWin(string uniqueWin)
    {
        winText.enabled = true;
        winText.text = uniqueWin;
    }


    public void ShowLose(string uniqueLose)
    {
        loseText.enabled = true;
        loseText.text = uniqueLose;
    }
}
