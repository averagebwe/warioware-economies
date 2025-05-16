using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementScript : MonoBehaviour
{
    private int line = 2;

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
                transform.position = new Vector3(-4.5f, 1.7f, -14f);
                break;
            case 2: 
                transform.position = new Vector3(0f, 1.7f, -14f);
                break;
            case 3: 
                transform.position = new Vector3(4.5f, 1.7f, -14f);
                break;
        }            
    }
}
