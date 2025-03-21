using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject tableCards;
    public GameObject cardPanel;
    public GameObject helpPanel;
    public GameObject pausePanel;

    private GameObject activePanel = null; // the current open panel. if there is a panel here, then nothing else will open

    private void Start()
    {
        CloseAllPanels();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && activePanel == null)
        {
            OpenCardPanel();
        }
    }

    public void OpenPanel(GameObject panel)
    {
        if (activePanel == null)
        {
            panel.SetActive(true);
            activePanel = panel;
        }
    }

    public void ClosePanel()
    {
        if (activePanel != null)
        {
            activePanel.SetActive(false);
            activePanel = null;
        }
    }

    private void OpenCardPanel()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == tableCards)
        {
            OpenPanel(cardPanel);
        }
    }

    public void ToggleHelpPanel()
    {
        if (activePanel == helpPanel)
        {
            ClosePanel();
        }
        else if (activePanel == null)
        {
            OpenPanel(helpPanel);
        }
    }

    public void TogglePausePanel()
    {
        if (activePanel == pausePanel)
        {
            ClosePanel();
        }
        else if (activePanel == null)
        {
            OpenPanel(pausePanel);
        }
    }

    private void CloseAllPanels()
    {
        cardPanel.SetActive(false);
        helpPanel.SetActive(false);
        pausePanel.SetActive(false);
        activePanel = null;
    }
}
    //private bool isHelpOpen = false;
    //private bool isCardsOpen = false;
    //private bool isPaused = false;
    //public GameObject tableCards;
    //public GameObject helpPanel;
    //public GameObject cardPanel;

    //private void Start()
    //{
    //    cardPanel.SetActive(false);
    //    helpPanel.SetActive(false);
    //}
    //void Update()
    //{
    //    OpenCardPanel();
    //}

    //public void OpenCardPanel()
    //{
    //    if (!isCardsOpen && !isHelpOpen)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //            RaycastHit hit;

    //            if (Physics.Raycast(ray, out hit))
    //            {
    //                if (hit.collider.gameObject == tableCards) // Checks if this object was tapped
    //                {
    //                    cardPanel.SetActive(true);
    //                    isCardsOpen = true;
    //                }
    //            }
    //        }
    //    }
    //}

    //public void CloseCardPanel()
    //{
    //    cardPanel.SetActive(false);
    //    isCardsOpen = false;
    //}

    //public void OpenCloseHelp()
    //{
    //    if (!isHelpOpen && !isCardsOpen)
    //    {
    //        helpPanel.SetActive(true);
    //        isHelpOpen = true;
    //    } else
    //    {
    //        isHelpOpen = false;
    //        helpPanel.SetActive(false);
    //    }
    //}
