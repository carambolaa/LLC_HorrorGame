using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlinker : MonoBehaviour
{
    public void Update()
    {
        this.gameObject.GetComponent<Renderer>().sharedMaterial.SetColor("_EmissionColor", new Color(2.55f, 0f, 2.55f, 0.1f));
    }
}
