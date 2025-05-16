using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Rigidbody2D arrowRigidbody;
    private float speed = 2f;
    private float vel = 2f;
    float smooth = 2f;
    private float tiltAngle = 45f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion noInputs = Quaternion.Euler(0, 0, -90f);
        Quaternion target = Quaternion.Euler(0, 0, tiltAngle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);
            arrowRigidbody.velocity = Vector2.up * vel;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, noInputs, Time.deltaTime * smooth);
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
