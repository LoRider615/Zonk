using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public DiceManager diceManager; 
    public UIManager uiManager;
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
        "1's are worth 100 points, 5's are worth 50. Tap on a dice to move it to your pocket, located at the bottom of the table. If a dice is moved to your pocket, you can cast again.",
        "You got a 3 of a kind! It scores 100 times the number on the die. 1's are the exception, scoring 1000. All dice combos can be found in the help menu in the top right. Cast again!",
        "You got a Zonk... A Zonk occurs when you can't score any dice, meaning you can't cast again. You also lose all points in your pocket and end your turn early. Tap 'End Turn' to continue.",
        "Let's try again! Cast the dice. Pay attention to the top right. You are now on your second turn of the quota.",
        "Score what you can and cast again.",
        "You can score all of the dice! That's called a Hot Cast! You are able to cast again while staying in the same turn. Be careful, as you can risk losing it all.",
        "Score what you can, and then end your turn. Ending your turn allows you to safely cache your points. You don't want to risk Zonking with all of these points in your pocket, right?",
        "You are now on your last turn, though you are way over of the quota. Feel free to cast, score any dice, and end your turn early.",
        "This marks the end of the tutorial! feel free to press the Settings button in the top left to return to the main menu. Press 'End Turn' to close this menu."
    };

    private int[][] tutorialDiceValues = new int[][]
    {
        new int[] { 3, 3, 3, 4, 0, 0 },
        new int[] { 1, 3, 3, 3, 4, 0 },
        new int[] { 4, 0, 0, 0, 0, 0 },
        new int[] { 1, 2, 3, 4, 6, 6 },
        new int[] { 5, 5, 5, 5, 5, 5 },
        new int[] { 3, 2, 5, 4, 5, 1 },
        new int[] { 4, 4, 5, 6, 1, 2 },
        new int[] { 1, 2, 5, 1, 2, 5 },
        new int[] { 6, 5, 5, 1, 3, 2 },
        new int[] { 6, 5, 5, 1, 3, 2 },
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

        if (tutorialStep == 7)
        {
            castButton.interactable = false;
            endTurnButton.interactable = true;
        }

        if (tutorialStep == 8)
        {
            castButton.interactable = true;
            endTurnButton.interactable = true;
        }

        if (tutorialStep == 9)
        {
            castButton.interactable = true;
            endTurnButton.interactable = true;
        }

        if (tutorialStep == 10)
        {
            castButton.interactable = true;
            endTurnButton.interactable = true;
            uiManager.ClosePanel();
        }
    }

    IEnumerator EnableButtonsAfterStart()
    {
        yield return new WaitForSeconds(1f);
        castButton.interactable = true;
    }
}
