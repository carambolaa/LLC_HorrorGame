using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLocker : MonoBehaviour
{
    public bool canOpen;
    [SerializeField] private bool isLocked;
    public AudioSource audioSource;
    public AudioClip openDoor;
    public AudioClip closeDoor;
    public AudioClip closingDoor;
    public AudioClip doorLocked;

    public void SetCanOpen(bool bo)
    {
        canOpen = bo;
    }

    public bool GetCanOpen()
    {
        return canOpen;
    }

    public void SetIsLocked(bool bo)
    {
        isLocked = bo;
    }

    public bool GetIsLocked()
    {
        return isLocked;
    }

    public void PlayLockedSound()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(doorLocked, 0.2f);
        }
    }

    public void DebugString(string st)
    {
        Debug.Log(st);
    }

    public void PlaySFX()
    {
        //Debug.Log(transform.localRotation.y);
        canOpen = false;
        if (transform.localRotation.y == 0)
        {
            audioSource.PlayOneShot(openDoor, 1);
            StartCoroutine(ResetCanOpen());
        }
        else if(transform.localRotation.y < 0)
        {
            audioSource.PlayOneShot(closingDoor, 1);
            StartCoroutine(CloseDoorSound());
        }
        else
        {
            StartCoroutine(ResetCanOpen());
        }
    }

    IEnumerator CloseDoorSound()
    {
        yield return new WaitForSeconds(1.9f);
        audioSource.PlayOneShot(closeDoor, 0.7f);
        canOpen = true;
    }

    IEnumerator ResetCanOpen()
    {
        yield return new WaitForSeconds(1.9f);
        canOpen = true;
    }
}
