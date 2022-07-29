using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private GameObject Ghost;
    [SerializeField] private bool isActive;
    [SerializeField] private Transform InitialPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform resetPoint;
    private bool isOn;

    private void Start()
    {
        player = GameObject.Find("FPS Controller");
    }

    private void Update()
    {
        if(isActive && isOn == false)
        {
            StartCoroutine("GhostAI");
        }
    }

    public void reset()
    {
        player.transform.position = resetPoint.position;
        player.transform.rotation = Quaternion.Euler(0, 180, 0);
        player.GetComponent<SimplePlayerController>().canMove = true;
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<SimplePlayerUse>().SetShouldFlick(false);
        StopCoroutine("GhostAI");
        SetIsActive(false);
        GetComponent<GhostHunt>().SetShouldChase(false);
        GetComponent<NavMeshAgent>().enabled = false;
        transform.position = InitialPoint.position;
        transform.rotation = InitialPoint.rotation;
        GetComponent<NavMeshAgent>().enabled = true;
        Ghost.transform.position = InitialPoint.position;
        Ghost.transform.rotation = InitialPoint.rotation;
        Ghost.SetActive(false);
    }

    public void SetIsActive(bool bo)
    {
        isActive = bo;
    }

    IEnumerator GhostAI()
    {
        isOn = true;
        if(Vector3.Distance(player.transform.position, transform.position) < 1.5f)
        {
            player.GetComponent<SimplePlayerController>().canMove = false;
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<SimplePlayerUse>().SetShouldFlick(true);
            Ghost.SetActive(true);
            var cur = player.transform.Find("GhostPosition").position;
            cur.y -= 1.42f;
            Ghost.transform.position = cur;
            Ghost.transform.rotation = player.transform.Find("GhostPosition").rotation;
            yield return new WaitForSeconds(1.5f);
            reset();
        }
        else
        {
            var cur = gameObject.transform.position;
            cur.y -= 1;
            Ghost.transform.position = cur;
            Ghost.transform.rotation = gameObject.transform.rotation;
            Ghost.SetActive(true);
            yield return new WaitForSeconds(1);
            Ghost.SetActive(false);
            yield return new WaitForSeconds(1);
        }
        isOn = false;
    }
}
