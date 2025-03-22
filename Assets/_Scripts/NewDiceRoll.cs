using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDiceRoll : MonoBehaviour
{
    //NOTES: Still need to get this to instantiate when needed
    //right now it stays on screen
    //doesn't reset position for each roll
    //also need to ensure that the player can't tap again while dice is being rolled/touch can only affect dice when we want them to in the game
    
    //dice rigibody
    public Rigidbody rb;
    public DiceCast diceCast;
    public GameObject gameManager;

    //this neat thing creates a list of game objects
    public GameObject[] faceReader;
    public bool allDiceStopped = false;
    //public int diceStoppedCount = 0;

    private bool valuePassed = true;

    private void Start()
    {
        diceCast = gameManager.GetComponent<DiceCast>();
        //StartState();
    }

    private void Update()
    {
        //touch ctrls (for now this will be blocked out, unblock when testing on phone)
        /*if (Input.touchCount > 0)
        {
            StartState();
        }*/

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Dice")
                {
                    Debug.Log("Dice touched successfully");
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }


        //temp keyboard ctrls - block out when using touch ctrls above
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartState();
            allDiceStopped = false;
            valuePassed = false;
            diceCast.diceStoppedCount = 0;
        }

        //if the dice is no longer moving, read which face is up (what we rolled)
        /*
        if (IsStopped() && !allDiceStopped)
        {
            //diceCast.CastDice(RollResult());
            diceStoppedCount++;
            Debug.Log(diceStoppedCount);
            if (diceStoppedCount == diceCast.diceToRoll)
                allDiceStopped = true;
        }
        */
        if (IsStopped() && !valuePassed)
        {
            diceCast.CastDice(RollResult());
            valuePassed = true;
            diceCast.diceStoppedCount++;
            Debug.Log("Dice Stopped: " + diceCast.diceStoppedCount);
            if (diceCast.diceStoppedCount == diceCast.diceToRoll)
                allDiceStopped = true;
        }

    }

    //code for the rotation, force and torque for the dice
    //also adds torque and force to the dice rigidbody
    //the state in which the dice starts off in
    //might need to adjust either the force or torque range later bc it's a little strong
    private void StartState()
    {
        //rotation
        int x = Random.Range(0, 360);
        int y = Random.Range(0, 360);
        int z = Random.Range(0, 360);
        
        Quaternion rotation = Quaternion.Euler(x, y, z);

        //force
        x = Random.Range(0, 25);
        y = Random.Range(0, 25);
        z = Random.Range(0, 25);
        
        Vector3 force = new Vector3(x, -y, z);

        //torque
        x = Random.Range(0, 50);
        y = Random.Range(0, 50);
        z = Random.Range(0, 50);

        Vector3 torque = new Vector3(x, y, z);

        //sets the starting rotation
        transform.rotation = rotation;
        //the velocity on the rigidbody is what we set the force as above
        rb.velocity = force;

        this.rb.maxAngularVelocity = 1000;
        rb.AddTorque(torque, ForceMode.VelocityChange);
    }

    //checks to see if the dice has stopped moving
    private bool IsStopped()
    {
        //if the rigidbody's velocity and angular velocity are zero (not moving) then it's stopped
        //if not, then return false cause its still moving
        if(rb.velocity == Vector3.zero && rb.angularVelocity == Vector3.zero)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //sees which face is the highest on the y axis to tell which face/number we rolled
    public int RollResult()
    {
        int maxValue = 0;

        for(int i = 1; i < faceReader.Length; i++)
        {
            if (faceReader[maxValue].transform.position.y < faceReader[i].transform.position.y)
            {
                maxValue = i;
                //Debug.Log("Rolled " + faceReader[i].name);
            }
        }
        Debug.Log("MAX VALUE: " +  (maxValue + 1));
        return maxValue + 1;
    }

    //my brain is fried 
    //I have never had to consult the Unity documentation more than I have now
}
