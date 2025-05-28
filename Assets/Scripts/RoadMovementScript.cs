using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovementScript : MonoBehaviour
{
    private GameObject controller;
    public float roadSpeed;
    [SerializeField] private GameObject roadMoving;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        roadSpeed = 15 + (controller.GetComponent<SceneController>().playedGames / controller.GetComponent<SceneController>().minigamesBuildIndexList.Count) * 2;
        if (roadSpeed > 29)
            roadSpeed = 29;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * roadSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Delete"))
        {
            Destroy(roadMoving);
        }
    }
}
