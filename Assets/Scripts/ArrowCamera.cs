using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCamera : MonoBehaviour
{
    private Vector3 offset = new Vector3(-0.4f, 3.1f, -6f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
