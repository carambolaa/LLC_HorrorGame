using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishHunting : MonoBehaviour
{
    [SerializeField] private GameObject righHalf;
    [SerializeField] private GameObject GhostAI;
    [SerializeField] private GameObject Ghost;
    [SerializeField] private GameObject FinalDoor;

    public void StopHunting()
    {
        Destroy(GhostAI);
        Destroy(Ghost);
        righHalf.SetActive(true);
        FinalDoor.GetComponent<LoadFinishScene>().canFinish = true;
    }
}
