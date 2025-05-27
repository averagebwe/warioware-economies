using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupCompletionCheck : MonoBehaviour
{
    [SerializeField] SceneController controller;
    public void CheckCompletion()
    {
        if (controller.groupCounter == controller.minigamesBuildIndexList.Count)
        {
            controller.Shuffle();
            controller.groupCounter = 0;
        }
    }
}
