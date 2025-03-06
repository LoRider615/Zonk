using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool isHelpOpen = false;
    private bool isCardsOpen = false;
    public GameObject tableCards;
    public GameObject helpPanel;
    public GameObject cardPanel;

    private void Start()
    {
        cardPanel.SetActive(false);
        helpPanel.SetActive(false);
    }
    void Update()
    {
        OpenCardPanel();
    }

    public void OpenCardPanel()
    {
        if (!isCardsOpen && !isHelpOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == tableCards) // Checks if this object was tapped
                    {
                        cardPanel.SetActive(true);
                        isCardsOpen = true;
                    }
                }
            }
        }
    }

    public void CloseCardPanel()
    {
        cardPanel.SetActive(false);
        isCardsOpen = false;
    }

    public void OpenCloseHelp()
    {
        if (!isHelpOpen && !isCardsOpen)
        {
            helpPanel.SetActive(true);
            isHelpOpen = true;
        } else
        {
            isHelpOpen = false;
            helpPanel.SetActive(false);
        }
    }
}
