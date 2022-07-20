using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildAudioSource : MonoBehaviour
{
    public void PlayTheClipAfterSecs(float delay)
    {
        Invoke("PlaySound", delay);
    }

    private void PlaySound()
    {
        transform.GetComponent<AudioSource>().Play();
    }

    public void StopSound()
    {
        transform.GetComponent<AudioSource>().Stop();
    }
}
