using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCrisisScript : MonoBehaviour
{
    public GameObject conditionManager; 
    private float colorTimeChange = 2f;
    private float timer;
    private float crisisDelay;
    private bool crisisOccur = false;
    [SerializeField] private GameObject[] regions;
    [SerializeField] private GameObject crisisRegion;
    SpriteRenderer crisisRegionRenderer;

    // Start is called before the first frame update
    void Start()
    {
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

        if (crisisRegionRenderer.color == Color.red)
        {
            conditionManager.GetComponent<ResultScript>().ShowLose("<mark=#000000ff>МИРОВОЙ КРИЗИС<mark>");
            Time.timeScale = 0;
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
}
