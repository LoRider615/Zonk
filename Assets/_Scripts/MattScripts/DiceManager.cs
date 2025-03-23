using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public DiceRoller[] diceArray;

    // this will have to be changed, as each dice will have it's own desired value
    public void RollAllDice()
    {
        foreach (DiceRoller die in diceArray)
        {
            die.RollDice();
        }
    }
}
