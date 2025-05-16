using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovementScript : MonoBehaviour
{
    private float speed = 15f;
    [SerializeField] private GameObject roadMoving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Delete"))
        {
            Destroy(roadMoving);
        }
    }
}
