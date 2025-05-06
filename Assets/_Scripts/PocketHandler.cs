using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
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
    public int quota = 500;
    public int diceAdded = 0;
    public int previousPoints = 0;
    
    public int quotaLevel = 0;
    public int highscore = 0;

    public bool mrXLife = false;
    public bool xLifeAlreadyUsed = false;
    public bool evenPocket = false;
    public Button lifeButton;
    public Button castButton;
    public Button endTurnButton;

    private DiceCast _diceCast;

    public AudioSource poof;
    public AudioSource coins;
    public AudioSource _audioSource;
    public TMP_Text ScoreText;
    public TMP_Text CachedScoreText;
    public TMP_Text TurnText;
    public TMP_Text QuotaText;
    public GameObject textOne;
    public GameObject ZonkText;
    public GameObject UIManager;
    public UIManager uiManager;
    public CardManager cardManager;
    public DiceCast diceCast;
    public RunesUI runeUI;
    //public GameObject runesQuota;

    //public UIManager uIManager;

    //grug

    public int playerScore = 0;
    public int playerCachedScore = 0;

    private void Awake()
    {
        lifeButton.interactable = false;
        
        highscore = PlayerPrefs.GetInt("highscore");
        PlayerPrefs.SetInt("score", playerCachedScore);

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

        if (diceAdded % 2 == 0)
            evenPocket = true;
        else
            evenPocket = false;



            poof.Play();

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
                        if (i == 5)
                        {
                            _diceCast.threePairsTrigger = true;

                        }
                            
                        Pocket1[i] = diceNum;
                        if (_diceCast.rainbow)
                        {
                            if (i == 5 && _diceCast.clutchOrKick)
                            {
                                ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints + (2500 / 10));
                                
                            }
                            else if (i == 5)
                            {
                                ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints);
                            }
                        }
                        else if (_diceCast.doubleRainbow1 || _diceCast.doubleRainbow2)
                        {
                            if (i == 4 && _diceCast.clutchOrKick)
                            {
                                ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints + (2000 / 10));
                            }
                            else if (i == 4)
                            {
                                ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints);
                            }
                        }

                        else if (i == 5 && _diceCast.clutchOrKick)
                        {
                            ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints + (CalculatePocketPoints() / 10));
                            _diceCast.clutchIsTrue = true;
                        }
                        else
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
                        if (i == 5 && _diceCast.clutchOrKick)
                        {
                            ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints + (CalculatePocketPoints() / 10));
                            _diceCast.clutchIsTrue = true;
                        }
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
                        if (i == 5 && _diceCast.clutchOrKick)
                        {
                            ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints + (CalculatePocketPoints() / 10));
                            _diceCast.clutchIsTrue = true;
                        }
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
                        if (i == 5 && _diceCast.clutchOrKick)
                        {
                            ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints + (CalculatePocketPoints() / 10));
                            _diceCast.clutchIsTrue = true;
                        }
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
                        if (i == 5 && _diceCast.clutchOrKick)
                        {
                            ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints + (CalculatePocketPoints() / 10));
                            _diceCast.clutchIsTrue = true;
                        }
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
                        if (i == 5 && _diceCast.clutchOrKick)
                        {
                            ScoreText.text = "Pocketed: $" + (CalculatePocketPoints() + previousPoints + (CalculatePocketPoints() / 10));
                            _diceCast.clutchIsTrue = true;
                        }
                        break;
                    }
                }
                break;
        }
        playerScore = CalculatePocketPoints();
        if (playerScore == 0)
        {
            castButton.interactable = false;
            endTurnButton.interactable = false;
        }
        else
        {
            castButton.interactable = true;
            endTurnButton.interactable = true;
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
        PlayerPrefs.SetInt("score", playerCachedScore);
        ZonkText.SetActive(false);
        diceCast.twoOnes = false;
        textOne.SetActive(false);
        _diceCast.ResetDice();
        _diceCast.ResetSpawnOpen();
        
        
        playerScore = CalculatePocketPoints();
        if (_diceCast.clutchIsTrue)
            playerCachedScore += playerScore + previousPoints + (playerScore / 10);
        else if (_diceCast.threePairsTrigger)
            playerCachedScore += playerScore + previousPoints;
        else
            playerCachedScore += playerScore + previousPoints;

        _diceCast.clutchIsTrue = false;
        _diceCast.threePairsTrigger = false;
        playerScore = 0;
        ScoreText.text = "Pocketed: $" + playerScore;
        CachedScoreText.text = "Cached: $" + playerCachedScore;
        currentPocket = 0;
        //Debug.Log("End of turn: " + currentTurn);
        currentTurn++;
        TurnText.text = "Turn: " + currentTurn + "/3";
        diceAdded = 0;
        previousPoints = 0;
        diceCast.finalChanceUsed = false;

        SetPockets();
        if (currentTurn > 3)
        {
            if (playerCachedScore >= quota)
            {
                if (quotaLevel < 3)
                {
                    quota += (int)(500 + (quota / 4 * 0.6));
                }
                else if (quotaLevel < 6)
                {
                    quota += (int)(500 + (quota / 4 * 0.7));
                }
                else if (quotaLevel < 9)
                {
                    quota += (int)(500 + (quota / 4 * 0.8));
                }
                
                //quota += (int)(quota *1.1);
                currentTurn = 1;
                TurnText.text = "Turn: " + currentTurn + "/3";
                QuotaText.text = "Quota: $" + quota;
                xLifeAlreadyUsed = false; // reset extra life

                // update high score
                quotaLevel++;
                PlayerPrefs.SetInt("score", playerCachedScore);

                // open card panel to select from three random cards
                if (cardManager.availableCards.Count > 0)
                {
                    uiManager.ClosePanel();
                    uiManager.OpenCardPanel();
                }

                if (playerCachedScore >= highscore) 
                {
                    PlayerPrefs.SetInt("highscore", playerCachedScore);
                }
                //_audioSource.Play();

                coins.Play();

            }
            else
            {
                SceneManager.LoadScene(3);
            }
        }
        runeUI.ButtonOn();
    }

    public void ZonkOut()
    {
        StartCoroutine(Zonked());
    }

    private IEnumerator Zonked()
    {
        Debug.Log($"Zonked started: mrXLife = {mrXLife}, xLifeAlreadyUsed = {xLifeAlreadyUsed}");
        yield return new WaitForSeconds(2f);
        SetPockets();

        if (mrXLife == true && !xLifeAlreadyUsed)
        {
            Debug.Log("Extra life logic executed");
            ZonkText.SetActive(true);
            lifeButton.interactable = true;
            diceCast.CastDiceButton.interactable = false;
        }
        else
        {
            Debug.Log("No extra life logic executed");
            diceCast.CastDiceButton.interactable = false;
            ScoreText.text = "Pocketed: $" + playerScore;
            for (int i = 0; i < _diceCast.diceToRoll; i++)
            {
                _diceCast.PhysicalDice[i].GetComponent<MeshRenderer>().enabled = false;
            }
            ZonkText.SetActive(true);
            lifeButton.interactable = false;
        }

        /*playerScore = 0;
        ScoreText.text = "Pocket Total: $" + playerScore;
        for (int i = 0; i < _diceCast.diceToRoll; i++)
        {
            _diceCast.PhysicalDice[i].GetComponent<MeshRenderer>().enabled = false;
        }
        ZonkText.SetActive(true);*/
    }

    public void ExtraLife()
    {
        ZonkText.SetActive(false);
        diceCast.CastDiceButton.interactable = true;
        xLifeAlreadyUsed = true;
        Debug.Log($"Extra life activated. Current playerScore: {playerScore}");
    }

    public void IsXLifeActive()
    {
        mrXLife = true;
    }

}
