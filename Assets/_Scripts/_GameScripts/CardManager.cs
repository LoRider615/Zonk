using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject cardUIPrefab; // UI Prefab for a single card
    public Transform cardPanel; // Parent UI panel for cards
    public int maxCards = 5; // Max cards allowed

    private List<Card> playerCards = new List<Card>();

    public void AddCard(Card newCard)
    {
        if (playerCards.Count >= maxCards)
        {
            Debug.Log("Max cards reached!");
            return;
        }

        playerCards.Add(newCard);
        UpdateCardUI();
    }

    public void UseCard(int index)
    {
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
            GameObject cardUI = Instantiate(cardUIPrefab, cardPanel); // Auto positions with Layout Group
            cardUI.transform.Find("CardName").GetComponent<Text>().text = playerCards[i].cardName;
            cardUI.transform.Find("CardDescription").GetComponent<Text>().text = playerCards[i].description;
            cardUI.transform.Find("CardImage").GetComponent<Image>().sprite = playerCards[i].cardImage;
            cardUI.transform.Find("UseButton").GetComponent<Button>().onClick.AddListener(() => UseCard(i));
        }
    }
}
