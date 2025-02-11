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
    public int[][] PocketHolder = new int[6][];

    public int currentPocket = 1;

    private DiceCast _diceCast;

    private void Awake()
    {
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
        Pocket1 = null; Pocket2 = null; Pocket3 = null; Pocket4 = null; Pocket5 = null; Pocket6 = null;
    }

    public void AddToPocket(int diceNum)
    {
        foreach (var subArray in PocketHolder)
        {
            switch (subArray)
            {
                case var arr when arr == PocketHolder[0]:
                   if (currentPocket == 1)
                    {
                        if (Pocket1 == null)
                        {
                            Pocket1 = new int[_diceCast.diceToRoll];
                            for (int i = 0; i < _diceCast.diceToRoll; i++)
                            {
                                Pocket1[i] = 0;
                            }
                        }
                        for (int i = 0; i < _diceCast.diceToRoll; i++)
                        {
                            if (Pocket1[i] == 0)
                            {
                                Pocket1[i] = diceNum;
                                Debug.Log("Dice Added, pocket updated: ");
                                for (int j = 0; j < 6; j++)
                                {
                                    if (Pocket1[j] != 0)
                                    {
                                        Debug.Log(Pocket1[j] + " ");
                                        break;
                                    }
                                }
                                //Debug.Log("Current Pocket Score:" + _diceCast.passCalculateMaxPotentialScore(Pocket1));
                                break;
                            }
                        }
                        break;
                    }
                    break;

                case var arr when arr == PocketHolder[1]:
                    if (Pocket2 == null)
                    {
                        Pocket2 = new int[_diceCast.diceToRoll];
                        for (int i = 0; i < _diceCast.diceToRoll; i++)
                            Pocket2[i] = 0;
                    }
                    for (int i = 0; i < _diceCast.diceToRoll; i++)
                    {
                        if (Pocket2[i] == 0)
                        {
                            Pocket2[i] = diceNum;
                            break;
                        }
                    }
                    break;

                case var arr when arr == PocketHolder[2]:
                    if (Pocket3 == null)
                    {
                        Pocket3 = new int[_diceCast.diceToRoll];
                        for (int i = 0; i < _diceCast.diceToRoll; i++)
                            Pocket3[i] = 0;
                    }
                    for (int i = 0; i < _diceCast.diceToRoll; i++)
                    {
                        if (Pocket3[i] == 0)
                        {
                            Pocket3[i] = diceNum;
                            break;
                        }
                    }
                    break;

                case var arr when arr == PocketHolder[3]:
                    if (Pocket4 == null)
                    {
                        Pocket4 = new int[_diceCast.diceToRoll];
                        for (int i = 0; i < _diceCast.diceToRoll; i++)
                            Pocket4[i] = 0;
                    }
                    for (int i = 0; i < _diceCast.diceToRoll; i++)
                    {
                        if (Pocket4[i] == 0)
                        {
                            Pocket4[i] = diceNum;
                            break;
                        }
                    }
                    break;

                case var arr when arr == PocketHolder[4]:
                    if (Pocket5 == null)
                    {
                        Pocket5 = new int[_diceCast.diceToRoll];
                        for (int i = 0; i < _diceCast.diceToRoll; i++)
                            Pocket5[i] = 0;
                    }
                    for (int i = 0; i < _diceCast.diceToRoll; i++)
                    {
                        if (Pocket5[i] == 0)
                        {
                            Pocket5[i] = diceNum;
                            break;
                        }
                    }
                    break;

                case var arr when arr == PocketHolder[5]:
                    if (Pocket6 == null)
                    {
                        Pocket6 = new int[_diceCast.diceToRoll];
                        for (int i = 0; i < _diceCast.diceToRoll; i++)
                            Pocket6[i] = 0;
                    }
                    for (int i = 0; i < _diceCast.diceToRoll; i++)
                    {
                        if (Pocket6[i] == 0)
                        {
                            Pocket6[i] = diceNum;
                            break;
                        }
                    }
                    break;
            }
            break;
        }
    }
    

}
