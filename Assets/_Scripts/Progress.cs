using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    private Slider progress;

    private float currentProgress = 0;

    public float fillSpeed = 0.5f;

    private void Awake()
    {
        progress = gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        QuotaProgress(0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        if (progress.value < currentProgress)
        {
            progress.value += fillSpeed * Time.deltaTime;
        }
    }

    public void QuotaProgress(float currentProgress)
    {
        currentProgress = progress.value += currentProgress;
    }
}
