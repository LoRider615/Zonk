using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    private Rigidbody diceRb;
    public int targetNumber;
    private bool isRolling = false;
    public GameObject gameManager;
    private DiceCast diceCast;
    
    public bool scoreable = false;
    public bool selected = false;



    private DiceManager diceManager;

    void Start()
    {
        
        diceRb = GetComponent<Rigidbody>();
        diceCast = gameManager.GetComponent<DiceCast>();
        diceManager = GameObject.FindObjectOfType<DiceManager>();
    }

    private void Update()
    {
        /*
        //if (Input.touchCount > 0)
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
                                if (diceCast.scoreableArray[0])
                                {
                                    for (int i = 0; i < diceCast.diceToRoll; i++)
                                    {
                                        if (diceCast.PocketSpawnOpen[i])
                                        {
                                            diceCast.PhysicalDice[0].transform.position = diceCast.PocketSpawns[i].transform.position;
                                            diceCast.PocketSpawnOpen[i] = false;
                                            pocketHandler.AddToPocket(diceCast.DiceArray[0]);
                                            diceCast.Dice1Clicked = true;
                                            //diceCast.diceToRoll--;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (1)":
                                if (diceCast.scoreableArray[1])
                                {
                                    for (int i = 0; i < diceCast.diceToRoll; i++)
                                    {
                                        if (diceCast.PocketSpawnOpen[i])
                                        {
                                            diceCast.PhysicalDice[1].transform.position = diceCast.PocketSpawns[i].transform.position;
                                            diceCast.PocketSpawnOpen[i] = false;
                                            //diceCast.diceToRoll--;
                                            pocketHandler.AddToPocket(diceCast.DiceArray[1]);
                                            diceCast.Dice2Clicked = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (2)":
                                if (diceCast.scoreableArray[2])
                                {
                                    for (int i = 0; i < diceCast.diceToRoll; i++)
                                    {
                                        if (diceCast.PocketSpawnOpen[i])
                                        {
                                            diceCast.PhysicalDice[2].transform.position = diceCast.PocketSpawns[i].transform.position;
                                            diceCast.PocketSpawnOpen[i] = false;
                                            //diceCast.diceToRoll--;
                                            pocketHandler.AddToPocket(diceCast.DiceArray[2]);
                                            diceCast.Dice3Clicked = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (3)":
                                if (diceCast.scoreableArray[3])
                                {
                                    for (int i = 0; i < diceCast.diceToRoll; i++)
                                    {
                                        if (diceCast.PocketSpawnOpen[i])
                                        {
                                            diceCast.PhysicalDice[3].transform.position = diceCast.PocketSpawns[i].transform.position;
                                            diceCast.PocketSpawnOpen[i] = false;
                                            //diceCast.diceToRoll--;
                                            pocketHandler.AddToPocket(diceCast.DiceArray[3]);
                                            diceCast.Dice4Clicked = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (4)":
                                if (diceCast.scoreableArray[4])
                                {
                                    for (int i = 0; i < diceCast.diceToRoll; i++)
                                    {
                                        if (diceCast.PocketSpawnOpen[i])
                                        {
                                            diceCast.PhysicalDice[4].transform.position = diceCast.PocketSpawns[i].transform.position;
                                            diceCast.PocketSpawnOpen[i] = false;
                                            //diceCast.diceToRoll--;
                                            pocketHandler.AddToPocket(diceCast.DiceArray[4]);
                                            diceCast.Dice5Clicked = true;
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "DiceV2 (5)":
                                if (diceCast.scoreableArray[5])
                                {
                                    for (int i = 0; i < diceCast.diceToRoll; i++)
                                    {
                                        if (diceCast.PocketSpawnOpen[i])
                                        {
                                            diceCast.PhysicalDice[5].transform.position = diceCast.PocketSpawns[i].transform.position;
                                            diceCast.PocketSpawnOpen[i] = false;
                                            //diceCast.diceToRoll--;
                                            pocketHandler.AddToPocket(diceCast.DiceArray[5]);
                                            diceCast.Dice6Clicked = true;
                                            break;
                                        }
                                    }
                                }
                                break;
                        }
                    }

                    



                }
            }
        }
        */

    }

    // i rewrote this btw, should function the same
    public void RollDice()
    {
        if (transform.position.z < 9.1f || gameManager.GetComponent<DiceCast>().hotCast)
        {
            if (gameManager.GetComponent<DiceCast>().hotCast)
            {
                gameManager.GetComponent<DiceCast>().HotCastReset();
            }

            DiceCast diceCast = gameManager.GetComponent<DiceCast>();

            if (!diceManager.isTutorialMode)
            {

                //targetNumber = Random.Range(1, 7);
                //targetNumber = 1;
            }

            isRolling = true;
            StartCoroutine(RollAndStop());
            diceCast.CastDice(targetNumber);
        }
    }

    private IEnumerator RollAndStop()
    {
        // reset dice movement
        diceRb.velocity = Vector3.zero;
        diceRb.angularVelocity = Vector3.zero;

        // apply random force and spin
        diceRb.AddForce(Vector3.up * 15f, ForceMode.Impulse);
        diceRb.AddTorque(Random.insideUnitSphere * 20f, ForceMode.Impulse);

        // wait until the dice slows down
        yield return new WaitForSeconds(1f); // let the dice roll

        // wait until dice is nearly stopped
        while (diceRb.velocity.magnitude > 0.1f || diceRb.angularVelocity.magnitude > 0.1f)
        {
            yield return null;
        }

        // add small final roll (found that it makes it feel a little more natural, gives it a bit of a pop)
        //diceRb.AddTorque(Random.insideUnitSphere * 1f, ForceMode.Impulse);
        //diceRb.AddForce(Vector3.up * 0.5f, ForceMode.Impulse);

        yield return new WaitForSeconds(0.1f); // let the dice roll a bit more

        // now smoothly change to desired face
        StartCoroutine(FinalSettleRotation(targetNumber));
    }

    private IEnumerator FinalSettleRotation(int number)
    {
        Quaternion targetRotation = GetTargetRotation(number);
        Quaternion startRotation = transform.rotation;
        float elapsedTime = 0f;
        float duration = 0.5f; // total time to change to face, more duration means slower turn

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        isRolling = false;
    }

    private Quaternion GetTargetRotation(int number)
    {
        if (number == 1) return Quaternion.Euler(-90, 0, 0);
        if (number == 2) return Quaternion.Euler(0, 0, -90);
        if (number == 3) return Quaternion.Euler(0, 0, 0);
        if (number == 4) return Quaternion.Euler(180, 0, 0);
        if (number == 5) return Quaternion.Euler(0, 0, 90);
        if (number == 6) return Quaternion.Euler(90, 0, 0);
        return Quaternion.identity;
    }
}