using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TEMPUI : MonoBehaviour
{
    public Button[] buttonList = new Button[6];
    int[] passedArray = new int[6];
    public int playerScore = 0;
    public int playerCachedScore = 0;
    

    public TMP_Text ScoreText;
    public TMP_Text CachedScoreText;
    public TMP_Text TurnText;
    public TMP_Text QuotaText;

    public Button CastDiceButton;
    public Button CachePointsButton;
    public Button EndTurnButton;

    /*
    private bool _buttonAClicked = false;
    private bool _buttonBClicked = false;
    private bool _buttonCClicked = false;
    private bool _buttonDClicked = false;
    private bool _buttonEClicked = false;
    private bool _buttonFClicked = false;
    */

    private void Awake()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].interactable = false;
        }
    }

    /// <summary>
    /// Fills the buttons with their respective numbers
    /// </summary>
    /// <param name="myArray"></param>
    public void PopulateButtons(int[] myArray)
    {
        for (int i = 0; i < GetComponent<DiceCast>().maxDiceToRoll; i++)
        {
            passedArray[i] = myArray[i];
            buttonList[i].GetComponentInChildren<TMP_Text>().text = myArray[i].ToString();
        }
        EnableButtons(GetComponent<DiceCast>().CheckIfScoreable(myArray));
        /*
        _buttonAClicked = false;
        _buttonBClicked = false;
        _buttonCClicked = false;
        _buttonDClicked = false;
        _buttonEClicked = false;
        _buttonFClicked = false;
        */
    }
    
    /// <summary>
    /// Enables only the buttons that having scoring numbers on them
    /// </summary>
    /// <param name="scoreable"></param>
    public void EnableButtons(bool[] scoreable)
    {
        if (scoreable.Length > 0)
        {
            for (int i = 0; i < scoreable.Length; i++)
            {
                if (!scoreable[i])
                {
                    buttonList[i].interactable = false;
                }
            }
        }
    }

    /*
    public void ButtonAClicked()
    {
        
        if (!_buttonAClicked)
        {
            this.GetComponent<PocketHandler>().AddToPocket(passedArray[0]);
            _buttonAClicked = true;
            buttonList[0].image.color = Color.green;
        }
        else
        {
            this.GetComponent<PocketHandler>().RemoveFromPocket(passedArray[0]);
            _buttonAClicked = false;
            buttonList[0].image.color = Color.white;
        }
        
        //Debug.Log("Num Passed " + passedArray[0]);
    }

    public void ButtonBClicked()
    {
        if (!_buttonBClicked)
        {
            this.GetComponent<PocketHandler>().AddToPocket(passedArray[1]);
            _buttonBClicked = true;
            buttonList[1].image.color = Color.green;
        }
        else
        {
            this.GetComponent<PocketHandler>().RemoveFromPocket(passedArray[1]);
            _buttonBClicked = false;
            buttonList[1].image.color = Color.white;
        }
    }

    public void ButtonCClicked()
    {
        if (!_buttonCClicked)
        {
            this.GetComponent<PocketHandler>().AddToPocket(passedArray[2]);
            _buttonCClicked = true;
            buttonList[2].image.color = Color.green;
        }
        else
        {
            this.GetComponent<PocketHandler>().RemoveFromPocket(passedArray[2]);
            _buttonCClicked = false;
            buttonList[2].image.color = Color.white;
        }
    }

    public void ButtonDClicked()
    {
        if (!_buttonDClicked)
        {
            this.GetComponent<PocketHandler>().AddToPocket(passedArray[3]);
            _buttonDClicked = true;
            buttonList[3].image.color = Color.green;
        }
        else
        {
            this.GetComponent<PocketHandler>().RemoveFromPocket(passedArray[3]);
            _buttonDClicked = false;
            buttonList[3].image.color = Color.white;
        }
    }

    public void ButtonEClicked()
    {
        if (!_buttonEClicked)
        {
            this.GetComponent<PocketHandler>().AddToPocket(passedArray[4]);
            _buttonEClicked = true;
            buttonList[4].image.color = Color.green;
        }
        else
        {
            this.GetComponent<PocketHandler>().RemoveFromPocket(passedArray[4]);
            _buttonEClicked = false;
            buttonList[4].image.color = Color.white;
        }
    }

    public void ButtonFClicked()
    {
        if (!_buttonFClicked)
        {
            this.GetComponent<PocketHandler>().AddToPocket(passedArray[5]);
            _buttonFClicked = true;
            buttonList[5].image.color = Color.green;
        }
        else
        {
            this.GetComponent<PocketHandler>().RemoveFromPocket(passedArray[5]);
            _buttonFClicked = false;
            buttonList[5].image.color = Color.white;
        }
    }
    */

    /// <summary>
    /// Rolls the proverbial dice when the button is clicked
    /// </summary>
    public void CastDiceClicked()
    {
        for (int i = 0; i < 6; i++)
        {
            buttonList[i].interactable = true;
        }
        EndTurnButton.interactable = false;
        CastDiceButton.interactable = false;
        CachePointsButton.interactable = true;
        //this.GetComponent<DiceCast>().CastDice();
    }

    /// <summary>
    /// End of turn cleanup, adds points, reduces dice to roll, fills the buttons with 0's and preps for the next move
    /// </summary>
    public void CachePointsClicked()
    {
        EndTurnButton.interactable = true;

        playerScore += this.GetComponent<PocketHandler>().CalculatePocketPoints();

        /*
        if (_buttonAClicked)
            GetComponent<DiceCast>().diceToRoll--;
        
        if (_buttonBClicked)
            GetComponent<DiceCast>().diceToRoll--;

        if (_buttonCClicked)
            GetComponent<DiceCast>().diceToRoll--;
        
        if (_buttonDClicked)
            GetComponent<DiceCast>().diceToRoll--;
        
        if (_buttonEClicked)
            GetComponent<DiceCast>().diceToRoll--;
        
        if (_buttonFClicked)
            GetComponent<DiceCast>().diceToRoll--;
        */
        

        ScoreText.text = "Pocket Total: $" + playerScore;

        int[] emptyArr = new int[GetComponent<DiceCast>().maxDiceToRoll];
        if (GetComponent<DiceCast>().diceToRoll <= 0 )
        {
            PopulateButtons(emptyArr);
        }

        this.GetComponent<PocketHandler>().currentPocket++;
        PopulateButtons(emptyArr);

        for (int i = 0; i < emptyArr.Length; i++)
        {
            passedArray[i] = emptyArr[i];
            buttonList[i].interactable = false;
        }

        CastDiceButton.interactable = true;

        // Clears color for each button
        for (int i = 0; i < 6; i++)
        {
            buttonList[i].image.color = Color.white;
        }

    }

    /// <summary>
    /// Handles all of the changes that come with a turn ending, updates player's scores
    /// </summary>
    public void EndTurn()
    {
        playerCachedScore += playerScore;
        playerScore = 0;
        ScoreText.text = "Pocket Total: $" + playerScore;
        CachedScoreText.text = "Cached: $" + playerCachedScore;
        CastDiceButton.interactable = true;
    }

    /// <summary>
    /// Code for when the player has no dice left that can be scored, resulting in a Zonk
    /// </summary>
    public void ZonkOut()
    {
        for (int i = 0;i < GetComponent<DiceCast>().maxDiceToRoll; i++)
        {
            buttonList[i].interactable = false;
        }
        CachePointsButton.interactable = false;
        CastDiceButton.interactable= false;
        EndTurnButton.interactable= true;
        playerScore = 0;
        ScoreText.text = "Pocket Total: $" + playerScore;


    }





}
