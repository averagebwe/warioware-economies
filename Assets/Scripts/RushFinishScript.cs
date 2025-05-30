using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushFinishScript : MonoBehaviour
{
    [SerializeField] RoadMovementScript roadMovementScript;
    public int passedSectionsCounter = 0;
    private int sectionsNeeded;
    private float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        sectionsNeeded = Random.Range(10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }


    public void CheckSectionsCounter()
    {
        if (passedSectionsCounter == sectionsNeeded)
        {
            speed = roadMovementScript.roadSpeed;
        }
    }
}
