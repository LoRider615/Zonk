using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TEMPUI : MonoBehaviour
{
    public Button[] buttonList = new Button[6];
    int[] passedArray = new int[6];
    public void PopulateButtons(int[] myArray)
    {
        
        for (int i = 0; i < buttonList.Length; i++)
        { 
            passedArray[i] = myArray[i];
            buttonList[i].GetComponentInChildren<TMP_Text>().text = myArray[i].ToString();
        }



    }
    
    public void EnableButtons(bool[] scoreable)
    {
        for (int i = 0; i < scoreable.Length; i++)
        {
            if (!scoreable[i])
            {
                buttonList[i].enabled = false;
            }
        }
    }

    public void ButtonAClicked()
    {
        this.GetComponent<PocketHandler>().AddToPocket(passedArray[0]);
        //Debug.Log("Num Passed " + passedArray[0]);
    }

    public void ButtonBClicked()
    {
        this.GetComponent<PocketHandler>().AddToPocket(passedArray[1]);
        //Debug.Log("Num Passed " + passedArray[1]);
    }

    public void ButtonCClicked()
    {
        this.GetComponent<PocketHandler>().AddToPocket(passedArray[2]);
        //Debug.Log("Num Passed " + passedArray[2]);
    }

    public void ButtonDClicked()
    {
        this.GetComponent<PocketHandler>().AddToPocket(passedArray[3]);
        //Debug.Log("Num Passed " + passedArray[3]);
    }

    public void ButtonEClicked()
    {
        this.GetComponent<PocketHandler>().AddToPocket(passedArray[4]);
        //Debug.Log("Num Passed " + passedArray[4]);
    }

    public void ButtonFClicked()
    {
        this.GetComponent<PocketHandler>().AddToPocket(passedArray[5]);
        //Debug.Log("Num Passed " + passedArray[5]);
    }
}
