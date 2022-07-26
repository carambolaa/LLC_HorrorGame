using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingCollisionSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private float relativeVelocity;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > relativeVelocity)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
