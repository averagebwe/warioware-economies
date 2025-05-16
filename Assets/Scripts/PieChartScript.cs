//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class PieChartScript : MonoBehaviour
//{
//    public GameObject[] pieChartPrefabs;
//    public float[] generalValues;

//    // Start is called before the first frame update
//    void Start()
//    {
//        SetValues(generalValues);

//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    public void SetValues(float[] sliderValues)
//    {
//        float totalValues = 0;

//        for (int i = 0; i < pieSliderPrefabs.Length; i++)
//        {
//            totalValues += FindPercentage(sliderValues, i);
//            pieChartPrefabs[i].value = totalValues;
//        }
//    }

//    public void FindPercentage(float[] valuesToSet, int index)
//    {
//        float totalAmount = 0;

//        for (int i = 0; i < valuesToSet.Length; i++)
//        {
//            totalAmount += valuesToSet[i];
//        }

//        return valuesToSet[index] / totalAmount;
//    }

//    public void PieChartGeneration()
//    {
//        int pieChartAmount = Random.Range(3, 5);
//        float[] piePieceValues = new float[pieChartAmount];

//        for (int i = 0; i < pieChartAmount; i++)
//        {
//            piePieceValues[i] = Random.Range(0.0f, 100.0f);
//            pieChartPrefabs[i].Color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
//        }
//    }
//}
