using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishHunting : MonoBehaviour
{
    [SerializeField] private GameObject righHalf;
    [SerializeField] private GameObject GhostAI;
    [SerializeField] private GameObject Ghost;

    public void StopHunting()
    {
        Destroy(GhostAI);
        Destroy(Ghost);
        righHalf.SetActive(true);
    }
}
