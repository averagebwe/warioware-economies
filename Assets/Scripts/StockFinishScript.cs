using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockFinishScript : MonoBehaviour
{
    private float finishPosition;
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        finishPosition = Random.Range(0f, 7f);
        float steppedPos = Mathf.Floor(finishPosition / 1) * 0.899f;
        transform.position += new Vector3(0, steppedPos, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
