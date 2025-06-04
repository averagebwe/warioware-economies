using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCrisisScript : MonoBehaviour
{
    private GameObject controller;
    public GameObject conditionManager;
    private float colorTimeChange;
    private float timer;
    private float crisisDelay;
    private bool crisisOccur = false;
    [SerializeField] private GameObject[] regions;
    [SerializeField] private GameObject crisisRegion;
    SpriteRenderer crisisRegionRenderer;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        colorTimeChange = 3 - (controller.GetComponent<SceneController>().playedGames / controller.GetComponent<SceneController>().minigamesBuildIndexList.Count) * 0.3f;
        if (colorTimeChange < 0.3f)
            colorTimeChange = 0.3f;
        crisisRegion = regions[Random.Range(0, regions.Length)];
        crisisRegionRenderer = crisisRegion.GetComponent<SpriteRenderer>();
        crisisDelay = Random.Range(7f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DelayColorChange(crisisDelay));
        if (crisisOccur)
        {
            timer += Time.deltaTime;
            ChangeColors(timer);
        }

        if (timer >= colorTimeChange)
        {
            crisisOccur = false;
            timer = 0;
            conditionManager.GetComponent<ResultScript>().ShowLose("<mark=#000000ff>МИРОВОЙ КРИЗИС<mark>");
            Time.timeScale = 0;
            StartCoroutine(LoadAfterDelay());
        }
    }


    void ChangeColors(float t)
    {
        crisisRegionRenderer.color = Color.Lerp(Color.white, Color.red, t / colorTimeChange);
    }

    IEnumerator DelayColorChange(float delay)
    {
        yield return new WaitForSeconds(delay);
        crisisRegion.GetComponent<BoxCollider2D>().enabled = true;
        crisisOccur = true;
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
