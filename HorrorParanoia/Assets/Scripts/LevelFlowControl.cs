using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFlowControl : MonoBehaviour
{
    [SerializeField] private List<GameObject> interactiveObjects;
    [SerializeField] private int indexCount = 0;

    public GameObject GetGameObject()
    {
        if(indexCount < interactiveObjects.Count)
        {
            return interactiveObjects[indexCount].gameObject;
        }
        else
        {
            return null;
        }
    }

    public void ObjectTriggered()
    {
        indexCount++;
    }
}
