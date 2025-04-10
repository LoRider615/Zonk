using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunesUI : MonoBehaviour
{
    public Button modifierButton;

    public PocketHandler pocketHandler;

    public void Awake()
    {
        pocketHandler = FindObjectOfType<PocketHandler>();

        modifierButton.interactable = false; 
    }

    public void ButtonOn()
    {
        if(pocketHandler.quota > 1000)
        {
            modifierButton.interactable = true;
        }
    }
}
