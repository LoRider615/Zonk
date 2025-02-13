using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressUI : MonoBehaviour
{
    private Image progressBar;
    private float speed = 1f;
    private UnityEvent<float> inProgress;
    private UnityEvent isFinished;
    private Coroutine newCoroutine;

    private void Start()
    {
        
    }
}
