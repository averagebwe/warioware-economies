using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrisisRegionScript : MonoBehaviour
{
    private GameObject controller;
    public GameObject conditionManager;
    private float transitionTimer;


    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        GetComponent<BoxCollider2D>().enabled = false;
    }


    private void OnMouseDown()
    {
        conditionManager.GetComponent<ResultScript>().ShowWin("<mark=#000000ff>ДЕФОЛТ!<mark>");
        Time.timeScale = 0;
        StartCoroutine(LoadAfterDelay());
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        if (conditionManager.GetComponent<ResultScript>().winText.enabled == true)
            controller.GetComponent<SceneController>().passedGames++;
        else
            controller.GetComponent<SceneController>().gameFails++;
        controller.GetComponent<SceneController>().playedGames++;
        controller.GetComponent<SceneController>().groupCounter++;
        controller.GetComponent<GroupCompletionCheck>().CheckCompletion();
        controller.GetComponent<SceneController>().LoadMini();
    }
}
