using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents: MonoBehaviour
{
    [SerializeField] private UnityEvent triggerTarget;
    [SerializeField] private Transform Level;

    public void Triggered()
    {
        if (ReferenceEquals(Level.GetComponent<LevelFlowControl>().GetGameObject(), gameObject))
        {
            triggerTarget.Invoke();
            Level.GetComponent<LevelFlowControl>().ObjectTriggered();
        }
    }
}
