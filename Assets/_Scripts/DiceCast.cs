using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/* Sharkey Logan
 * 2/4/2025
 * This is the script that is going to handle the logic for both casting the dice and calculating the max potential score from a cast (for now, scoring is subject to change)
 */

public class DiceCast : MonoBehaviour
{
    
    public bool rainbow = false;

    private bool threePairs = false;
    public bool threePairsTrigger = false;
    public bool twoOnes = false;
    public bool scoreBuff = false;
    private PocketHandler pocketHandler;
    public Button CastDiceButton;

    [SerializeField]
    public bool finalChance = false;
    public bool finalChanceUsed = false;
    public GameObject finalChanceText;

    public int[] DiceArray;
    public GameObject[] PhysicalDice = new GameObject[6];
    public GameObject[] PocketSpawns = new GameObject[6];
    public GameObject[] TableSpawns = new GameObject[6];
    public GameObject textOne;
    public bool[] scoreableArray = new bool[6];
    public bool[] PocketSpawnOpen = new bool[6];
    public bool hotCast = false;
    public bool snakeEyesActive = false;
    public bool snakeEyesRolled = false;
    public bool m2Active = true;
    public bool clutchOrKick = false;
    public bool clutchIsTrue = false;
    public bool doubleRainbow = false;
    
    public bool duoTwoModifier = false;
    private bool duoTwoIsTrue = false;
    public bool duoThreeModifier = false;
    private bool duoThreeIsTrue = false;
    public bool duoFourModifier = false;
    private bool duoFourIsTrue = false;
    public bool duoSixModifier = false;
    private bool duoSixIsTrue = false;

    public bool doubleRainbow1 = false;
    public bool doubleRainbow2 = false;
    public bool councilOfFive = false;
    public bool evenFlow = false;

    public int diceToRoll = 6;
    public int maxDiceToRoll = 6;

    //currently unimplemented and all scoring is hard-coded, THIS NEEDS TO CHANGE IN THE FUTURE
    public int threeOfAKindMultiplier;
    public int fourOfAKindMultiplier;
    public int fiveOfAKindMultiplier;
    public int sixOfAKindMultiplier;

    public int onesRolled = 0;
    public int twosRolled = 0;
    public int threesRolled = 0;
    public int foursRolled = 0;
    public int fivesRolled = 0;
    public int sixesRolled = 0;
    public int diceStoppedCount = 0;

    public bool hasZonked = false;


    private void Awake()
    {
        ResetSpawnOpen();
        DiceArray = null;
        pocketHandler = GetComponent<PocketHandler>();
        textOne.SetActive(false);

        finalChanceText.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Touch touch = Input.GetTouch(0);
            //Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Vector3 mousPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousPos);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Dice")
                {
                    if (hit.collider.transform.position.z < 9.1f)
                    {
                        switch (hit.collider.name)
                        {
                            case "DiceV2":
                                if (hit.collider.GetComponent<DiceRoller>().scoreable && !hit.collider.GetComponent<DiceRoller>().isRolling)
                                {
                                    for (int i = 0; i < diceToRoll; i++)
                                    {
                                        if (PocketSpawnOpen[i])
                                        {
                                            PhysicalDice[0].transform.position = PocketSpawns[i].transform.position;
                                            PhysicalDice[0].GetComponent<DiceRoller>().selected = true;
                                            PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(PhysicalDice[0].GetComponent<DiceRoller>().targetNumber);
                                            //CastDiceButton.interactable = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (1)":
                                if (hit.collider.GetComponent<DiceRoller>().scoreable && !hit.collider.GetComponent<DiceRoller>().isRolling)
                                {
                                    for (int i = 0; i < diceToRoll; i++)
                                    {
                                        if (PocketSpawnOpen[i])
                                        {
                                            PhysicalDice[1].transform.position = PocketSpawns[i].transform.position;
                                            PhysicalDice[1].GetComponent<DiceRoller>().selected = true;
                                            PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(PhysicalDice[1].GetComponent<DiceRoller>().targetNumber);
                                            //CastDiceButton.interactable = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (2)":
                                if (hit.collider.GetComponent<DiceRoller>().scoreable && !hit.collider.GetComponent<DiceRoller>().isRolling)
                                {
                                    for (int i = 0; i < diceToRoll; i++)
                                    {
                                        if (PocketSpawnOpen[i])
                                        {
                                            PhysicalDice[2].transform.position = PocketSpawns[i].transform.position;
                                            PhysicalDice[2].GetComponent<DiceRoller>().selected = true;
                                            PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(PhysicalDice[2].GetComponent<DiceRoller>().targetNumber);
                                            //CastDiceButton.interactable = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (3)":
                                if (hit.collider.GetComponent<DiceRoller>().scoreable && !hit.collider.GetComponent<DiceRoller>().isRolling)
                                {
                                    for (int i = 0; i < diceToRoll; i++)
                                    {
                                        if (PocketSpawnOpen[i])
                                        {
                                            PhysicalDice[3].transform.position = PocketSpawns[i].transform.position;
                                            PhysicalDice[3].GetComponent<DiceRoller>().selected = true;
                                            PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(PhysicalDice[3].GetComponent<DiceRoller>().targetNumber);
                                            //CastDiceButton.interactable = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (4)":
                                if (hit.collider.GetComponent<DiceRoller>().scoreable && !hit.collider.GetComponent<DiceRoller>().isRolling)
                                {
                                    for (int i = 0; i < diceToRoll; i++)
                                    {
                                        if (PocketSpawnOpen[i])
                                        {
                                            PhysicalDice[4].transform.position = PocketSpawns[i].transform.position;
                                            PhysicalDice[4].GetComponent<DiceRoller>().selected = true;
                                            PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(PhysicalDice[4].GetComponent<DiceRoller>().targetNumber);
                                            //CastDiceButton.interactable = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (5)":
                                if (hit.collider.GetComponent<DiceRoller>().scoreable && !hit.collider.GetComponent<DiceRoller>().isRolling)
                                {
                                    for (int i = 0; i < diceToRoll; i++)
                                    {
                                        if (PocketSpawnOpen[i])
                                        {
                                            PhysicalDice[5].transform.position = PocketSpawns[i].transform.position;
                                            PhysicalDice[5].GetComponent<DiceRoller>().selected = true;
                                            PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(PhysicalDice[5].GetComponent<DiceRoller>().targetNumber);
                                            //CastDiceButton.interactable = true;
                                            break;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    //Switch ends here




                }
            }
        }

        //StartCoroutine(TwoOnes());
    }

    public void CastDice(int diceNum)
    {
        CastDiceButton.interactable = false;
        hasZonked = false;
        threePairs = false;

        snakeEyesRolled = false;
        rainbow = false;
        doubleRainbow1 = false;
        doubleRainbow2 = false;
        duoTwoIsTrue = false;
        duoThreeIsTrue = false;
        duoFourIsTrue = false;
        duoSixIsTrue = false;
        threePairsTrigger = false;

        Debug.Log("Player pocket score before cast: " + pocketHandler.playerScore);

        if (DiceArray == null)
        {
            DiceArray = new int[diceToRoll];
            for (int i = 0; i < DiceArray.Length; i++)
            {
                DiceArray[i] = 0;
                //PhysicalDice[i].GetComponent<DiceRoller>().selected = false;
                PhysicalDice[i].GetComponent<DiceRoller>().scoreable = false;
            }
            pocketHandler.currentPocket++;
        }

        for (int i = 0; i < diceToRoll; i++)
        {
            if (DiceArray[i] == 0)
            {
                DiceArray[i] = diceNum;
                break;
            }
        }
        int j = 0; int selected = 0;
        for (int i = 0; i < diceToRoll; i++)
        {
            if (!PhysicalDice[i].GetComponent<DiceRoller>().selected)
            {
                PhysicalDice[i].GetComponent<DiceRoller>().scoreable = CheckIfScoreable(DiceArray)[j];
                j++;
            }
            else
                selected++;
        }
        CheckIfScoreable(DiceArray);
        StartCoroutine(CountDice());

        
        Debug.Log("Player pocket score: " + pocketHandler.playerScore);

    }

    public int GetAmountOfDiceLeft()
    {
        int amount = 0;
        for (int i = 0; i < DiceArray.Length; i++)
        {
            if (DiceArray[i] > 0)
            {
                amount++;
            }
        }
        return amount;
    }

    public void HotCastReset()
    {
        pocketHandler.previousPoints += pocketHandler.CalculatePocketPoints();
        ResetDice();
        ResetSpawnOpen();
        pocketHandler.SetPockets();
        pocketHandler.currentPocket = 0;
        hotCast = false;
    }

    public IEnumerator CountDice()
    {
        yield return new WaitForSeconds(2);
        int scoreable = 0;
        for (int i = 0; i < diceToRoll; i++)
        {
            if (!PhysicalDice[i].GetComponent<DiceRoller>().selected)
            {
                if (PhysicalDice[i].GetComponent<DiceRoller>().scoreable)
                {
                    scoreable++;
                }
            }
        }
        Debug.Log(scoreable);
        if (scoreable == 0)
        {
            Debug.Log("there are this many dice left on the table: " + GetAmountOfDiceLeft());
            if (finalChance && !finalChanceUsed && GetAmountOfDiceLeft() == 1) // if final chance is on, has not been used this turn, and only one dice left...
            {
                finalChanceUsed = true;
                finalChanceText.SetActive(true);
                CastDiceButton.interactable = true;
            }
            else if (!hasZonked)
            {
                Debug.Log("Final chance already used or not active, so going onto zonk logic");
                hasZonked = true;
                pocketHandler.ZonkOut();
            }
        }
    }

    public void DisableFinalChanceText()
    {
        finalChanceText.SetActive(false);
    }

    /// <summary>
    /// This is a getter function, used mainly for calculating individual pocket scores
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int PassCalculatedScore(int[] arr)
    {
        int score = CalculateMaxPotentialScore(arr);
        //if (clutchIsTrue)
        //return score += (score / 10);
        return score;
    }

    IEnumerator TwoOnes()
    {
        if (twoOnes == true)
        {
            //change line below to instantiate 
            //make text a prefab
            textOne.SetActive(true);
            yield return new WaitForSeconds(3f);
            textOne.SetActive(false);
            //Destroy(textOne.gameObject);
        }
    }

    /// <summary>
    /// Calculates the max potential score in a pocket, right now this code is only partially used, should be implemented so that the player can see the max potential score a pocket has
    /// </summary>
    /// <returns></returns>
    private int CalculateMaxPotentialScore(int[] arr)
    {
        int maxPotentialScore = 0;
        //rainbow = false;
        //threePairs = false;

        onesRolled = 0;
        twosRolled = 0;
        threesRolled = 0;
        foursRolled = 0;
        fivesRolled = 0;
        sixesRolled = 0;

        if (clutchOrKick)
        {
            int numCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                    numCount++;
                if (numCount > 1)
                    break;
                else if (i == 5 && numCount < 1)
                {
                    clutchIsTrue = true;
                }
            }
        }

        //Counting all the numbers from dice rolls 
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
                    //Debug.Log("Warning, roll outside of expected parameters and not counted, num:" + arr[index]);
                    break;
            }
        }

        /*
        if (doubleRainbow)
        {
            if (onesRolled == 0)
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
                                    doubleRainbow1 = true;
                                    scoreBuff = true;
                                    if (scoreBuff == true)
                                    {
                                        maxPotentialScore += 5;
                                    }

                                    maxPotentialScore += 2000;
                                }
                            }
                        }
                    }
                }
            }
            else if (onesRolled == 1)
            {
                if (twosRolled == 1)
                {
                    if (threesRolled == 1)
                    {
                        if (foursRolled == 1)
                        {
                            if (fivesRolled == 1)
                            {
                                if (sixesRolled == 0)
                                {
                                    doubleRainbow2 = true;
                                    scoreBuff = true;
                                    if (scoreBuff == true)
                                    {
                                        maxPotentialScore += 5;
                                    }

                                    maxPotentialScore += 2000;
                                }
                            }
                        }
                    }
                }
            }
        }

        */



        //Checking for Rainbow score condition
        /*
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
                                scoreBuff = true;
                                if(scoreBuff == true)
                                {
                                    maxPotentialScore += 5;
                                }

                                maxPotentialScore += 2500;
                            }
                        }
                    }
                }
            }
        }
        */

        if (rainbow)
        {
            maxPotentialScore += 2500;
            if (scoreBuff)
                maxPotentialScore += 5;
            return maxPotentialScore;
        }
        else if (doubleRainbow1)
            maxPotentialScore += 2000 - 150;
        else if (doubleRainbow2)
            maxPotentialScore += 2000 - 50;

        if (duoTwoIsTrue && pocketHandler.evenPocket)
        {
            maxPotentialScore += 100;
        }

        if (duoThreeIsTrue && pocketHandler.evenPocket)
        {
            maxPotentialScore += 150;
        }

        if (duoFourIsTrue && pocketHandler.evenPocket)
        {
            maxPotentialScore += 200;
        }

        if (duoSixIsTrue && pocketHandler.evenPocket)
        {
            maxPotentialScore += 250;
        }

        //Checking for the 3 pairs score condition
        //while (true)
        //{
        //    if (onesRolled == 2)
        //    {
        //        onePair = true;
        //        //will need to put code below into another if statement to make it only active when the modifier is active
        //        //keep line below here? need to test
        //        twoOnes = true;

        //        if (twoOnes == true)
        //        {
        //            if (snakeEyesActive == true)
        //            {
        //                maxPotentialScore += 200;
        //                StartCoroutine(TwoOnes());
        //                onePair = false; //this might not be doing anything - TEST!
        //                //OH MY GOSH IT FINALLY WORKS!!!!
        //                //THANK YOU SO MUCH FOR YOUR ADVICE, LOGAN!!
        //            }
        //        }
        //    }
        //    if (twosRolled == 2)
        //    {
        //        if (onePair)
        //            twoPair = true;
        //        else
        //            onePair = true;
        //    }
        //    if (threesRolled == 2)
        //    {
        //        if (onePair && twoPair)
        //        {
        //            threePairs = true;
        //            maxPotentialScore += 750;
        //            break;
        //        }
        //        else if (onePair)
        //            twoPair = true;
        //        else
        //            onePair = true;
        //    }
        //    if (foursRolled == 2)
        //    {
        //        if (onePair && twoPair)
        //        {
        //            threePairs = true;
        //            maxPotentialScore += 750;
        //            break;
        //        }
        //        else if (onePair)
        //            twoPair = true;
        //        else
        //            onePair = true;
        //    }
        //    if (fivesRolled == 2)
        //    {
        //        if (onePair && twoPair)
        //        {
        //            threePairs = true;
        //            maxPotentialScore += 750;
        //            break;
        //        }
        //        else if (onePair)
        //            twoPair = true;
        //        else
        //            onePair = true;
        //    }
        //    if (sixesRolled == 2)
        //    {
        //        if (onePair && twoPair)
        //        {
        //            threePairs = true;
        //            maxPotentialScore += 750;
        //            break;
        //        }
        //        else if (onePair)
        //            twoPair = true;
        //        else
        //            onePair = true;
        //    }
        //    break;

        //}

        //Scoring the ones rolled
        if (onesRolled > 0 && !(rainbow || threePairs))
        {
            switch (onesRolled)
            {
                case 1:
                    maxPotentialScore += 100;
                    break;
                case 2:
                    if (snakeEyesRolled)
                    {
                        maxPotentialScore += 400;
                    }
                    else
                        maxPotentialScore += 200;
                    break;
                case 3:
                    maxPotentialScore += 1000;
                    break;
                case 4:
                    maxPotentialScore += 1100;
                    break;
                case 5:
                    maxPotentialScore += 1200;
                    break;
                case 6:
                    maxPotentialScore += 2000;
                    break;
                default:
                    Debug.Log("Number of 1's rolled is over the current limit, please revise");
                    break;
            }
        }

        //Scoring the twos rolled
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

        //scoring the threes rolled
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

        //scoring the fours rolled
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

        //scoring the fives rolled
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
                    maxPotentialScore += 550;
                    break;
                case 5:
                    maxPotentialScore += 600;
                    break;
                case 6:
                    maxPotentialScore += 1000;
                    break;
                default:
                    Debug.Log("Number of 5's rolled is over the current limit, please revise");
                    break;
            }
        }

        //scoring the sixes rolled
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
        
        if (snakeEyesRolled)
        {
           // maxPotentialScore += 200;
            StartCoroutine(TwoOnes());
            //snakeEyesRolled = false;
        }


        if (threePairs && threePairsTrigger)
        {
            maxPotentialScore += 750;
        }
        


        //threePairs = false;
        rainbow = false;

        if (scoreBuff)
        {
            maxPotentialScore += (int)(maxPotentialScore * .05f);
            return maxPotentialScore;
        }



        return maxPotentialScore;
    }


    /// <summary>
    /// Code used to check if a button is scoreable, going to need to be replaced once actual dice are in, but the concept will need to remain
    /// This code disables a button that cannot be scored, so that it cannot be added to the pocket
    /// Returns a boolean array that is parallel to the dice rolling one, also checks if the player Zonks out
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public bool[] CheckIfScoreable(int[] arr)
    {

        onesRolled = 0;
        twosRolled = 0;
        threesRolled = 0;
        foursRolled = 0;
        fivesRolled = 0;
        sixesRolled = 0;


        for (int index = 0; index < arr.Length; index++)
        {
            //It has to go through and check everything again, this is copy pasted code from calc max score above
            //For whatever reason just passing the variables always resets them to 0 so it's kinda unavoidable, if a fix comes to mind, go for it
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
                    //Debug.Log("Warning, roll outside of expected parameters and not counted, num:" + arr[index]);
                    break;
            }
        }


        int unscoreable = 0;
        bool[] scoreable = new bool[diceToRoll];
        int[] scoreCount = new int[diceToRoll];
        bool onePair = false;
        bool twoPair = false;

        //if (duoTwoModifer)
        //{
        //    Debug.Log("duoTwoModifer is active");
        //    if (threesRolled == 2)
        //    {
        //        Debug.Log("there are 2 two's");
        //        for (int i = 0; i < diceToRoll; i++)
        //        {
        //            Debug.Log("I am going to check if dice " + i + "is a a 3");
        //            if (arr[i] == 3)
        //            {
        //                scoreable[i] = true;
        //                duoTwoIsTrue = true;
        //            }
        //        }
        //    }
        //}

        while (true)
        {
            if (onesRolled == 2)
            {
                onePair = true;
                //will need to put code below into another if statement to make it only active when the modifier is active
                //keep line below here? need to test
                twoOnes = true;

                if (twoOnes == true)
                {
                    if (snakeEyesActive == true)
                    {
                        //maxPotentialScore += 200;
                        //StartCoroutine(TwoOnes());
                        snakeEyesRolled = true;
                        onePair = false; //this might not be doing anything - TEST!
                        //OH MY GOSH IT FINALLY WORKS!!!!
                        //THANK YOU SO MUCH FOR YOUR ADVICE, LOGAN!!
                    }
                }
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
                    //maxPotentialScore += 750;
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
                    //maxPotentialScore += 750;
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
                    //maxPotentialScore += 750;
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
                    //maxPotentialScore += 750;
                    break;
                }
                else if (onePair)
                    twoPair = true;
                else
                    onePair = true;
            }
            if (threePairs)
            {
                for (int i = 0; i < diceToRoll; i++)
                {
                    scoreable[i] = true;
                }
            }



            break;

        }

        if (threePairs)
        {
            for (int i = 0; i < diceToRoll; i++)
            {
                scoreable[i] = true;
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
                                scoreBuff = true;
                            }
                        }
                    }
                }
            }
        }

        if (doubleRainbow && !rainbow)
        {
            if (onesRolled >= 1)
            {
                if (twosRolled >= 1)
                {
                    if (threesRolled >= 1)
                    {
                        if (foursRolled >= 1)
                        {
                            if (fivesRolled >= 1)
                            {
                                if (sixesRolled == 0)
                                {
                                    doubleRainbow1 = true;
                                    scoreBuff = true;
                                }
                            }
                        }
                    }
                }
            }
            else if (onesRolled == 0)
            {
                if (twosRolled >= 1)
                {
                    if (threesRolled >= 1)
                    {
                        if (foursRolled >= 1)
                        {
                            if (fivesRolled >= 1)
                            {
                                if (sixesRolled >= 1)
                                {
                                    doubleRainbow2 = true;
                                    scoreBuff = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        if (rainbow)
        {
            for (int i = 0; i < diceToRoll; i++)
            {
                scoreable[i] = true;
            }
        }
        else if (doubleRainbow1)
        {
            for (int i = 0; i < diceToRoll; i++)
            {
                if (arr[i] == 1)
                {
                    scoreable[i] = true;
                    --onesRolled;
                }
                else if (arr[i] == 2 && scoreCount[1] == 0)
                {
                    scoreable[i] = true;
                    scoreCount[1]++;
                    --twosRolled;
                }
                else if (arr[i] == 3 && scoreCount[2] == 0)
                {
                    scoreable[i] = true;
                    scoreCount[2]++;
                    --threesRolled;
                }
                else if (arr[i] == 4 && scoreCount[3] == 0)
                {
                    scoreable[i] = true;
                    scoreCount[3]++;
                    --foursRolled;
                }
                else if (arr[i] == 5)
                {
                    scoreable[i] = true;
                    --fivesRolled;
                }
                else { scoreable[i] = false; }
            }
        }
        else if (doubleRainbow2)
        {
            for (int i = 0; i < diceToRoll; i++)
            {
                if (arr[i] == 2 && scoreCount[1] == 0)
                {
                    scoreable[i] = true;
                    scoreCount[1]++;
                    --twosRolled;
                }
                else if (arr[i] == 3 && scoreCount[2] == 0)
                {
                    scoreable[i] = true;
                    scoreCount[2]++;
                    --threesRolled;
                }
                else if (arr[i] == 4 && scoreCount[3] == 0)
                {
                    scoreable[i] = true;
                    scoreCount[3]++;
                    --foursRolled;
                }
                else if (arr[i] == 5)
                {
                    scoreable[i] = true;
                    --fivesRolled;
                }
                else if (arr[i] == 6 && scoreCount[5] == 0)
                {
                    scoreable[i] = true;
                    scoreCount[5]++;
                    --sixesRolled;

                }
            }
        }
        



        //Methodically goes through and dynamically checks for scoring numbers, 
        else if (!threePairs)
        {
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
                else if (twosRolled == 2 && duoTwoModifier) // check for duo 2 modifier scoring
                {
                    if (arr[i] == 2)
                    {
                        scoreable[i] = true;
                        duoTwoIsTrue = true;
                    }
                }
                if (threesRolled >= 3)
                {
                    if (arr[i] == 3)
                        scoreable[i] = true;
                }
                else if (threesRolled == 2 && duoThreeModifier) // check for duo 3 modifier scoring
                {
                    if (arr[i] == 3)
                    {
                        scoreable[i] = true;
                        duoThreeIsTrue = true;
                    }
                }
                if (foursRolled >= 3)
                {
                    if (arr[i] == 4)
                        scoreable[i] = true;
                }
                else if (foursRolled == 2 && duoFourModifier) // check for duo 4 modifier scoring
                {
                    if (arr[i] == 4)
                    {
                        scoreable[i] = true;
                        duoFourIsTrue = true;
                    }
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
                else if (sixesRolled == 2 && duoSixModifier) // check for duo 6 modifier scoring
                {
                    if (arr[i] == 6)
                    {
                        scoreable[i] = true;
                        duoSixIsTrue = true;
                    }
                }
                if (arr[i] == 0)
                {
                    scoreable[i] = false;
                }
                else
                    unscoreable++;

            }
        }
                
            //Debug.Log(unscoreable);
            //Zonk Detection
            /*
            if (unscoreable == diceToRoll)
            {
                //GetComponent<PocketHandler>().ZonkOut();
                return null;
            }
            */
        
        return scoreable;
    }

    public void ResetSpawnOpen()
    {
        PocketSpawnOpen[0] = true;
        PocketSpawnOpen[1] = true;
        PocketSpawnOpen[2] = true;
        PocketSpawnOpen[3] = true;
        PocketSpawnOpen[4] = true;
        PocketSpawnOpen[5] = true;
    }

    public void ResetDice()
    {
        Debug.Log("Resetting the dice");
        for (int i = 0; i < maxDiceToRoll; i++)
        {
            PhysicalDice[i].transform.position = TableSpawns[i].transform.position;
            PhysicalDice[i].GetComponent<MeshRenderer>().enabled = true;
            PhysicalDice[i].GetComponent<DiceRoller>().selected = false;
            PhysicalDice[i].GetComponent<DiceRoller>().scoreable = false;
        }
        CastDiceButton.interactable = true;

        hasZonked = false;
    }

    //if troubles, may need to figure out once the button has been pressed, this is true forever 
    public void SerpentButton()
    {
        snakeEyesActive = true;
        
        //serpentsStare == true;
        //maybe it's set active true?
    }

}