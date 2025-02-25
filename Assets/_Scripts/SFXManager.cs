using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    public Slider sfxSlider;

    public void SFXChange()
    {
        AudioListener.volume = sfxSlider.value;
    }
}
