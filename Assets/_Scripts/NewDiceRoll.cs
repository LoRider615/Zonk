using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDiceRoll : MonoBehaviour
{
    //dice rigibody
    private Rigidbody rb;

    private void Start()
    {
        StartState();
    }

    //code for the rotation, force and torque for the dice
    //also adds torque and force to the dice rigidbody
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
}
