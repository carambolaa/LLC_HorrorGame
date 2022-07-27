using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLerpController : MonoBehaviour
{
    private float StartValue = 20;
    private float EndValue = 0;
    [SerializeField] private float lerpDuration;
    private float timeElapsed = 10;

    private void Update()
    {
        if(timeElapsed < lerpDuration)
        {
            transform.localRotation = Quaternion.Euler(0,75f, Mathf.Lerp(StartValue, EndValue, timeElapsed / lerpDuration));
            timeElapsed += Time.deltaTime;
        }
    }

    public void StartLerp()
    {
        timeElapsed = 0;
        StartCoroutine("DisableGameObject");
    }

    IEnumerator DisableGameObject()
    {
        yield return new WaitForSeconds(1.5f);
        transform.parent.gameObject.SetActive(false);
    }
}
