using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockScript : MonoBehaviour
{
    public GameObject conditionManager;
    private float completionTime = 17f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime > completionTime)
        {
            conditionManager.GetComponent<ResultScript>().ShowLose("<mark=#000000ff>ОБВАЛ АКЦИЙ<mark>");
            Time.timeScale = 0;
        }
    }
}
