using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settingmenu : MonoBehaviour
{
    public AudioMixer mainmixer;
    public void SetVolume(float volume)
    {
        mainmixer.SetFloat("volume", volume);
    }
    public void setfullscreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }
}
