using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallFunctionsOnPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<SimplePlayerController>().ThunderAudio.volume > 0)
            {
                other.GetComponent<SimplePlayerController>().FadeSound();
            }
            else
            {
                other.GetComponent<SimplePlayerController>().IncreaseSound();
            }
            Destroy(gameObject);
        }
    }
}
