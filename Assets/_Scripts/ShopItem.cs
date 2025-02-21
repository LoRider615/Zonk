using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
/// <summary>
/// 
/// </summary>

public class ShopItem : MonoBehaviour
{
    public int price;
    public Button buyButton;
    public TMP_Text priceText;
    private bool isPurchased = false;
    private PointManager PointManager;

    void Start()
    {
        PointManager = FindObjectOfType<PointManager>();
        priceText.text = "$" + price;
        buyButton.onClick.AddListener(BuyItem);
    }

    void BuyItem()
    {
        // If item has not been purchased, and the player has enough money, they purchase item.
        if (!isPurchased && PointManager.TryPurchase(price))
        {
            isPurchased = true;
            buyButton.interactable = false;
            priceText.text = "Purchased!";
            buyButton.image.color = Color.gray;
        }
    }
}
