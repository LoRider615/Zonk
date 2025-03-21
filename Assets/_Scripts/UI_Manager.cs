using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements; 
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text quotaText;
    public TMP_Text scoreText;
    public TMP_Text cacheText;
    public PlayerController playerController;
    public QuotaControl quotaControl;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerController.totalScore.ToString();
        quotaText.text = "Round 1 Quota: " + quotaControl.levelOneQuota.ToString();
        cacheText.text = "Cache: " + playerController.totalCache.ToString();
        //above will need work later (hooking it up to work and changing the code accordingly)
        //I might make this process more eficcient later (for the quota), but it works for now.
    }

    //Not sure if this has to be in OnEnable, I was following a tutorial to help me learn this and they used their example in this.
    private void OnEnable()
    {
        //This is a root reference to the UI, giving us access to it's elements.
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
    }
}
