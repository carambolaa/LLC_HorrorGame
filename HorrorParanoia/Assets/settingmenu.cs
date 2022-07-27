using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class settingmenu : MonoBehaviour
{
    public AudioMixer mainmixer;
    public void SetVolume(float volume)
    {
        mainmixer.SetFloat("volume", volume);
    }
    public void SetFullScreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }
    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }
}
