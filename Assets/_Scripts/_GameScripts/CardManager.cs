using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CardManager : MonoBehaviour
{
    public GameObject cardUIPrefab; // UI Prefab for a single card
    public Transform cardPanel; // Parent UI panel for cards
    public int maxCards = 5; // Max cards allowed


    public List<Card> playerCards = new List<Card>();

    // THIS IS TEMPORARY ----
    public Card testCard;
    public Card testCard2;
    public Card testCard3;

    //void Start()
    //{
    //    for (int i = 0; i < 3; i++)
    //    {
    //        Card testCard = new Card();
    //        testCard.cardName = "Test Card";
    //        testCard.description = "This is a test card.";
    //        AddCard(testCard); 
    //    }
    //}

    private void Start()
    {
        AddCard(testCard);
        AddCard(testCard2);
        AddCard(testCard3);
    }

    //public void BuyCard()
    //{
    //    AddCard(testCard);
    //}
    // -----

    public void AddCard(Card newCard)
    {
        if (playerCards.Count >= maxCards)
        {
            Debug.Log("Max cards reached!");
            return;
        }
        
        playerCards.Add(newCard);
        //Debug.Log("ADDED CARD OF INDEX: " + playerCards.Count);
        UpdateCardUI();
    }

    public void UseCard(int index)
    {
        Debug.Log("CARD USED at index of: " + index);
        if (index < 0 || index >= playerCards.Count)
        {
            Debug.Log("Used card is outside expected range");
            return;
        }

        playerCards[index].Use(); // Do the card effect
        playerCards.RemoveAt(index); // Remove the card from the player's cards
        UpdateCardUI();
    }

    /// <summary>
    /// Clears all cards within the CardPanel and re-creates them
    /// </summary>
    void UpdateCardUI()
    {
        // Clear current UI
        foreach (Transform child in cardPanel)
        {
            Destroy(child.gameObject);
        }

        // Create UI for each card
        for (int i = 0; i < playerCards.Count; i++)
        {
            //Debug.Log("Displaying card at index: " + i); // log each card being created

            GameObject cardUI = Instantiate(cardUIPrefab, cardPanel); // Auto positions with Layout Group
            cardUI.transform.Find("CardName").GetComponent<TextMeshProUGUI>().text = playerCards[i].cardName;
            cardUI.transform.Find("CardDescription").GetComponent<TextMeshProUGUI>().text = playerCards[i].description;
            cardUI.transform.Find("CardImage").GetComponent<Image>().sprite = playerCards[i].cardImage;
            
            int index = i;
            cardUI.transform.Find("UseButton").GetComponent<Button>().onClick.AddListener(() => UseCard(index));
        }
    }
}
