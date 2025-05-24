using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTriggerScript : MonoBehaviour
{
    public GameObject[] roadPrefabs;


    void Start()
    {
        foreach (GameObject section in roadPrefabs)
        {
            section.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            int tileIndex = Random.Range(0, roadPrefabs.Length);
            var tile = Instantiate(roadPrefabs[tileIndex], new Vector3(0, 1, 18.5f), Quaternion.identity);
            tile.SetActive(true);

        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0;
        }
    }
}
