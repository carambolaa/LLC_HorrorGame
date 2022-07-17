using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerUse : MonoBehaviour
{
    public GameObject mainCamera;
    private GameObject objectClicked;
    public GameObject flashlight;
    public KeyCode OpenClose;
    public KeyCode Flashlight;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(OpenClose)) // Open and close action
            {
                RaycastCheck();
            }

        if (Input.GetKeyDown(Flashlight)) // Toggle flashlight
        {
            if (flashlight.activeSelf )
                  flashlight.SetActive(false);
            else
                 flashlight.SetActive(true);
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
                if(go.GetComponent<DoorLocker>().GetCanOpen())
                {
                    go.BroadcastMessage("PlaySFX");
                    go.BroadcastMessage("ObjectClicked");
                    if (go.GetComponent<AutoDoorControl>())
                    {
                        var reference = transform.GetComponent<SimplePlayerController>();
                        reference.GetCurrentPosition();
                        reference.SetTransitState(true);
                        reference.SetDestination(hit.collider.gameObject.GetComponent<AutoDoorControl>().GetDestination());
                        reference.SetCurrentDoor(hit.collider.gameObject);
                    }
                }
                else
                {
                    //play lock sound
                    Debug.Log("doorLocked");
                }
            }
            else
            {

            }
        }
        else
        {
         // Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
         //   Debug.Log("Did not Hit");


        }

    }

}
