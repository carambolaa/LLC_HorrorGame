using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlinker : MonoBehaviour
{
    [SerializeField] private bool isFlickering;
    [SerializeField] private float timeDelay;
    private bool shouldFlick;

    public void Update()
    {
        if(isFlickering == false && shouldFlick)
        {
            StartCoroutine("FlickeringLight");
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }

    public void Reset()
    {
        isFlickering = false;
    }

    public void SetShouldFlick(bool bo)
    {
        shouldFlick = bo;
    }
}
