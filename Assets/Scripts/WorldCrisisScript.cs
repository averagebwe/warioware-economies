using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCrisisScript : MonoBehaviour
{
    private float colorTimeChange = 2f;
    private float timer;
    private float crisisDelay;
    private bool crisisOccur = false;
    [SerializeField] private GameObject[] regions;
    SpriteRenderer crisisRegion;
    // Start is called before the first frame update
    void Start()
    {
        crisisRegion = regions[Random.Range(0, regions.Length)].GetComponent<SpriteRenderer>();
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
    }


    void ChangeColors(float t)
    {
        crisisRegion.color = Color.Lerp(Color.white, Color.red, t / colorTimeChange);
    }

    IEnumerator DelayColorChange(float delay)
    {
        yield return new WaitForSeconds(delay);
        crisisOccur = true;
    }
}
