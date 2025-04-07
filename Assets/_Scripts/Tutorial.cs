using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public DiceManager diceManager; 
    public int[] tutorialValues;
    public TMP_Text tutorialText;
    public Button castButton;
    public Button endTurnButton;

    private int tutorialStep = 0;

    private void Awake()
    {
        diceManager.isTutorialMode = true;
    }

    void Start()
    {
        tutorialValues = new int[] { 2, 2, 4, 6, 5, 1 };
        tutorialText.text = tutorialMessages[tutorialStep];

        castButton.interactable = false;
        endTurnButton.interactable = false;

        castButton.onClick.AddListener(OnButtonClicked);
        endTurnButton.onClick.AddListener(OnButtonClicked);

        StartCoroutine(EnableButtonsAfterStart());
    }

    private string[] tutorialMessages = new string[]
    {
        "Welcome to Zonk! The goal of this game is to beat the quota, located in the top right. You have 3 turns to beat the quota, otherwise you lose. Tap the 'Cast Dice' button in the bottom left to start.",
        "Tap on a dice to move it to your pocket located at the bottom of the table. 1's are worth 100 points, 5's are worth 50. If a dice is moved to your pocket, you can cast again.",
        "You got a 3 of a kind! It scores 100 times the number on the die. 1's are the exception, scoring 1000. All dice combos can be found in the help menu in the top right. Cast again!",
        "You got a Zonk... A Zonk occurs when you can't score any dice, meaning you can't roll again. You also lose all points in your pocket and end your turn early. Tap 'End Turn' to continue.",
        "Let's try again! Cast the dice. Pay attention to the top right. You are now on your second turn of the quota.",
        "Score the 1 and roll again.",
        "You scored all the dice! That's called a hot cast! You are able to roll again while staying in the same turn. Be careful, as you can risk losing it all.",
        "Score what you can, and then end your turn. Ending your turn allows you to safely cache your points. You don't want to risk Zonking with all of these points in your pocket, right?"
    };

    private int[][] tutorialDiceValues = new int[][]
    {
        new int[] { 3, 3, 3, 4, 0, 0 },
        new int[] { 1, 3, 3, 3, 4, 0 },
        new int[] { 0, 0, 0, 0, 0, 0 },
        new int[] { 1, 2, 3, 4, 5, 6 },
        new int[] { 1, 1, 1, 1, 1, 1 },
        new int[] { 3, 2, 5, 4, 5, 1 }
    };

    void OnButtonClicked()
    {
        tutorialValues = tutorialDiceValues[tutorialStep];

        tutorialStep++;

        castButton.interactable = false;
        endTurnButton.interactable = false;

        StartCoroutine(WaitAndUpdateText());

        Debug.Log("this is step: " + tutorialStep);
    }

    IEnumerator WaitAndUpdateText()
    {
        yield return new WaitForSeconds(4f);

        if (tutorialStep < tutorialMessages.Length)
        {
            tutorialText.text = tutorialMessages[tutorialStep];
        }

        if (tutorialStep == 3)
        {
            castButton.interactable = false;
            endTurnButton.interactable = true;
        }

        if (tutorialStep == 4)
        {
            castButton.interactable = true;
            endTurnButton.interactable = false;
        }
    }

    IEnumerator EnableButtonsAfterStart()
    {
        yield return new WaitForSeconds(1f);
        castButton.interactable = true;
    }
}
