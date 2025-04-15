using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/* Sharkey Logan
 * 2/4/2025
 * This is the script that is going to handle the logic for both casting the dice and calculating the max potential score from a cast (for now, scoring is subject to change)
 */

public class DiceCast : MonoBehaviour
{
    private bool rainbow = false;
    private bool threePairs = false;
    private bool twoOnes = false;
    private bool scoreBuff = false;
    private PocketHandler pocketHandler;
    public Button CastDiceButton;

    [SerializeField]
    private bool finalChance = false;

    public int[] DiceArray;
    public GameObject[] PhysicalDice = new GameObject[6];
    public GameObject[] PocketSpawns = new GameObject[6];
    public GameObject[] TableSpawns = new GameObject[6];
    public GameObject textOne;
    public bool[] scoreableArray = new bool[6];
    public bool[] PocketSpawnOpen = new bool[6];
    public bool hotCast = false;

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


    private void Awake()
    {
        ResetSpawnOpen();
        DiceArray = null;
        pocketHandler = GetComponent<PocketHandler>();
        textOne.SetActive(false);
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
                                if (hit.collider.GetComponent<DiceRoller>().scoreable)
                                {
                                    for (int i = 0; i < diceToRoll; i++)
                                    {
                                        if (PocketSpawnOpen[i])
                                        {
                                            PhysicalDice[0].transform.position = PocketSpawns[i].transform.position;
                                            PhysicalDice[0].GetComponent<DiceRoller>().selected = true;
                                            PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(PhysicalDice[0].GetComponent<DiceRoller>().targetNumber);
                                            CastDiceButton.interactable = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (1)":
                                if (hit.collider.GetComponent<DiceRoller>().scoreable)
                                {
                                    for (int i = 0; i < diceToRoll; i++)
                                    {
                                        if (PocketSpawnOpen[i])
                                        {
                                            PhysicalDice[1].transform.position = PocketSpawns[i].transform.position;
                                            PhysicalDice[1].GetComponent<DiceRoller>().selected = true;
                                            PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(PhysicalDice[1].GetComponent<DiceRoller>().targetNumber);
                                            CastDiceButton.interactable = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (2)":
                                if (hit.collider.GetComponent<DiceRoller>().scoreable)
                                {
                                    for (int i = 0; i < diceToRoll; i++)
                                    {
                                        if (PocketSpawnOpen[i])
                                        {
                                            PhysicalDice[2].transform.position = PocketSpawns[i].transform.position;
                                            PhysicalDice[2].GetComponent<DiceRoller>().selected = true;
                                            PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(PhysicalDice[2].GetComponent<DiceRoller>().targetNumber);
                                            CastDiceButton.interactable = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (3)":
                                if (hit.collider.GetComponent<DiceRoller>().scoreable)
                                {
                                    for (int i = 0; i < diceToRoll; i++)
                                    {
                                        if (PocketSpawnOpen[i])
                                        {
                                            PhysicalDice[3].transform.position = PocketSpawns[i].transform.position;
                                            PhysicalDice[3].GetComponent<DiceRoller>().selected = true;
                                            PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(PhysicalDice[3].GetComponent<DiceRoller>().targetNumber);
                                            CastDiceButton.interactable = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (4)":
                                if (hit.collider.GetComponent<DiceRoller>().scoreable)
                                {
                                    for (int i = 0; i < diceToRoll; i++)
                                    {
                                        if (PocketSpawnOpen[i])
                                        {
                                            PhysicalDice[4].transform.position = PocketSpawns[i].transform.position;
                                            PhysicalDice[4].GetComponent<DiceRoller>().selected = true;
                                            PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(PhysicalDice[4].GetComponent<DiceRoller>().targetNumber);
                                            CastDiceButton.interactable = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (5)":
                                if (hit.collider.GetComponent<DiceRoller>().scoreable)
                                {
                                    for (int i = 0; i < diceToRoll; i++)
                                    {
                                        if (PocketSpawnOpen[i])
                                        {
                                            PhysicalDice[5].transform.position = PocketSpawns[i].transform.position;
                                            PhysicalDice[5].GetComponent<DiceRoller>().selected = true;
                                            PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(PhysicalDice[5].GetComponent<DiceRoller>().targetNumber);
                                            CastDiceButton.interactable = true;
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

        for (int i = 0;i < diceToRoll; i++)
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

        StartCoroutine(CountDice());

        CastDiceButton.interactable = false;
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
            if (finalChance)
            {
                finalChance = false;
                CastDiceButton.interactable = true;
            }
            else
                pocketHandler.ZonkOut();
    }



    /// <summary>
    /// This is a getter function, used mainly for calculating individual pocket scores
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int PassCalculatedScore(int[] arr)
    {
        return CalculateMaxPotentialScore(arr);
    }

    IEnumerator TwoOnes()
    {
        if(twoOnes == true)
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
        rainbow = false;
        threePairs = false;
        bool onePair = false;
        bool twoPair = false;
        onesRolled = 0;
        twosRolled = 0;
        threesRolled = 0;
        foursRolled = 0;
        fivesRolled = 0;
        sixesRolled = 0;


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
        



        //Checking for Rainbow score condition
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

        //Checking for the 3 pairs score condition
        while (true)
        {
            if (onesRolled == 2)
            {
                onePair = true;
                //will need to put code below into another if statement to make it only active when the modifier is active
                //keep line below here? need to test
                twoOnes = true;

                /*if(twoOnes == true)
                {
                    maxPotentialScore += 200;
                    StartCoroutine(TwoOnes());
                }*/
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

        //Scoring the ones rolled
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
        threePairs = false;
        rainbow = false;

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

        //Methodically goes through and dynamically checks for scoring numbers, 
        int unscoreable = 0;
        bool[] scoreable = new bool[diceToRoll];
        for (int i = 0; i < diceToRoll; i++)
        {
            scoreable[i] = false;

            if (arr[i] == 1 || arr[i] == 5)
                scoreable[i] = true;

            else if (twosRolled >= 3)
            {
                if (arr[i] == 2)
                    scoreable[i] = true;
            }
            else if (threesRolled >= 3)
            {
                if (arr[i] == 3)
                    scoreable[i] = true;
            }
            else if (foursRolled >= 3)
            {
                if (arr[i] == 4)
                    scoreable[i] = true;
            }
            else if (fivesRolled >= 3)
            {
                if (arr[i] == 5)
                    scoreable[i] = true;
            }
            else if (sixesRolled >= 3)
            {
                if (arr[i] == 6)
                    scoreable[i] = true;
            }
            else if (arr[i] == 0)
            {
                scoreable[i] = false;
            }
            else
                unscoreable++;

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
        for (int i = 0; i < maxDiceToRoll; i++)
        {
            PhysicalDice[i].transform.position = TableSpawns[i].transform.position;
            PhysicalDice[i].GetComponent<MeshRenderer>().enabled = true;
            PhysicalDice[i].GetComponent<DiceRoller>().selected = false;
            PhysicalDice[i].GetComponent<DiceRoller>().scoreable = false;
        }
        CastDiceButton.interactable = true;
    }

    //if troubles, may need to figure out once the button has been pressed, this is true forever 
    public void SerpentButton()
    {
        //serpentsStare == true;
        //maybe it's set active true?
    }

}