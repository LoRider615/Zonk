using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// Manages point spending. Updates UI when points are spent, and also checks if purchase is valid.
/// </summary>

public class PointManager : MonoBehaviour
{
    public int points = 1000; // Starting money
    public TMP_Text pointText;

    void Start()
    {
        UpdatePoints();
    }

    public bool TryPurchase(int cost)
    {
        if (points >= cost)
        {
            points -= cost;
            UpdatePoints();
            return true;
        }
        return false;
    }

    void UpdatePoints()
    {
        pointText.text = "Points: $" + points;
    }
}
