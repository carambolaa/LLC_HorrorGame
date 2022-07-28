using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAreaDetection : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float detectRange;
    [SerializeField] private float triggerRange;

    private void Start()
    {
        player = GameObject.Find("FPS Controller").transform;
    }

    private void Update()
    {
        if(gameObject.activeSelf)
        {
            if(Vector3.Distance(this.transform.position, player.position) < detectRange)
            {
                if(Vector3.Distance(this.transform.position, player.position) < triggerRange)
                {
                    player.GetComponent<SimplePlayerUse>().SetShouldFlick(false);
                    Destroy(this.gameObject);
                }
                else
                {
                    player.GetComponent<SimplePlayerUse>().SetShouldFlick(true);
                }
            }
        }
    }
}
