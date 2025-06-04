using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTriggerScript : MonoBehaviour
{
    private GameObject controller;
    public GameObject[] roadPrefabs;
    public GameObject conditionManager;
    [SerializeField] RushFinishScript rushFinish;


    void Start()
    {
        controller = GameObject.FindWithTag("GameController");

        foreach (GameObject section in roadPrefabs)
        {
            section.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            rushFinish.passedSectionsCounter++;
            rushFinish.CheckSectionsCounter();
            int tileIndex = Random.Range(0, roadPrefabs.Length);
            var tile = Instantiate(roadPrefabs[tileIndex], new Vector3(0, 1, 18.5f), Quaternion.identity);
            tile.SetActive(true);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            conditionManager.GetComponent<ResultScript>().ShowWin("<mark=#000000ff>ДОЕХАЛ ДО БАНКА<mark>");
            Time.timeScale = 0;
            StartCoroutine(LoadAfterDelay());
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            conditionManager.GetComponent<ResultScript>().ShowLose("<mark=#000000ff>НЕ ДОЕХАЛ<mark>");
            Time.timeScale = 0;
            StartCoroutine(LoadAfterDelay());
        }
    }
    

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        if (conditionManager.GetComponent<ResultScript>().winText.enabled == true)
            controller.GetComponent<SceneController>().passedGames++;
        else
            controller.GetComponent<SceneController>().gameFails += 1;
        controller.GetComponent<SceneController>().playedGames++;
        controller.GetComponent<SceneController>().groupCounter++;
        controller.GetComponent<GroupCompletionCheck>().CheckCompletion();
        controller.GetComponent<SceneController>().LoadMini();
    }
}
