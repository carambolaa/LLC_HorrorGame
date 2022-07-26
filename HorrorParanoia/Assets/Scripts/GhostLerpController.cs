using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLerpController : MonoBehaviour
{
    private float StartValue = 20;
    private float EndValue = 0;
    [SerializeField] private float lerpDuration;
    private float timeElapsed = 0;

    private void Update()
    {
        if(timeElapsed < lerpDuration)
        {
            transform.rotation = Quaternion.Euler(0,180, Mathf.Lerp(StartValue, EndValue, timeElapsed / lerpDuration));
            timeElapsed += Time.deltaTime;
        }
    }
}
