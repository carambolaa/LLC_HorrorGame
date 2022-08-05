using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAreaDetection : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float detectRange;
    [SerializeField] private float triggerRange;
    private int audioPlayedTime = 0;

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
                    PlayOnce();
                    player.GetComponent<SimplePlayerUse>().SetShouldFlick(true);
                }
            }
        }
    }

    private void PlayOnce()
    {
        if(audioPlayedTime == 0)
        {
            GetComponent<AudioSource>().Play();
            audioPlayedTime++;
        }
    }
}
