using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private List<Transform> WayPoint;
    [SerializeField] private float speed;
    [SerializeField] private int index;
    [SerializeField] private bool started;

    private void Update()
    {
        if(started)
        {
            if (transform.position == WayPoint[index].position)
            {
                //go to next waypoint
                if(index == WayPoint.Count - 1)
                {
                    DeavtiveObejct();
                }
                else
                {
                    index++;
                }
            }
            else
            {
                Walk(index);
            }
        }
    }

    private void Walk(int index)
    {
        transform.position = Vector3.MoveTowards(transform.position, WayPoint[index].position, speed * Time.deltaTime);
    }

    public void DeavtiveObejct()
    {
        transform.GetComponent<AudioSource>().Stop();
        transform.gameObject.SetActive(false);
    }

    public void ActiveObject()
    {
        transform.gameObject.SetActive(true);
        index = 0;
        started = true;
        transform.GetComponent<AudioSource>().Play();
    }

    public void ActiveObjectAfterSecs(float delay)
    {
        Invoke("ActiveObject", delay);
    }
}
