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

    //this neat thing creates a list of game objects
    public GameObject[] faceReader;

    private void Start()
    {
        //StartState();
    }

    private void Update()
    {
        //touch ctrls (for now this will be blocked out, unblock when testing on phone)
        /*if (Input.touchCount > 0)
        {
            StartState();
        }*/

        //temp keyboard ctrls - block out when using touch ctrls above
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartState();
        }

        //if the dice is no longer moving, read which face is up (what we rolled)
        if (IsStopped() == true)
        {
            int indexResult = RollResult();
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
    private int RollResult()
    {
        int maxValue = 0;

        for(int i = 1; i < faceReader.Length; i++)
        {
            if (faceReader[maxValue].transform.position.y < faceReader[i].transform.position.y)
            {
                maxValue = i;
                Debug.Log("Rolled " + faceReader[i].name);
            }
        }
        return maxValue;
    }

    //my brain is fried 
    //I have never had to consult the Unity documentation more than I have now
}
