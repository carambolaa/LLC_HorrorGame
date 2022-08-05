using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallFunctionsOnPlayer : MonoBehaviour
{
    [SerializeField] private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && triggered == false)
        {
            if(other.GetComponent<SimplePlayerController>().ThunderAudio.volume > 0)
            {
                other.GetComponent<SimplePlayerController>().FadeSound();
            }
            else
            {
                other.GetComponent<SimplePlayerController>().IncreaseSound();
            }
            triggered = true;
        }
    }
}
