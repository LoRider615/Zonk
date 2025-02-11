using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void Continue()
    {
        Debug.Log("Continue was pressed.");
    }

    public void New()
    {
        Debug.Log("New was pressed.");
    }

    public void Shop()
    {
        Debug.Log("Shop was pressed.");
    }

    public void Help()
    {
        Debug.Log("Help was pressed.");
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Log("You quit the game.");
    }

    public void Settings()
    {
        Debug.Log("Settings was pressed.");
    }
}
