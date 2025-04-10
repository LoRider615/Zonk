using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Logan Sharkey
/// 2/10/2025
/// Handles the logic for all the potential pockets 
/// </summary>
public class PocketHandler : MonoBehaviour
{
    public int[] Pocket1;
    public int[] Pocket2;
    public int[] Pocket3;
    public int[] Pocket4;
    public int[] Pocket5;
    public int[] Pocket6;

    //This is an outdated variable, but it could be useful later so i'm leaving it in for reference for future me just in case
    public int[][] PocketHolder = new int[6][];

    public int currentPocket = 0;
    public int currentTurn = 1;
    public int quota = 1000;
    public int diceAdded = 0;
    public int previousPoints = 0;

    private DiceCast _diceCast;

    public AudioSource _audioSource;
    public TMP_Text ScoreText;
    public TMP_Text CachedScoreText;
    public TMP_Text TurnText;
    public TMP_Text QuotaText;
    public GameObject ZonkText;
    public GameObject UIManager;
    public RunesUI runeUI;
    //public GameObject runesQuota;

    //public UIManager uIManager;

    public int playerScore = 0;
    public int playerCachedScore = 0;

    private void Awake()
    {

        runeUI = UIManager.GetComponent<RunesUI>();
        //uIManager = runesQuota.GetComponent<UIManager>();
        _diceCast = this.GetComponent<DiceCast>();

        //Ensures all pockets are empty
        Pocket1 = null; Pocket2 = null; Pocket3 = null; Pocket4 = null; Pocket5 = null; Pocket6 = null;

        for (int i = 0; i < PocketHolder.Length; i++)
        {
            switch (i)
            {
                case 0:
                    PocketHolder[i] = Pocket1;
                    break;
                case 1:
                    PocketHolder[i] = Pocket2;
                    break;
                case 2:
                    PocketHolder[i] = Pocket3;
                    break;
                case 3:
                    PocketHolder[i] = Pocket4;
                    break;
                case 4:
                    PocketHolder[i] = Pocket5;
                    break;
                case 5:
                    PocketHolder[i] = Pocket6;
                    break;
            }
        }

        TurnText.text = "Turn: " + currentTurn + "/3";
        QuotaText.text = "Quota: $" + quota;
        CachedScoreText.text = "Total: $" + playerCachedScore;
        ScoreText.text = "Pocketed: $" + playerScore;


        SetPockets();

    }

    public void SetPockets()
    {
        if (Pocket1 == null) Pocket1 = new int[_diceCast.diceToRoll];
        if (Pocket2 == null) Pocket2 = new int[_diceCast.diceToRoll];
        if (Pocket3 == null) Pocket3 = new int[_diceCast.diceToRoll];
        if (Pocket4 == null) Pocket4 = new int[_diceCast.diceToRoll];
        if (Pocket5 == null) Pocket5 = new int[_diceCast.diceToRoll];
        if (Pocket6 == null) Pocket6 = new int[_diceCast.diceToRoll];



        for (int i = 0; i < _diceCast.diceToRoll; ++i)
        {
            Pocket1[i] = 0;
        }
        for (int i = 0; i < _diceCast.diceToRoll; ++i)
        {
            Pocket2[i] = 0;
        }
        for (int i = 0; i < _diceCast.diceToRoll; ++i)
        {
            Pocket3[i] = 0;
        }
        for (int i = 0; i < _diceCast.diceToRoll; ++i)
        {
            Pocket4[i] = 0;
        }
        for (int i = 0; i < _diceCast.diceToRoll; ++i)
        {
            Pocket5[i] = 0;
        }
        for (int i = 0; i < _diceCast.diceToRoll; ++i)
        {
            Pocket6[i] = 0;
        }
    }

    /// <summary>
    /// This handles the logic of adding a number to a pocket
    /// </summary>
    /// <param name="diceNum"></param>
    public void AddToPocket(int diceNum)
    {
        diceAdded++;
        if (diceAdded == 6)
        {
            _diceCast.hotCast = true;
            diceAdded = 0;
        }
            

        switch (currentPocket)
        {
            case 1:
                //This is to initialize the pocket only when it's going to be used, in order to save memory
                if (Pocket1 == null)
                {
                    Pocket1 = new int[_diceCast.maxDiceToRoll];
                    for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                    {
                        Pocket1[i] = 0;
                    }
                }
                //Goes through the current pocket and replaces the first 0 it finds with the number added
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket1[i] == 0)
                    {
                        Pocket1[i] = diceNum;
                        ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints);
                        break;
                    }
                }
                break;
            case 2:
                //This is to initialize the pocket only when it's going to be used, in order to save memory
                if (Pocket2 == null)
                {
                    Pocket2 = new int[_diceCast.maxDiceToRoll];
                    for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                    {
                        Pocket2[i] = 0;
                    }
                }
                //Goes through the current pocket and replaces the first 0 it finds with the number added
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket2[i] == 0)
                    {
                        Pocket2[i] = diceNum;
                        ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints);
                        break;
                    }
                }
                break;

            case 3:
                //This is to initialize the pocket only when it's going to be used, in order to save memory
                if (Pocket3 == null)
                {
                    Pocket3 = new int[_diceCast.maxDiceToRoll];
                    for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                    {
                        Pocket3[i] = 0;
                    }
                }
                //Goes through the current pocket and replaces the first 0 it finds with the number added
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket3[i] == 0)
                    {
                        Pocket3[i] = diceNum;
                        ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints);
                        break;
                    }
                }
                break;

            case 4:
                //This is to initialize the pocket only when it's going to be used, in order to save memory
                if (Pocket4 == null)
                {
                    Pocket4 = new int[_diceCast.maxDiceToRoll];
                    for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                    {
                        Pocket4[i] = 0;
                    }
                }
                //Goes through the current pocket and replaces the first 0 it finds with the number added
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket4[i] == 0)
                    {
                        Pocket4[i] = diceNum;
                        ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints);
                        break;
                    }
                }
                break;

            case 5:
                //This is to initialize the pocket only when it's going to be used, in order to save memory
                if (Pocket5 == null)
                {
                    Pocket5 = new int[_diceCast.maxDiceToRoll];
                    for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                    {
                        Pocket5[i] = 0;
                    }
                }
                //Goes through the current pocket and replaces the first 0 it finds with the number added
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket5[i] == 0)
                    {
                        Pocket5[i] = diceNum;
                        ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints);
                        break;
                    }
                }
                break;

            case 6:
                //This is to initialize the pocket only when it's going to be used, in order to save memory
                if (Pocket6 == null)
                {
                    Pocket6 = new int[_diceCast.maxDiceToRoll];
                    for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                    {
                        Pocket6[i] = 0;
                    }
                }
                //Goes through the current pocket and replaces the first 0 it finds with the number added
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket6[i] == 0)
                    {
                        Pocket6[i] = diceNum;
                        ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints);
                        break;
                    }
                }
                break;
        }
    }
    /*
    /// <summary>
    /// This handles removing a number from a pocket
    /// Right now it just removes the first matching number, which isn't correlated with the button itself
    /// This will need some consideration if it'll be a probelm when dice are implemented, but works fine with the way it is now
    /// </summary>
    /// <param name="diceNum"></param>
    public void RemoveFromPocket(int diceNum)
    {
        switch (currentPocket)
        {
            case 1:
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket1[i] == diceNum)
                    {
                        Pocket1[i] = 0; Debug.Log("Dice Removed");
                        ScoreText.text = "Pocketed: $" + CalculatePocketPoints();
                        break;
                    }
                }
                break;

            case 2:
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket2[i] == diceNum)
                    {
                        Pocket2[i] = 0; Debug.Log("Dice Removed");
                        ScoreText.text = "Pocketed: $" + CalculatePocketPoints();
                        break;
                    }
                }
                break;

            case 3:
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket3[i] == diceNum)
                    {
                        Pocket3[i] = 0; Debug.Log("Dice Removed");
                        ScoreText.text = "Pocketed: $" + CalculatePocketPoints();
                        break;
                    }
                }
                break;

            case 4:
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket4[i] == diceNum)
                    {
                        Pocket4[i] = 0; Debug.Log("Dice Removed");
                        ScoreText.text = "Pocketed: $" + CalculatePocketPoints();
                        break;
                    }
                }
                break;

            case 5:
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket5[i] == diceNum)
                    {
                        Pocket5[i] = 0; Debug.Log("Dice Removed");
                        ScoreText.text = "Pocketed: $" + CalculatePocketPoints();
                        break;
                    }
                }
                break;

            case 6:
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket6[i] == diceNum)
                    {
                        Pocket6[i] = 0; Debug.Log("Dice Removed");
                        ScoreText.text = "Pocketed: $" + CalculatePocketPoints();
                        break;
                    }
                }
                break;
        }
    }
    */
    /// <summary>
    /// Gets the score the player earned on whatever pocket they have currently just ended
    /// </summary>
    /// <returns></returns>
    public int CalculatePocketPoints()
    {
        int pocketScore = 0;
        switch (currentPocket)
        {
            case 1:
                pocketScore = _diceCast.PassCalculatedScore(Pocket1);
                break;

            case 2:
                pocketScore = _diceCast.PassCalculatedScore(Pocket2) + _diceCast.PassCalculatedScore(Pocket1);
                break;

            case 3:
                pocketScore = _diceCast.PassCalculatedScore(Pocket3) + _diceCast.PassCalculatedScore(Pocket2) + _diceCast.PassCalculatedScore(Pocket1);
                break;

            case 4:
                pocketScore = _diceCast.PassCalculatedScore(Pocket4) + _diceCast.PassCalculatedScore(Pocket3) + _diceCast.PassCalculatedScore(Pocket2) + _diceCast.PassCalculatedScore(Pocket1);
                break;

            case 5:
                pocketScore = _diceCast.PassCalculatedScore(Pocket5) + _diceCast.PassCalculatedScore(Pocket4) + _diceCast.PassCalculatedScore(Pocket3) + _diceCast.PassCalculatedScore(Pocket2) + _diceCast.PassCalculatedScore(Pocket1);
                break;

            case 6:
                pocketScore = _diceCast.PassCalculatedScore(Pocket6) + _diceCast.PassCalculatedScore(Pocket5) + _diceCast.PassCalculatedScore(Pocket4) + _diceCast.PassCalculatedScore(Pocket3) + _diceCast.PassCalculatedScore(Pocket2) + _diceCast.PassCalculatedScore(Pocket1);
                break;
            default:
                pocketScore = 0;
                break;

        }
        //Debug.Log("Points earned from this pocket: " + pocketScore);
        return pocketScore;
    }

    /// <summary>
    /// Handles Ending a turn and resetting variables for a new turn
    /// </summary>
    public void EndTurn()
    {
        
        ZonkText.SetActive(false);
        _diceCast.ResetDice();
        _diceCast.ResetSpawnOpen();
        playerScore = CalculatePocketPoints();
        playerCachedScore += playerScore + previousPoints;
        playerScore = 0;
        ScoreText.text = "Pocketed: $" + playerScore;
        CachedScoreText.text = "Cached: $" + playerCachedScore;
        currentPocket = 0;
        //Debug.Log("End of turn: " + currentTurn);
        currentTurn++;
        TurnText.text = "Turn: " + currentTurn + "/3";
        diceAdded = 0;
        previousPoints = 0;

        SetPockets();
        if (currentTurn > 3)
        {
            if (playerCachedScore >= quota)
            {
                quota += (int)(1000 + (quota / 2 / 2 * 0.6));
                currentTurn = 1;
                TurnText.text = "Turn: " + currentTurn + "/3";
                QuotaText.text = "Quota: $" + quota;
                //_audioSource.Play();
            }
            else
            {
                SceneManager.LoadScene(3);
            }
        }

        /*if(quota >= 2000)
        {
            uIManager.runesPanel.SetActive(true);
        }*/
        runeUI.ButtonOn();
    }

    public void ZonkOut()
    {
        StartCoroutine(Zonked());
    }

    private IEnumerator Zonked()
    {
        yield return new WaitForSeconds(2f);
        SetPockets();
        playerScore = 0;
        ScoreText.text = "Pocket Total: $" + playerScore;
        for (int i = 0; i < _diceCast.diceToRoll; i++)
        {
            _diceCast.PhysicalDice[i].GetComponent<MeshRenderer>().enabled = false;
        }
        ZonkText.SetActive(true);
    }

}
