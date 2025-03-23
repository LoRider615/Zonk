using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public DiceRoller[] diceArray;
    public GameObject gameManager;
    private DiceCast diceCast;

    // this will have to be changed, as each dice will have it's own desired value
    public void RollAllDice()
    {
        diceCast.DiceArray = null;
        foreach (DiceRoller die in diceArray)
        {
            die.RollDice();
        }
    }

    private void Awake()
    {
        diceCast = gameManager.GetComponent<DiceCast>();
    }
}
