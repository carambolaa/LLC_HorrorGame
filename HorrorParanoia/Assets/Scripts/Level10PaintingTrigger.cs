using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level10PaintingTrigger : MonoBehaviour
{
    [SerializeField] GameObject GhostAI;
    private SimplePlayerUse player;

    private void Start()
    {
        player = GameObject.Find("FPS Controller").GetComponent<SimplePlayerUse>();
    }

    private void Update()
    {
        if(gameObject.activeSelf)
        {
            player.haveHalf = false;
        }
    }

    public void StartHunting()
    {
        player.haveHalf = true;
        GhostAI.SetActive(true);
        GhostAI.GetComponent<GhostHunt>().SetShouldChase(true);
        gameObject.SetActive(false);
    }
}
