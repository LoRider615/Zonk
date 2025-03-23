using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    private Rigidbody diceRb;
    private int targetNumber;
    private bool isRolling = false;
    public GameObject gameManager;
    private DiceCast diceCast;

    public bool[] PocketSpawnOpen = new bool[6];
    public Transform[] previousLocations = new Transform[6];

    void Start()
    {
        diceRb = GetComponent<Rigidbody>();
        diceCast = gameManager.GetComponent<DiceCast>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Dice")
                {
                    switch (hit.collider.name)
                    {
                        case "DiceV2":
                            if (diceCast.scoreableArray[0])
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    if (PocketSpawnOpen[i])
                                    {
                                        previousLocations[0].position = diceCast.PhysicalDice[0].transform.position;
                                        diceCast.PhysicalDice[0].transform.position = diceCast.PocketSpawns[i].transform.position;
                                        PocketSpawnOpen[i] = false;
                                        break;
                                    }
                                }
                            }
                            break;

                        case "DiceV2 (1)":
                            if (diceCast.scoreableArray[1])
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    if (PocketSpawnOpen[i])
                                    {
                                        previousLocations[1].position = diceCast.PhysicalDice[1].transform.position;
                                        diceCast.PhysicalDice[1].transform.position = diceCast.PocketSpawns[i].transform.position;
                                        PocketSpawnOpen[i] = false;
                                        break;
                                    }
                                }
                            }
                            break;

                        case "DiceV2 (2)":
                            if (diceCast.scoreableArray[2])
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    if (PocketSpawnOpen[i])
                                    {
                                        previousLocations[2].position = diceCast.PhysicalDice[2].transform.position;
                                        diceCast.PhysicalDice[2].transform.position = diceCast.PocketSpawns[i].transform.position;
                                        PocketSpawnOpen[i] = false;
                                        break;
                                    }
                                }
                            }
                            break;

                        case "DiceV2 (3)":
                            if (diceCast.scoreableArray[3])
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    if (PocketSpawnOpen[i])
                                    {
                                        previousLocations[3].position = diceCast.PhysicalDice[3].transform.position;
                                        diceCast.PhysicalDice[3].transform.position = diceCast.PocketSpawns[i].transform.position;
                                        PocketSpawnOpen[i] = false;
                                        break;
                                    }
                                }
                            }
                            break;

                        case "DiceV2 (4)":
                            if (diceCast.scoreableArray[4])
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    if (PocketSpawnOpen[i])
                                    {
                                        previousLocations[4].position = diceCast.PhysicalDice[4].transform.position;
                                        diceCast.PhysicalDice[4].transform.position = diceCast.PocketSpawns[i].transform.position;
                                        PocketSpawnOpen[i] = false;
                                        break;
                                    }
                                }
                            }
                            break;

                        case "DiceV2 (5)":
                            if (diceCast.scoreableArray[5])
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    if (PocketSpawnOpen[i])
                                    {
                                        previousLocations[5].position = diceCast.PhysicalDice[5].transform.position;
                                        diceCast.PhysicalDice[5].transform.position = diceCast.PocketSpawns[i].transform.position;
                                        PocketSpawnOpen[i] = false;
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

    public void RollDice()
    {
        targetNumber = Random.Range(1, 7);
        diceCast.CastDice(targetNumber);
        //targetNumber = number;
        isRolling = true;
        StartCoroutine(RollAndStop());
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