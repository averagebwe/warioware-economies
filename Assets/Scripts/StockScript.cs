using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockScript : MonoBehaviour
{
    private float elapsedTime;
    private GameObject controller;
    public GameObject conditionManager;
    private float completionTime;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        completionTime = 20 - (controller.GetComponent<SceneController>().playedGames / controller.GetComponent<SceneController>().minigamesBuildIndexList.Count) * 3;
        elapsedTime = 0;
        if (completionTime < 10)
            completionTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > completionTime)
        {
            FailStock();
        }
    }


    void FailStock()
    {
        conditionManager.GetComponent<ResultScript>().ShowLose("<mark=#000000ff>ОБВАЛ АКЦИЙ<mark>");
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
