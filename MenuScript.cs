using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject noTradesErrorPanel;
    public GameObject itemPanel;
    public GameObject itemErrorMessage;
    public GameObject itemNode;
    public GameObject qualityFormulaPanel;
    public Text desiredText;
    public Text unwantedText;
    public GameObject gamePanel;
    public GameObject tradesPanel;
    public GameObject settingsPanel;
    public GameObject completePanel;
    public GameObject failPanel;
    public GameObject durabilityBar;
    public GameObject weightBar;
    public GameObject sharpnessBar;
    public GameObject intricacyBar;

    public Image energyBarImage;
    public Image progressBarImage;
    public Image qualityBarImage;
    public Image durabilityBarImage;
    public Image weightBarImage;
    public Image sharpnessBarImage;
    public Image intricacyBarImage;

    public Text levelText;
    public Text experienceText;
    public int level;
    public int experience;
    public Text qualityTextValue;
    public Text durabilityTextValue;
    public Text weightTextValue;
    public Text sharpnessTextValue;
    public Text intricacyTextValue;

	// Use this for initialization
	void Start () {
        //display the main menu
        CloseAllPanels();
        DisplayMainMenu();
    }
	
	public void StartButton()
    {
        
        if (this.GetComponent<TradeScript>().trades[0] == "")
        {
            noTradesErrorPanel.SetActive(true);
        }
        else
        {
            CloseAllPanels();
            itemPanel.SetActive(true);
        }
        
    }

    public void SettingsButton()
    {
        CloseAllPanels();
        settingsPanel.SetActive(true);
    }

    

    public void SaveSettingsButton()
    {
        //get the text from the textboxes
        level = Convert.ToInt32(levelText.text);
        experience = Convert.ToInt32(experienceText.text);        
        Debug.Log(level);
        Debug.Log(experience);
        //display the main menu
        CloseAllPanels();
        menuPanel.SetActive(true);
    }

    public void DisplayMainMenu()
    {
        CloseAllPanels();
        //display the main menu
        menuPanel.SetActive(true);        
    }

    public void SelectTradesButton()
    {
        CloseAllPanels();
        tradesPanel.SetActive(true);
    }

    public void CraftButton()
    {
        ItemScript iScript = this.GetComponent<ItemScript>();
        if (itemNode.transform.childCount != 1)
        {
            itemErrorMessage.SetActive(true);
        }
        else
        {
            CloseAllPanels();
            iScript.SelectItem();
            bool showQualityFormula = iScript.CheckIfDisplayQualityFormula();
            if (showQualityFormula)
            {
                //set the text for the panel
                desiredText.text = iScript.SetDesiredAttributes();
                unwantedText.text = iScript.SetUnwantedAttributes();
                qualityFormulaPanel.SetActive(true);
            }            
            ResetQualityBars();
            DisplayCorrectQualityBars();
            this.GetComponent<TradeScript>().SetAbilityButtonText();
            gamePanel.SetActive(true);
        }        
    }

    //call this to make sure everything is closed
    //before opening the required panel
    public void CloseAllPanels()
    {
        menuPanel.SetActive(false);
        noTradesErrorPanel.SetActive(false);
        itemPanel.SetActive(false);
        itemErrorMessage.SetActive(false);
        qualityFormulaPanel.SetActive(false);
        gamePanel.SetActive(false);
        settingsPanel.SetActive(false);
        completePanel.SetActive(false);
        failPanel.SetActive(false);
        tradesPanel.SetActive(false);

        //also disable quality bars by default
        durabilityBar.SetActive(false);
        weightBar.SetActive(false);
        sharpnessBar.SetActive(false);
        intricacyBar.SetActive(false);
    }

    void DisplayCorrectQualityBars()
    {
        //display the correct quality bars
        if (experience >= 100)
        {
            durabilityBar.SetActive(true);
            if (experience >= 250)
            {
                weightBar.SetActive(true);
                if (experience >= 500)
                {
                    sharpnessBar.SetActive(true);
                    if (experience >= 1000)
                    {
                        intricacyBar.SetActive(true);
                    }
                }
            }
        }
    }

    void ResetQualityBars()
    {
        //set the bars to the default amounts (energy bar is full, others are empty)
        energyBarImage.fillAmount = 1;
        progressBarImage.fillAmount = 0;
        qualityBarImage.fillAmount = 0;
        durabilityBarImage.fillAmount = 0;
        weightBarImage.fillAmount = 0;
        sharpnessBarImage.fillAmount = 0;
        intricacyBarImage.fillAmount = 0;
    }

    public void ExitButton()
    {
        //exit the game
        Application.Quit();
    }
}
