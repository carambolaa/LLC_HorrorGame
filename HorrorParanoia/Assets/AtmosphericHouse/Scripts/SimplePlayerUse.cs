using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerUse : MonoBehaviour
{
    public GameObject mainCamera;
    private GameObject objectClicked;
    public GameObject flashlight;
    public AudioClip flashLightOn;
    public AudioClip flashLightOff;
    public AudioSource flashLightAudio;
    public KeyCode OpenClose;
    public KeyCode Flashlight;
    [SerializeField] private bool shouldFlick;
    public bool haveHalf;

    void Update()
    {
        if (Input.GetKeyDown(OpenClose)) // Open and close action
            {
                RaycastCheck();
            }
        flashlight.GetComponent<LightFlinker>().SetShouldFlick(shouldFlick);

        if (Input.GetKeyDown(Flashlight)) // Toggle flashlight
        {
            if (flashlight.activeSelf)
            {
                flashLightAudio.GetComponent<AudioSource>().PlayOneShot(flashLightOff);
                if(shouldFlick)
                {
                    flashlight.GetComponent<LightFlinker>().Reset();
                }
                flashlight.SetActive(false);
            }
            else
            {
                flashLightAudio.GetComponent<AudioSource>().PlayOneShot(flashLightOn);
                if(shouldFlick)
                {
                    flashlight.GetComponent<LightFlinker>().Reset();
                }
                flashlight.SetActive(true);
            }
        }
        GhostRaycastCheck();
    }

    void GhostRaycastCheck()
    {
        RaycastHit hit;

        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, 20f))
        {
            if(hit.collider.tag == "Ghost")
            {
                Debug.Log("found");
                hit.collider.BroadcastMessage("Triggered");
            }
        }
    }

    void RaycastCheck()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, 1f))
        {
            if (hit.collider.gameObject.GetComponent<DoorLocker>())
            {
                var go = hit.collider.gameObject;
                if(go.GetComponent<TriggerEvents>())
                {
                    go.BroadcastMessage("Triggered");
                }
                if(go.GetComponent<DoorLocker>().GetCanOpen() && !go.GetComponent<DoorLocker>().GetIsLocked())
                {
                    go.BroadcastMessage("PlaySFX");
                    go.BroadcastMessage("ObjectClicked");
                    if (go.GetComponent<AutoDoorControl>())
                    {
                        var reference = transform.GetComponent<SimplePlayerController>();
                        reference.SetCurrentDoor(hit.collider.gameObject);
                        reference.GetCurrentPosition();
                        reference.SetTransitState(true);
                        reference.SetDestination(hit.collider.gameObject.GetComponent<AutoDoorControl>().GetDestination());
                    }
                }
                else if(go.GetComponent<DoorLocker>().GetIsLocked())
                {
                    //play lock sound
                    go.BroadcastMessage("PlayLockedSound");
                }
            }
            else
            {

            }
            if(hit.collider.gameObject.GetComponent<TriggerEvents>())
            {
                hit.collider.gameObject.GetComponent<TriggerEvents>().Triggered();
            }
            if(hit.collider.gameObject.GetComponent<Level10PaintingTrigger>())
            {
                hit.collider.gameObject.GetComponent<Level10PaintingTrigger>().StartHunting();
            }
            if(hit.collider.gameObject.GetComponent<FinishHunting>() && haveHalf)
            {
                hit.collider.gameObject.GetComponent<FinishHunting>().StopHunting();
            }
        }
        else
        {
         // Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
         //   Debug.Log("Did not Hit");
        }

    }


    public void SetShouldFlick(bool bo)
    {
        shouldFlick = bo;
    }
}
