using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseCanvas;
    public GameObject pauseButton;

    public void Start()
    {
        PauseCanvas.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void PauseGame()
    {
        //pauses game
        Time.timeScale = 0;
        //adds pause screen overlay
        PauseCanvas.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
        pauseButton.SetActive(true);
    }
}
