using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text quotaText;
    public TMP_Text scoreText;
    public PlayerController playerController;
    public QuotaControl quotaControl;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerController.totalScore.ToString();
        quotaText.text = "Round 1 Quota: " + quotaControl.levelOneQuota.ToString();
        //above will need work later (hooking it up to work and changing the code accordingly)
        //I might make this process more eficcient later (for the quota), but it works for now.
    }

    public void Continue()
    {

    }

    public void New()
    {

    }

    public void Shop()
    {

    }

    public void Help()
    {

    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void Settings()
    {

    }
}
