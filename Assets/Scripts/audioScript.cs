using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioScript : MonoBehaviour
{
    public AudioSource Music, Sound;
    public Toggle audioTog, sfxTog;

    public void enableMusic()   //toggle music
    {
        if (audioTog.isOn)
            Music.mute = false;
        else
            Music.mute = true;
    }
    public void enableSound()   //toggle SFX
    {
        if (sfxTog.isOn)
            Sound.mute = false;
        else
            Sound.mute = true;
    }
}
