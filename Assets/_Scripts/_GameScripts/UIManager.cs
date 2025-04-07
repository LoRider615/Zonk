using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public GameObject tableCards;
    public GameObject cardPanel;
    public GameObject helpPanel;
    public GameObject settingsPanel;
    public GameObject runesPanel;
    public GameObject tutorialPanel;
    public DiceManager diceManager;

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

    //private void OpenCardPanel()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == tableCards)
    //    {
    //        OpenPanel(cardPanel);
    //    }
    //}

    public void ToggleHelpPanel()
    {
        if (activePanel == helpPanel)
        {
            ClosePanel();
            Time.timeScale = 1;
        }
        else if (activePanel == null)
        {
            OpenPanel(helpPanel);
            Time.timeScale = 0;
        }
    }

    public void ToggleSettingsPanel()
    {
        if (activePanel == settingsPanel)
        {
            ClosePanel();
            Time.timeScale = 1;
        }
        else if (activePanel == null)
        {
            OpenPanel(settingsPanel);
            Time.timeScale = 0;
        }
    }

    public void ToggleRunesPanel()
    {
        if (activePanel == runesPanel)
        {
            ClosePanel();
            Time.timeScale = 1;
        }
        else if (activePanel == null)
        {
            OpenPanel(runesPanel);
            Time.timeScale = 0;
        }
    }

    private void CloseAllPanels()
    {
        cardPanel.SetActive(false);
        helpPanel.SetActive(false);
        settingsPanel.SetActive(false);
        runesPanel.SetActive(false);
        tutorialPanel.SetActive(false);
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
