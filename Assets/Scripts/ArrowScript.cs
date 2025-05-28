using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private GameObject controller;
    public GameObject conditionManager;
    public Rigidbody2D arrowRigidbody;
    private float speed = 2f;
    private float vel = 2f;
    float smooth = 2f;
    private float tiltAngle = 45f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            conditionManager.GetComponent<ResultScript>().ShowWin("<mark=#000000ff>УСПЕХ<mark>");
            Time.timeScale = 0;
            StartCoroutine(LoadAfterDelay());
        }
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        if (conditionManager.GetComponent<ResultScript>().winText.enabled == true)
            controller.GetComponent<SceneController>().passedGames++;
        else
            controller.GetComponent<SceneController>().gameFails++;
        controller.GetComponent<SceneController>().playedGames++;
        controller.GetComponent<SceneController>().groupCounter++;
        controller.GetComponent<GroupCompletionCheck>().CheckCompletion();
        controller.GetComponent<SceneController>().LoadMini();
    }
}
