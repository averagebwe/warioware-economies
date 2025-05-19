using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCrisisScript : MonoBehaviour
{
    //private float colorChangeTime = 2f;
    [SerializeField] private GameObject[] regions;
    SpriteRenderer crisisRegion;
    // Start is called before the first frame update
    void Start()
    {
        crisisRegion = regions[Random.Range(0, regions.Length)].GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColors();
    }


    void ChangeColors()
    {
        crisisRegion.color = Color.Lerp(Color.white, Color.red, Time.time / 2f);
    }

    IEnumerator DelayColorChange(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
