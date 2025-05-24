using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementScript : MonoBehaviour
{
    private int line = 2;
    private float smoothTime = 0.1f;
    public Vector3 carPosition;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && line != 1)
        {
            line--;
        }
        if (Input.GetKeyDown(KeyCode.D) && line != 3)
        {
            line++;
        }

        switch (line)
        {
            case 1:
                carPosition = new Vector3(-4.5f, 1f, -14f);
                break;
            case 2:
                carPosition = new Vector3(0f, 1f, -14f);
                break;
            case 3:
                carPosition = new Vector3(4.5f, 1f, -14f);
                break;
        }

        transform.position = Vector3.SmoothDamp(transform.position, carPosition, ref velocity, smoothTime);            
    }
}
