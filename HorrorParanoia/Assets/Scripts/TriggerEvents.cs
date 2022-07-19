using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents: MonoBehaviour
{
    [SerializeField] private UnityEvent triggerTarget1;
    [SerializeField] private UnityEvent triggerTarget2;
    [SerializeField] private UnityEvent triggerTarget3;
    [SerializeField] private Transform Level;
    [SerializeField] private int triggeredTime = 0;

    public void Triggered()
    {
        if (ReferenceEquals(Level.GetComponent<LevelFlowControl>().GetGameObject(), gameObject))
        {
            //First Time Trigger
            if(triggeredTime == 0)
            {
                triggerTarget1.Invoke();
            }
            else if(triggeredTime == 1)
            {
                triggerTarget2.Invoke();
            }
            else if(triggeredTime == 2)
            {
                triggerTarget3.Invoke();
            }
            Level.GetComponent<LevelFlowControl>().ObjectTriggered();
            triggeredTime++;
        }
    }
}
