using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildAudioSource : MonoBehaviour
{
    [SerializeField] private bool isLooping;
    private float time = 0f;

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

    public void SetLooping(bool bo)
    {
        isLooping = bo;
    }

    private void Update()
    {
        if(isLooping)
        {
            time += Time.deltaTime;
            if (time > 2.5f)
            {
                transform.GetComponent<AudioSource>().loop = true;
                if(!transform.GetComponent<AudioSource>().isPlaying)
                {
                    PlaySound();
                }
                if (time > 4)
                {
                    time = 0;
                }
            }
            else
            {
                transform.GetComponent<AudioSource>().loop = false;
                StopSound();
            }
        }
    }
}
