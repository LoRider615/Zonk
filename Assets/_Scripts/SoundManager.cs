using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider musicSlider;

    public void VolumeChange()
    {
        AudioListener.volume = musicSlider.value;
    }

}
