using System.Collections;
using UnityEngine;

/* Sharkey Logan
 * 2/4/2025
 * This is the script that is going to handle the logic for both casting the dice and calculating the max potential score from a cast (for now, scoring is subject to change)
 */

public class DiceCast : MonoBehaviour
{
    private bool rainbow = false;
    private bool threePairs = false;

    public int diceToRoll;
    public int threeOfAKindMultiplier;
    public int fourOfAKindMultiplier;
    public int fiveOfAKindMultiplier;
    public int sixOfAKindMultiplier;

    public void CastDice()
    {
        int[] CastList = new int[diceToRoll];
        for (int index = 0; index < diceToRoll; index++)
        {
            CastList[index] = Random.Range(1, 7);
            //Debug.Log(CastList[index]);
        }
        this.GetComponent<TEMPUI>().PopulateButtons(CastList);

        Debug.Log("Max potential score from cast: " + CalculateMaxPotentialScore(CastList));
    }

    public int PassCalculatedScore(int[] arr)
    {
        return CalculateMaxPotentialScore(arr);
    }

    /// <summary>
    /// Calculates the max potential score only from a roll currently, but is likely to change in the future to accommodate pockets
    /// </summary>
    /// <returns></returns>
    private int CalculateMaxPotentialScore(int[] arr)
    {
        int maxPotentialScore = 0;

        bool onePair = false;
        bool twoPair = false;
        int onesRolled = 0;
        int twosRolled = 0;
        int threesRolled = 0;
        int foursRolled = 0;
        int fivesRolled = 0;
        int sixesRolled = 0;

        for (int index = 0; index < arr.Length; index++)
        {
            switch (arr[index])
            {
                case 1:
                    onesRolled++;
                    break;
                case 2:
                    twosRolled++;
                    break;
                case 3:
                    threesRolled++;
                    break;
                case 4:
                    foursRolled++;
                    break;
                case 5:
                    fivesRolled++;
                    break;
                case 6:
                    sixesRolled++;
                    break;
                default:
                    Debug.Log("Warning, roll outside of expected parameters and not counted");
                    break;
            }
        }




        if (onesRolled == 1)
        {
            if (twosRolled == 1)
            {
                if (threesRolled == 1)
                {
                    if (foursRolled == 1)
                    {
                        if (fivesRolled == 1)
                        {
                            if (sixesRolled == 1)
                            {
                                rainbow = true;
                                maxPotentialScore += 2500;
                            }
                        }
                    }
                }
            }
        }
        while (true)
        {
            if (onesRolled == 2)
            {
                onePair = true;
            }
            if (twosRolled == 2)
            {
                if (onePair)
                    twoPair = true;
                else
                    onePair = true;
            }
            if (threesRolled == 2)
            {
                if (onePair && twoPair)
                {
                    threePairs = true;
                    maxPotentialScore += 750;
                    break;
                }
                else if (onePair)
                    twoPair = true;
                else
                    onePair = true;
            }
            if (foursRolled == 2)
            {
                if (onePair && twoPair)
                {
                    threePairs = true;
                    maxPotentialScore += 750;
                    break;
                }
                else if (onePair)
                    twoPair = true;
                else
                    onePair = true;
            }
            if (fivesRolled == 2)
            {
                if (onePair && twoPair)
                {
                    threePairs = true;
                    maxPotentialScore += 750;
                    break;
                }
                else if (onePair)
                    twoPair = true;
                else
                    onePair = true;
            }
            if (sixesRolled == 2)
            {
                if (onePair && twoPair)
                {
                    threePairs = true;
                    maxPotentialScore += 750;
                    break;
                }
                else if (onePair)
                    twoPair = true;
                else
                    onePair = true;
            }
            break;

        }
        
        if (!threePairs && !rainbow)
        {
            bool[] scoreable = new bool[diceToRoll];
            for (int i = 0; i < diceToRoll; i++)
            {
                scoreable[i] = false;

                if (arr[i] == 1 || arr[i] == 5)
                    scoreable[i] = true;

                if (twosRolled >= 3)
                {
                    if (arr[i] == 2)
                        scoreable[i] = true;
                }
                if (threesRolled >= 3)
                {
                    if (arr[i] == 3)
                        scoreable[i] = true;
                }
                if (foursRolled >= 3)
                {
                    if (arr[i] == 4)
                        scoreable[i] = true;
                }
                if (fivesRolled >= 3)
                {
                    if (arr[i] == 5)
                        scoreable[i] = true;
                }
                if (sixesRolled >= 3)
                {
                    if (arr[i] == 6)
                        scoreable[i] = true;
                }
            }
            this.GetComponent<TEMPUI>().EnableButtons(scoreable);
            
        }


        if (onesRolled > 0 && !(rainbow || threePairs))
        {
            switch (onesRolled)
            {
                case 1:
                    maxPotentialScore += 100;
                    break;
                case 2:
                    maxPotentialScore += 200;
                    break;
                case 3:
                    maxPotentialScore += 1000;
                    break;
                case 4:
                    maxPotentialScore += 2000;
                    break;
                case 5:
                    maxPotentialScore += 4000;
                    break;
                case 6:
                    maxPotentialScore += 6000;
                    break;
                default:
                    Debug.Log("Number of 1's rolled is over the current limit, please revise");
                    break;
            }
        }
        if (twosRolled > 0 && !(rainbow || threePairs))
        {
            switch (twosRolled)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    maxPotentialScore += 200;
                    break;
                case 4:
                    maxPotentialScore += 400;
                    break;
                case 5:
                    maxPotentialScore += 800;
                    break;
                case 6:
                    maxPotentialScore += 1200;
                    break;
                default:
                    Debug.Log("Number of 2's rolled is over the current limit, please revise");
                    break;
            }
        }
        if (threesRolled > 0 && !(rainbow || threePairs))
        {
            switch (threesRolled)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    maxPotentialScore += 300;
                    break;
                case 4:
                    maxPotentialScore += 600;
                    break;
                case 5:
                    maxPotentialScore += 1200;
                    break;
                case 6:
                    maxPotentialScore += 1800;
                    break;
                default:
                    Debug.Log("Number of 3's rolled is over the current limit, please revise");
                    break;
            }
            
        }
        if (foursRolled > 0 && !(rainbow || threePairs))
        {
            switch (foursRolled)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    maxPotentialScore += 400;
                    break;
                case 4:
                    maxPotentialScore += 800;
                    break;
                case 5:
                    maxPotentialScore += 1600;
                    break;
                case 6:
                    maxPotentialScore += 2400;
                    break;
                default:
                    Debug.Log("Number of 4's rolled is over the current limit, please revise");
                    break;
            }
        }
        if (fivesRolled > 0 && !(rainbow || threePairs))
        {
            switch (fivesRolled)
            {
                case 1:
                    maxPotentialScore += 50;
                    break;
                case 2:
                    maxPotentialScore += 100;
                    break;
                case 3:
                    maxPotentialScore += 500;
                    break;
                case 4:
                    maxPotentialScore += 1000;
                    break;
                case 5:
                    maxPotentialScore += 2000;
                    break;
                case 6:
                    maxPotentialScore += 3000;
                    break;
                default:
                    Debug.Log("Number of 5's rolled is over the current limit, please revise");
                    break;
            }
        }
        if (sixesRolled > 0 && !(rainbow || threePairs))
        {
            switch (sixesRolled)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    maxPotentialScore += 600;
                    break;
                case 4:
                    maxPotentialScore += 1200;
                    break;
                case 5:
                    maxPotentialScore += 2400;
                    break;
                case 6:
                    maxPotentialScore += 3600;
                    break;
                default:
                    Debug.Log("Number of 4's rolled is over the current limit, please revise");
                    break;
            }
        }
        threePairs = false;
        rainbow = false;

        return maxPotentialScore;
    }



}