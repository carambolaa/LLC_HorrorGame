using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoorControl : MonoBehaviour
{
    [SerializeField] private Transform destination;

    public Vector3 GetDestination()
    {
        return destination.position;
    }
}
