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
    public TMP_Text ScoreText;




    public Button CastDiceButton;
    public Button CachePointsButton;

    private bool _buttonAClicked = false;
    private bool _buttonBClicked = false;
    private bool _buttonCClicked = false;
    private bool _buttonDClicked = false;
    private bool _buttonEClicked = false;
    private bool _buttonFClicked = false;

    private void Awake()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].interactable = false;
        }

        
    }

    public void PopulateButtons(int[] myArray)
    {
        for (int i = 0; i < myArray.Length; i++)
        {
            passedArray[i] = myArray[i];
            buttonList[i].GetComponentInChildren<TMP_Text>().text = myArray[i].ToString();
        }
    }
    
    public void EnableButtons(bool[] scoreable)
    {
        for (int i = 0; i < scoreable.Length; i++)
        {
            if (!scoreable[i])
            {
                buttonList[i].interactable = false;
            }
        }
    }

    public void ButtonAClicked()
    {
        if (!_buttonAClicked)
        {
            this.GetComponent<PocketHandler>().AddToPocket(passedArray[0]);
            _buttonAClicked = true;
        }
        else
        {
            this.GetComponent<PocketHandler>().RemoveFromPocket(passedArray[0]);
            _buttonAClicked = false;
        }
        
        //Debug.Log("Num Passed " + passedArray[0]);
    }

    public void ButtonBClicked()
    {
        if (!_buttonBClicked)
        {
            this.GetComponent<PocketHandler>().AddToPocket(passedArray[1]);
            _buttonBClicked = true;
        }
        else
        {
            this.GetComponent<PocketHandler>().RemoveFromPocket(passedArray[1]);
            _buttonBClicked = false;
        }
    }

    public void ButtonCClicked()
    {
        if (!_buttonCClicked)
        {
            this.GetComponent<PocketHandler>().AddToPocket(passedArray[2]);
            _buttonCClicked = true;
        }
        else
        {
            this.GetComponent<PocketHandler>().RemoveFromPocket(passedArray[2]);
            _buttonCClicked = false;
        }
    }

    public void ButtonDClicked()
    {
        if (!_buttonDClicked)
        {
            this.GetComponent<PocketHandler>().AddToPocket(passedArray[3]);
            _buttonDClicked = true;
        }
        else
        {
            this.GetComponent<PocketHandler>().RemoveFromPocket(passedArray[3]);
            _buttonDClicked = false;
        }
    }

    public void ButtonEClicked()
    {
        if (!_buttonEClicked)
        {
            this.GetComponent<PocketHandler>().AddToPocket(passedArray[4]);
            _buttonEClicked = true;
        }
        else
        {
            this.GetComponent<PocketHandler>().RemoveFromPocket(passedArray[4]);
            _buttonEClicked = false;
        }
    }

    public void ButtonFClicked()
    {
        if (!_buttonFClicked)
        {
            this.GetComponent<PocketHandler>().AddToPocket(passedArray[5]);
            _buttonFClicked = true;
        }
        else
        {
            this.GetComponent<PocketHandler>().RemoveFromPocket(passedArray[5]);
            _buttonFClicked = false;
        }
    }

    public void CastDiceClicked()
    {
        for (int i = 0; i < 6; i++)
        {
            buttonList[i].interactable = true;
        }
        CastDiceButton.interactable = false;
        this.GetComponent<DiceCast>().CastDice();
    }

    public void CachePointsClicked()
    {
        playerScore += this.GetComponent<PocketHandler>().CalculatePocketPoints();
        if (_buttonAClicked)
        {
            buttonList[0].interactable = false;
            GetComponent<DiceCast>().diceToRoll--;
        }
        if (_buttonBClicked)
        {
            buttonList[0].interactable = false;
            GetComponent<DiceCast>().diceToRoll--;
        }
        if (_buttonCClicked)
        {
            buttonList[0].interactable = false;
            GetComponent<DiceCast>().diceToRoll--;
        }
        if (_buttonDClicked)
        {
            buttonList[0].interactable = false;
            GetComponent<DiceCast>().diceToRoll--;
        }
        if (_buttonEClicked)
        {
            buttonList[0].interactable = false;
            GetComponent<DiceCast>().diceToRoll--;
        }
        if (_buttonFClicked)
        {
            buttonList[0].interactable = false;
            GetComponent<DiceCast>().diceToRoll--;
        }
        ScoreText.text = "Score: " + playerScore;
        this.GetComponent<PocketHandler>().currentPocket++;
        int[] emptyArr = new int[GetComponent<DiceCast>().diceToRoll];
        PopulateButtons(emptyArr);
        for (int i = 0; i < emptyArr.Length; i++)
        {
            passedArray[i] = emptyArr[i];
            buttonList[i].interactable = false;
        }
        CastDiceButton.interactable = true;

    }


}
