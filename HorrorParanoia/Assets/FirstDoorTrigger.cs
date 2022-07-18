using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject FirstDoor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FirstDoor.SetActive(true);
        }
    }
}
