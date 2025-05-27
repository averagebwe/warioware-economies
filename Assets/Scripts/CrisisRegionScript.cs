using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrisisRegionScript : MonoBehaviour
{
    public GameObject conditionManager; 

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    private void OnMouseDown()
    {
        conditionManager.GetComponent<ResultScript>().ShowWin("<mark=#000000ff>ДЕФОЛТ!<mark>");
        Time.timeScale = 0;
    }
}
