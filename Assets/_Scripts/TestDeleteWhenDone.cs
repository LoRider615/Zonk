using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeleteWhenDone : MonoBehaviour
{
    static Rigidbody diceBody;
    public static Vector3 castVel;

    public void Start()
    {
        diceBody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        castVel = diceBody.velocity;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            DiceNumberText.diceNumber = 0;

            float directionX = Random.Range(0, 500);
            float directionY = Random.Range(0, 500);
            float directionZ = Random.Range(0, 500);

            transform.position = new Vector3(0, 2, 0);
            transform.rotation = Quaternion.identity;

            diceBody.AddForce(transform.up * 500);
            diceBody.AddTorque(directionX, directionY, directionZ);
        }
    }
}
