using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLocker : MonoBehaviour
{
    public bool canOpen;
    public AudioSource audioSource;
    public AudioClip openDoor;
    public AudioClip CloseDoor;

    public void SetCanOpen(bool bo)
    {
        canOpen = bo;
    }

    public bool GetCanOpen()
    {
        return canOpen;
    }

    public void PlaySFX()
    {
        audioSource.PlayOneShot(openDoor, 1);
        if (transform.localRotation.y < 0)
        {
            StartCoroutine(CloseDoorSound());
        }
    }

    IEnumerator CloseDoorSound()
    {
        yield return new WaitForSeconds(2f);
        
        audioSource.PlayOneShot(CloseDoor, 0.7f);
    }
}
