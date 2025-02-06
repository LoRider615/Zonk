using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheck : MonoBehaviour
{
    Vector3 diceVelocity;

    private void FixedUpdate()
    {
        diceVelocity = RollDice.castVel;
    }

    private void OnTriggerStay(Collider other)
    {
        if(diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
        {
            switch(other.gameObject.name)
            {
                case "face1":
                    DiceNumberText.diceNumber = 6;
                    break;
                case "face2":
                    DiceNumberText.diceNumber = 5;
                    break;
                case "face3":
                    DiceNumberText.diceNumber = 4;
                    break;
                case "face4":
                    DiceNumberText.diceNumber = 3;
                    break;
                case "face5":
                    DiceNumberText.diceNumber = 2;
                    break;
                case "face6":
                    DiceNumberText.diceNumber = 1;
                    break;
            }
        }
    }
}
