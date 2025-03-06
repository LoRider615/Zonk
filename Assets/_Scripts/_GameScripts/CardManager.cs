using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CardManager : MonoBehaviour
{
    public GameObject cardUIPrefab; // UI Prefab for a single card
    public GameObject cardUIAll; // Reference to the specific game object of the CardUI panel
    public Transform cardPanel; // Parent UI panel for cards
    public int maxCards = 5; // Max cards allowed
    public bool isCardPanelOn = false;


    public List<Card> playerCards = new List<Card>();

    // THIS IS TEMPORARY ----
    public Card testCard;
    public Card testCard2;
    public Card testCard3;

    //void Start()
    //{
    //    for (int i = 0; i < 3; i++)
    //    {
    //        // Manually create a test card if needed
    //        Card testCard = new Card();
    //        testCard.cardName = "Test Card";
    //        testCard.description = "This is a test card.";
    //        AddCard(testCard); // Add the card manually
    //    }
    //}

    private void Start()
    {
        cardUIAll.SetActive(false);
        AddCard(testCard);
        AddCard(testCard2);
        AddCard(testCard3);
    }

    //public void BuyCard()
    //{
    //    AddCard(testCard);
    //}
    // -----

    void Update()
    {
        OpenCardPanel();
    }

    public void OpenCardPanel()
    {
        if (!isCardPanelOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject) // Checks if this object was tapped
                    {
                        cardUIAll.SetActive(true);
                        isCardPanelOn = true;
                    }
                }
            }
        }
    }

    public void CloseCardPanel()
    {
        cardUIAll.SetActive(false);
        isCardPanelOn = false;
    }

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

            GameObject cardUI = Instantiate(cardUIPrefab, cardPanel); // Auto positions with Layout Group (TODO)
            cardUI.transform.Find("CardName").GetComponent<TextMeshProUGUI>().text = playerCards[i].cardName;
            cardUI.transform.Find("CardDescription").GetComponent<TextMeshProUGUI>().text = playerCards[i].description;
            cardUI.transform.Find("CardImage").GetComponent<Image>().sprite = playerCards[i].cardImage;
            
            int index = i;
            cardUI.transform.Find("UseButton").GetComponent<Button>().onClick.AddListener(() => UseCard(index));
        }
    }
}
