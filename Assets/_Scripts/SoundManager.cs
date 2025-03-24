using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider musicSlider;

    void Update()
    {
        audioSource.volume = musicSlider.value;
    }
}
