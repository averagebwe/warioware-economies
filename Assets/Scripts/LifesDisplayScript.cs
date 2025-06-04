using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifesDisplayScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI loadText;
    private GameObject controller;
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (controller.GetComponent<SceneController>().initialCheck)
            loadText.enabled = false;
    }
}
