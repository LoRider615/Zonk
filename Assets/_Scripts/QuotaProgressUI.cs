using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class QuotaProgressUI : MonoBehaviour
{
    private void Awake()
    {
        ProgressBar quotaProgress = new ProgressBar();
    }    

    //currently, this is just for the first quota. 
    //this script is currently attached to the canvas in the quota UI scene. It might need to be removed later because I didn't know where to put it

    public ProgressBar CreateProgressBar()
    {
        var progressBar = new ProgressBar
        {
            title = "Quota Progress",
            lowValue = 0f,
            highValue = 1000f,
            value = 0f
        };
        return progressBar;
    }
}
