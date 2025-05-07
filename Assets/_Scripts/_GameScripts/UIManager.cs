using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public GameObject tableCards;
    public GameObject cardPanel;
    public GameObject inventoryPanel;
    public GameObject helpPanel;
    public GameObject settingsPanel;
    public GameObject runesPanel;
    public GameObject tutorialPanel;
    public DiceManager diceManager;
    public PocketHandler pocketHandler;

    public bool wasCastOn;
    public bool wasEndOn;

    //public GameObject runesQuota;

    //public PocketHandler pocketHandler;

    private GameObject activePanel = null; // the current open panel. if there is a panel here, then nothing else will open

    private void Start()
    {
        CloseAllPanels();
        if (diceManager.isTutorialMode == true)
        {
            OpenPanel(tutorialPanel);
        }

        //Cursor.SetCursor(PlayerSettings.defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
 
    }

    //private void Awake()
    //{
    //    //pocketHandler = runesQuota.GetComponent<PocketHandler>();
    //    runesPanel.SetActive(false);
    //}

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0) && activePanel == null)
    //    {
    //        OpenCardPanel();
    //    }
    //}

    public void OpenPanel(GameObject panel)
    {
        if (activePanel == null)
        {
            panel.SetActive(true);
            activePanel = panel;
            Time.timeScale = 0;
            if (pocketHandler.castButton.interactable == false)
            {
                wasCastOn = false;
            } 
            else
            {
                wasCastOn = true;
            }
            if (pocketHandler.endTurnButton.interactable == false)
            {
                wasEndOn = false;
            }
            else
            {
                wasEndOn = true;
            }
            pocketHandler.castButton.interactable = false;
            pocketHandler.endTurnButton.interactable = false;
        }
    }

    public void ClosePanel()
    {
        if (activePanel != null)
        {
            activePanel.SetActive(false);
            activePanel = null;
            Time.timeScale = 1;
            if (wasCastOn)
            {
                pocketHandler.castButton.interactable = true;
            } 
            else
            {
                pocketHandler.castButton.interactable = false;
            }
            if (wasEndOn)
            {
                pocketHandler.endTurnButton.interactable = true;
            }
            else
            {
                pocketHandler.endTurnButton.interactable = false;
            }
        }
    }

    public void OpenCardPanel()
    {
        OpenPanel(cardPanel);
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

    public void ToggleSettingsPanel()
    {
        if (activePanel == settingsPanel)
        {
            ClosePanel();
        }
        else if (activePanel == null)
        {
            OpenPanel(settingsPanel);
        }
    }

    public void ToggleInventoryPanel()
    {
        if (activePanel == inventoryPanel)
        {
            ClosePanel();
        }
        else if (activePanel == null)
        {
            OpenPanel(inventoryPanel);
        }
    }

    private void CloseAllPanels()
    {
        cardPanel.SetActive(false);
        helpPanel.SetActive(false);
        settingsPanel.SetActive(false);
        runesPanel.SetActive(false);
        tutorialPanel.SetActive(false);
        inventoryPanel.SetActive(false);
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
