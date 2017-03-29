using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour {

    public GameObject itemNode;
    public Text itemBeingMadeText;
    string selectedItem;

    //images
    public Sprite sword;
    public Sprite shield;
    public Sprite shoes;
    public Sprite bracelet;
    public Sprite necklace;

    public void SelectItem()
    {
        selectedItem = itemNode.transform.GetChild(0).name;
        itemBeingMadeText.text = selectedItem;
    }

    public float GetQuality(float[] values)
    {
        float quality = 0;

        switch(selectedItem)
        {
            case "Sword":
                quality = SwordQuality(values);
                break;
            case "Shield":
                quality = ShieldQuality(values);
                break;
            case "Shoes":
                quality = ShoesQuality(values);
                break;
            case "Bracelet":
                quality = BraceletQuality(values);
                break;
            case "Necklace":
                quality = NecklaceQuality(values);
                break;
        }

        return quality;
    }

    public bool CheckIfDisplayQualityFormula()
    {
        bool show = false;
        bool tradeMatch = false;
        bool correctLevel;
        string mainTrade = this.GetComponent<TradeScript>().trades[0];
        Debug.Log(mainTrade + "main trade");
        int level = this.GetComponent<MenuScript>().level;
        //check if main trade matches selected item
        switch(selectedItem)
        {
            case "Sword":
                if (mainTrade == "Blacksmithing") { tradeMatch = true; }
                break;
            case "Shield":
                if (mainTrade == "Blacksmithing") { tradeMatch = true; }
                break;
            case "Shoes":
                if (mainTrade == "Leatherworking") { tradeMatch = true; }
                break;
            case "Bracelet":
                if (mainTrade == "Goldsmithing") { tradeMatch = true; }
                break;
            case "Necklace":
                if (mainTrade == "Jewellery") { tradeMatch = true; }
                break;
            default:
                tradeMatch = false;
                break;
        }
        Debug.Log("Trade match is " + tradeMatch);
        Debug.Log(selectedItem);
        if (level >= 50) { correctLevel = true; }
        else { correctLevel = false; }
        Debug.Log("Level is " + level.ToString());
        if (tradeMatch && correctLevel)
        {
            show = true;
        }
        //check if level is high enough
        return show;
    }

    public string SetDesiredAttributes()
    {
        string desired = "";
        switch(selectedItem)
        {
            case "Sword":
                desired = "Sharpness\nDurability";
                break;
            case "Shield":
                desired = "Durability";
                break;
            case "Shoes":
                desired = "Durability";
                break;
            case "Bracelet":
                desired = "Intricacy\nDurability";
                break;
            case "Necklace":
                desired = "Intricacy\nDurability";
                break;

        }
        return desired;
    }

    public string SetUnwantedAttributes()
    {
        string unwanted = "";
        switch (selectedItem)
        {
            case "Sword":
                unwanted = "";
                break;
            case "Shield":
                unwanted = "Sharpness";
                break;
            case "Shoes":
                unwanted = "Weight";
                break;
            case "Bracelet":
                unwanted = "Sharpness\nWeight";
                break;
            case "Necklace":
                unwanted = "Sharpness\nWeight";
                break;
        }
        return unwanted;
    }

    public string GetCompleteText()
    {
        string complete = "";
        switch(selectedItem)
        {
            case "Sword":
                complete = "Congratulations!\nYou have made a sword.";
                break;
            case "Shield":
                complete = "Congratulations!\nYou have made a shield.";
                break;
            case "Shoes":
                complete = "Congratulations!\nYou have made some shoes.";
                break;
            case "Bracelet":
                complete = "Congratulations!\nYou have made a bracelet.";
                break;
            case "Necklace":
                complete = "Congratulations!\nYou have made a necklace.";
                break;
        }
        return complete;
    }

    public Sprite GetCompleteImage()
    {
        Sprite compImage = null;
        switch (selectedItem)
        {
            case "Sword":
                compImage = sword;
                break;
            case "Shield":
                compImage = shield;
                break;
            case "Shoes":
                compImage = shoes;
                break;
            case "Bracelet":
                compImage = bracelet;
                break;
            case "Necklace":
                compImage = necklace;
                break;
        }
        return compImage;
    }

    //For the values array:
    //Durability: 2
    //Weight: 3
    //Sharpness: 4
    //Intricacy: 5

    float SwordQuality(float[] values)
    {
        //A top quality sword has high Sharpness and Durability
        float q;
        //quality is a sum so needs to halve the values (since need a total of 100, and the values can each be 100)
        q = (values[2]/2) + (values[4]/2);
        // quality = durability + sharpness
        return q;
    }

    float ShieldQuality(float[] values)
    {
        //A top quality shield has high Durability but low sharpness
        float q;
        //since here the quality is equal to one value minus another, no halving is needed
        q = values[2] - values[4];
        // quality = durability - sharpness
        return q;
    }

    float ShoesQuality(float[] values)
    {
        //Top quality shoes have high durability and low weight
        float q;
        //since here the quality is equal to one value minus another, no halving is needed
        q = values[2] - values[3];
        // quality = durability - weight
        return q;
    }

    float BraceletQuality(float[] values)
    {
        //A top quality bracelet has low sharpness, low weight but high intricacy and durability
        float q;
        //quality is a sum so needs to halve the values (since need a total of 100, and the values can each be 100)
        //this is also true for the values being taken away
        q = (values[2]/2) + (values[5]/2) - (values[3]/2) - (values[4]/2);
        // quality = durability + intricacy - weight - sharpness
        return q;
    }

    float NecklaceQuality(float[] values)
    {
        //A top quality bracelet has low sharpness, low weight but high intricacy and durability
        //High intricacy is more important than high durability        
        float q;
        //quality is a sum so needs to halve the values (since need a total of 100, and the values can each be 100)
        //this is also true for the values being taken away
        //Since we want intricacy to have twice the effect durability has, we halve durability an additional time
        q = (values[2]/4) + (values[5]/2) - (values[3]/2) - (values[4]/2);
        // quality = (durability/2) + intricacy - weight - sharpness
        return q;
    }
}
