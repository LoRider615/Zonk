using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public DiceRoller[] diceArray;
    public GameObject gameManager;
    private DiceCast diceCast;
    public bool isTutorialMode;
    private Tutorial tutorial;

    public void RollAllDice()
    {
        diceCast.DiceArray = null;

        if (!isTutorialMode)
        {
            foreach (DiceRoller die in diceArray)
            {
                die.RollDice();  // normal roll
            }
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

    private void Awake()
    {
        diceCast = gameManager.GetComponent<DiceCast>();
        tutorial = FindObjectOfType<Tutorial>();
    }
}
