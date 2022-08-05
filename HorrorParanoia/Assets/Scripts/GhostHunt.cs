using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostHunt : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private bool shouldChase;
    [SerializeField] private AudioSource footSteps;
    [SerializeField] private AudioSource chaseBGM;

    private void Start()
    {
        player = GameObject.Find("FPS Controller").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (shouldChase)
        {
            ChasePlayer();
            if(!footSteps.isPlaying)
            {
                footSteps.Play();
            }
            if(!chaseBGM.isPlaying)
            {
                chaseBGM.Play();
            }
        }
        else
        {
            chaseBGM.Stop();
            footSteps.Stop();
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    public void SetShouldChase(bool bo)
    {
        GetComponent<FollowAI>().SetIsActive(bo);
        shouldChase = bo;
    }
}
