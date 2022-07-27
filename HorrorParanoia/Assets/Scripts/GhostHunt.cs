using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostHunt : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask Ground, Player;
    [SerializeField] private bool shouldChase;

    private void Start()
    {
        player = GameObject.Find("FPS Controller").transform;
        agent = GetComponent<NavMeshAgent>();

        if (shouldChase)
            ChasePlayer();
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
}
