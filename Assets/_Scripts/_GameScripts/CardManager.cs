using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CardManager : MonoBehaviour
{
    public DiceCast diceCast;
    public UIManager uiManager;
    public GameObject cardUIPrefab; // UI Prefab for a single card
    public Transform cardPanel;
    public Transform inventoryPanel;

    public List<Card> availableCards = new List<Card>(); // all possible cards
    public List<Card> drawnCards = new List<Card>(); // cards currently drawn
    public List<Card> inventory = new List<Card>(); // cards in the player's inventory

    // THIS IS TEMPORARY ----
    public Card testCard;
    public Card testCard2;
    public Card testCard3;
    public Card testCard4;
    public Card testCard5;

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
        AddCard(testCard4);
        AddCard(testCard5);
        DrawCards(3);
    }

    //public void BuyCard()
    //{
    //    AddCard(testCard);
    //}
    // -----

    public void AddCard(Card newCard)
    {
        availableCards.Add(newCard);
        Debug.Log("ADDED CARD OF INDEX: " + availableCards.Count);
    }

    public void DrawCards(int count)
    {
        // clear out drawn cards
        drawnCards.Clear();
        foreach (Transform child in cardPanel)
        {
            Destroy(child.gameObject);
        }

        // add all remaining cards into temporary list for randomizing
        List<Card> tempCardsForRandomizer = new List<Card>();
        foreach (Card card in availableCards)
        {
            tempCardsForRandomizer.Add(card);
        }

        //pick 3 random cards from tempCardsForRandomizer and display them
        for (int i = 0; i < count && tempCardsForRandomizer.Count > 0; i++)
        {
            int randomIndex = Random.Range(0, tempCardsForRandomizer.Count);
            Card randomCard = tempCardsForRandomizer[randomIndex];

            drawnCards.Add(randomCard);

            GameObject cardUI = Instantiate(cardUIPrefab, cardPanel);
            cardUI.transform.Find("CardName").GetComponent<TextMeshProUGUI>().text = randomCard.cardName;
            cardUI.transform.Find("CardDescription").GetComponent<TextMeshProUGUI>().text = randomCard.description;
            cardUI.transform.Find("CardImage").GetComponent<Image>().sprite = randomCard.cardImage;

            cardUI.transform.Find("UseButton").GetComponent<Button>().onClick.AddListener(() => UseCard(randomCard));

            tempCardsForRandomizer.RemoveAt(randomIndex);
        }
    }

    public void UseCard(Card card)
    {
        card.Use(diceCast);
        inventory.Add(card);
        UpdateInventoryUI();
        drawnCards.Remove(card);
        availableCards.Remove(card);
        DrawCards(3);
        uiManager.ClosePanel(); // closes card panel after picking card
    }

    //public void UseCard(int index)
    //{
    //    Debug.Log("CARD USED at index of: " + index);
    //    if (index < 0 || index >= drawnCards.Count)
    //    {
    //        Debug.Log("Used card is outside expected range");
    //        return;
    //    }

    //    drawnCards[index].Use(diceCast); // Do the card effect
    //    drawnCards.RemoveAt(index); // Remove the card from the player's cards
    //    UpdateCardUI();
    //}

    private void UpdateInventoryUI()
    {
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (Card card in inventory)
        {
            GameObject cardUI = Instantiate(cardUIPrefab, inventoryPanel);
            cardUI.transform.Find("CardName").GetComponent<TextMeshProUGUI>().text = card.cardName;
            cardUI.transform.Find("CardDescription").GetComponent<TextMeshProUGUI>().text = card.description;
            cardUI.transform.Find("CardImage").GetComponent<Image>().sprite = card.cardImage;

            // disable the use button for the card
            cardUI.transform.Find("UseButton").GetComponent<Button>().interactable = false;
        }
    }

    //private List<Card> GetRandomCards(int count)
    //{
    //    List<Card> randomCards = new List<Card>();
    //    List<Card> tempAvailableCards = new List<Card>(availableCards);

    //    for (int i = 0; i < count && tempAvailableCards.Count > 0; i++)
    //    {
    //        int randomIndex = Random.Range(0, tempAvailableCards.Count);
    //        randomCards.Add(tempAvailableCards[randomIndex]);
    //        tempAvailableCards.RemoveAt(randomIndex);
    //    }

    //    return randomCards;
    //}
}
