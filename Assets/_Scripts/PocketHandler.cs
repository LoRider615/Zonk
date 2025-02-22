using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


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

    public int currentPocket = 1;
    public int currentTurn = 1;

    private DiceCast _diceCast;

    private void Awake()
    {
        //This is part of the above comment on being an outdated variable, safe to ignore this part
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
        _diceCast = this.GetComponent<DiceCast>();

        //Ensures all pockets are empty
        Pocket1 = null; Pocket2 = null; Pocket3 = null; Pocket4 = null; Pocket5 = null; Pocket6 = null;
    }

    /// <summary>
    /// This handles the logic of adding a number to a pocket
    /// </summary>
    /// <param name="diceNum"></param>
    public void AddToPocket(int diceNum)
    {
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
                        break;
                    }
                }
                break;
        }
    }

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
                        Pocket1[i] = 0; Debug.Log("Dice Removed"); break;
                    }
                }
                break;

            case 2:
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket2[i] == diceNum)
                    {
                        Pocket2[i] = 0; Debug.Log("Dice Removed"); break;
                    }
                }
                break;

            case 3:
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket3[i] == diceNum)
                    {
                        Pocket3[i] = 0; Debug.Log("Dice Removed"); break;
                    }
                }
                break;

            case 4:
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket4[i] == diceNum)
                    {
                        Pocket4[i] = 0; Debug.Log("Dice Removed"); break;
                    }
                }
                break;

            case 5:
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket5[i] == diceNum)
                    {
                        Pocket5[i] = 0; Debug.Log("Dice Removed"); break;
                    }
                }
                break;

            case 6:
                for (int i = 0; i < _diceCast.maxDiceToRoll; i++)
                {
                    if (Pocket6[i] == diceNum)
                    {
                        Pocket6[i] = 0; Debug.Log("Dice Removed"); break;
                    }
                }
                break;
        }
    }

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
                pocketScore = _diceCast.PassCalculatedScore(Pocket2);
                break;

            case 3:
                pocketScore = _diceCast.PassCalculatedScore(Pocket3);
                break;

            case 4:
                pocketScore = _diceCast.PassCalculatedScore(Pocket4);
                break;

            case 5:
                pocketScore = _diceCast.PassCalculatedScore(Pocket5);
                break;

            case 6:
                pocketScore = _diceCast.PassCalculatedScore(Pocket6);
                break;

        }
        Debug.Log("Points earned from this pocket: " + pocketScore);
        return pocketScore;
    }

    /// <summary>
    /// Handles Ending a turn and resetting variables for a new turn
    /// </summary>
    public void EndTurn()
    {
        GetComponent<TEMPUI>().EndTurn();
        currentPocket = 1;
        Debug.Log("End of turn: " + currentTurn);
        currentTurn++;
        GetComponent<TEMPUI>().TurnText.text = "Turn: " + currentTurn;
        GetComponent<DiceCast>().diceToRoll = GetComponent<DiceCast>().maxDiceToRoll;
        Pocket1 = null; Pocket2 = null; Pocket3 = null; Pocket4 = null; Pocket5 = null; Pocket6 = null;
    }

}
