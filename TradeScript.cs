using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TradeScript : MonoBehaviour {

    public GameObject mainNode;
    public GameObject secondaryNode;
    public GameObject tertiaryNode;
    public GameObject errorMessage;
    string mainTrade;
    string secondaryTrade;
    string tertiaryTrade;
    public string[] trades = new string[3];
    //ability button texts
    public Text basic1Text;
    public Text basic2Text;
    public Text main1Text;
    public Text main2Text;
    public Text main3Text;
    public Text secondary1Text;
    public Text secondary2Text;
    public Text secondary3Text;
    public Text tertiary1Text;
    public Text tertiary2Text;
    public Text tertiary3Text;

    void Start()
    {
        errorMessage.SetActive(false);
    }

    public void SaveTradeSelectionClick()
    {
        //make sure player has selected 3 trades
        if (mainNode.transform.childCount != 1 || secondaryNode.transform.childCount != 1 || tertiaryNode.transform.childCount != 1)
        {
            //Debug.Log("player needs to select trades");
            //show error panel
            errorMessage.SetActive(true);
        }
        else
        {
            errorMessage.SetActive(false);
            mainTrade = mainNode.transform.GetChild(0).name;
            secondaryTrade = secondaryNode.transform.GetChild(0).name;
            tertiaryTrade = tertiaryNode.transform.GetChild(0).name;
            Debug.Log(mainTrade);
            Debug.Log(secondaryTrade);
            Debug.Log(tertiaryTrade);
            trades[0] = mainTrade;
            trades[1] = secondaryTrade;
            trades[2] = tertiaryTrade;
            this.GetComponent<MenuScript>().CloseAllPanels();
            this.GetComponent<MenuScript>().menuPanel.SetActive(true);
        }
    }

    public void SetAbilityButtonText()
    {
        basic1Text.text = "Basic 1";
        basic2Text.text = "Basic 2";
        main1Text.text = GetMainTradeString(mainTrade) + " 1";
        main2Text.text = GetMainTradeString(mainTrade) + " 2";
        main3Text.text = GetMainTradeString(mainTrade) + " 3";
        secondary1Text.text = GetSecondaryTradeString(secondaryTrade) + " 1";
        secondary2Text.text = GetSecondaryTradeString(secondaryTrade) + " 2";
        secondary3Text.text = GetSecondaryTradeString(secondaryTrade) + " 3";
        tertiary1Text.text = GetTertiaryTradeString(tertiaryTrade) + " 1";
        tertiary2Text.text = GetTertiaryTradeString(tertiaryTrade) + " 2";
        tertiary3Text.text = GetTertiaryTradeString(tertiaryTrade) + " 3";
    }

    string GetMainTradeString(string tradeName)
    {
        string main = "";

        switch (tradeName)
        {
            case "Blacksmithing":
                main = "Smith";
                break;
            case "Leatherworking":
                main = "Leather";
                break;
            case "Cooking":
                main = "Cook";
                break;
            case "Carpentry":
                main = "Carpent";
                break;
            case "Goldsmithing":
                main = "Gold";
                break;
            case "Jewellery":
                main = "Jewel";
                break;
        }

        return main;
    }

    string GetSecondaryTradeString(string tradeName)
    {
        string second = "";

        switch (tradeName)
        {
            case "Blacksmithing":
                second = "Smith";
                break;
            case "Leatherworking":
                second = "Leather";
                break;
            case "Cooking":
                second = "Cook";
                break;
            case "Carpentry":
                second = "Carpent";
                break;
            case "Goldsmithing":
                second = "Gold";
                break;
            case "Jewellery":
                second = "Jewel";
                break;
        }

        return second;
    }

    string GetTertiaryTradeString(string tradeName)
    {
        string tert = "";

        switch (tradeName)
        {
            case "Blacksmithing":
                tert = "Smith";
                break;
            case "Leatherworking":
                tert = "Leather";
                break;
            case "Cooking":
                tert = "Cook";
                break;
            case "Carpentry":
                tert = "Carpent";
                break;
            case "Goldsmithing":
                tert = "Gold";
                break;
            case "Jewellery":
                tert = "Jewel";
                break;

        }

        return tert;
    }    
}
