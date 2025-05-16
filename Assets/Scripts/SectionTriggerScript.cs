using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTriggerScript : MonoBehaviour
{
    public GameObject[] roadPrefabs;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            int tileIndex = Random.Range(0, roadPrefabs.Length);
            Instantiate(roadPrefabs[tileIndex], new Vector3(0, 1, 18.5f), Quaternion.identity);
        }
    }
}
