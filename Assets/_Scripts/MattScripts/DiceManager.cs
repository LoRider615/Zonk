using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceManager : MonoBehaviour
{
    public DiceRoller[] diceArray;
    public GameObject gameManager;
    private DiceCast diceCast;
    public bool isTutorialMode;
    private Tutorial tutorial;

    private int[] rainbowArray;

    private void Awake()
    {
        diceCast = gameManager.GetComponent<DiceCast>();
        tutorial = FindObjectOfType<Tutorial>();
        rainbowArray = new int[6] { 2, 2, 3, 4, 5, 6 };

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "_Tutorial")
        {
            isTutorialMode = true;
        }
        else if (currentScene == "_Game")
        {
            isTutorialMode = false;
        }
    }

    public void RollAllDice()
    {
        diceCast.DiceArray = null;

        if (!isTutorialMode)
        {
            for (int i = 0; i < diceArray.Length; i++)
            {
                diceArray[i].targetNumber = rainbowArray[i];
                diceArray[i].RollDice();
            }

            //foreach (DiceRoller die in diceArray)
            //{
            //    die.RollDice();  // normal roll
            //}
        }
        else
        {
            for (int i = 0; i < diceArray.Length; i++)
            {
                diceArray[i].targetNumber = tutorial.tutorialValues[i];  // use custom tutorial values
                diceArray[i].RollDice();  // roll with tutorial numbers
            }
        }
    }

    public void EnableTutorial()
    {
        isTutorialMode = true;
    }

    public void DisableTutorial()
    {
        isTutorialMode = false;
    }
}
