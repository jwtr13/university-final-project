using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;

public class AbilityHandler : MonoBehaviour {

    //NOTE - ALL ABILITIES HAVE HAD THEIR COST REDUCED TO 1.
    //THIS WAS DONE FOR TESTING PURPOSES.

    //create abilities - constructors in order of energy cost, progress, durability, weight, sharpness, intricacy
    public Basic1 b1 = new Basic1(1, 5, 0, 0, 0, 0); //increase progress by 5%
    public Basic2 b2 = new Basic2(1, 0, 1, 1, 1, 1); //increase all quality aspects by 1%
    public Leatherwork1 l1 = new Leatherwork1(1, 0, 0, 0, 0, 20); //increase intricacy by 20%
    public Leatherwork2 l2 = new Leatherwork2(1, 0, 0, 0, 0, 0); //increase a random quality aspect by 40% but decrease another by 20%
    public Leatherwork3 l3 = new Leatherwork3(1, -10, 10, 0, 0, 10); //Increase Durability + Intricacy by 10% each decrease progress by 10%
    public Blacksmith1 bs1 = new Blacksmith1(1, 0, 0, -15, 30, 0); //increase sharpness by 30% decrease weight by 15%
    public Blacksmith2 bs2 = new Blacksmith2(1, 10, -2, -2, -2, -2); //increase progress by 10% decrease quality by 2% each
    public Blacksmith3 bs3 = new Blacksmith3(1, 10, 0, 0, 0, 0); //increase progress by 10%, if within 15% of completion, complete instantly
    public Cooking1 c1 = new Cooking1(-5, 0, 0, 0, 0, 0); //restore 5% energy
    public Cooking2 c2 = new Cooking2(1, 10, 0, 0, 0, 0); //increase progress by 10%
    public Cooking3 c3 = new Cooking3(1, 0, 0, 0, 0, 5); //increase intricacy by 5%
    public Carpentry1 car1 = new Carpentry1(1, 0, 0, 0, -10, 10); //decrease sharpness by 10% to increase intricacy by 10%
    public Carpentry2 car2 = new Carpentry2(1, 0, 10, 0, 0, -10); //decrease intricacy by 10% to increase durability by 10%
    public Carpentry3 car3 = new Carpentry3(1, 5, 0, -10, 0, 0); //increase progress by 5% by decreasing weight by 10%
    public Goldsmithing1 g1 = new Goldsmithing1(1, 0, 5, 0, 0, 0); //increase durability by 5%
    public Goldsmithing2 g2 = new Goldsmithing2(1, 2, 0, 15, 0, 5); //increase progress by 2%, intricacy by 5% and weight by 15%
    public Goldsmithing3 g3 = new Goldsmithing3(1, 0, 0, 0, 0, 0); //round down/up all quality aspects that are above 70% or below 30%
    public Jewellery1 j1 = new Jewellery1(1, 0, 0, -10, -10, 0); //decrease sharpness and weight by 10% 
    public Jewellery2 j2 = new Jewellery2(1, 10, -5, -5, -5, -5); //decrease all quality aspects to increase progress
    public Jewellery3 j3 = new Jewellery3(1, 0, 0, 0, 0, 0); //reduce progress to 0, but fully increase intricacy (to 100%)

    //progress bars
    public Image energyBar;
    public Image progressBar;
    public Image qualityBar;
    public Image durabilityBar;
    public Image weightBar;
    public Image sharpnessBar;
    public Image intricacyBar;

    //complete panel text and image
    public Text completeText;
    public Image completeImage;

    // Use this for initialization
    void Start()
    {
        energyBar = this.GetComponent<MenuScript>().energyBarImage;
        progressBar = this.GetComponent<MenuScript>().progressBarImage;
        qualityBar = this.GetComponent<MenuScript>().qualityBarImage;
        durabilityBar = this.GetComponent<MenuScript>().durabilityBarImage;
        weightBar = this.GetComponent<MenuScript>().weightBarImage;
        sharpnessBar = this.GetComponent<MenuScript>().sharpnessBarImage;
        intricacyBar = this.GetComponent<MenuScript>().intricacyBarImage;
    }

    public void abilityClick()
    {
        //Debug.Log("click");
        //check which button was pressed
        string abilityPressed = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text; //get what the text says
        //get the current values
        float[] currentValues = new float[6];
        currentValues[0] = (energyBar.fillAmount * 100);
        currentValues[1] = (progressBar.fillAmount * 100);
        currentValues[2] = (durabilityBar.fillAmount * 100);
        currentValues[3] = (weightBar.fillAmount * 100);
        currentValues[4] = (sharpnessBar.fillAmount * 100);
        currentValues[5] = (intricacyBar.fillAmount * 100);
        //run method with selected button
        currentValues = adjustValues(abilityPressed, currentValues);
        //work out the quality value - average of the quality aspects (durability, weight, sharpness and intricacy)
        float q = getQuality(currentValues);
        //update progress bars - including checking if over 100% and setting to bar fully filled
        UpdateProgressBars(currentValues, q);
        //check if progress is 100%        
        if (currentValues[1] >= 100)
        {
            //if it is greater/equal to 100, the player has completed the item
            //close the game panel
            this.gameObject.GetComponent<MenuScript>().gamePanel.SetActive(false);
            //set the correct text to show depending on completed item
            completeText.text = this.gameObject.GetComponent<ItemScript>().GetCompleteText();
            //set the correct image
            completeImage.sprite = this.gameObject.GetComponent<ItemScript>().GetCompleteImage();
            //show the complete panel
            this.gameObject.GetComponent<MenuScript>().completePanel.SetActive(true);
            //set all the stats of the completed item
            //check if the stats are less than 0
            //if they are, set them to 0
            //same with if above 100
            if (q < 0)
            {
                q = 0;
            }
            if (q > 100)
            {
                q = 100;
            }
            for (int i = 0; i <= 5; i++)
            {
                //Need to check if quality values are between 0-100 - if not, cap them at 0 and 100.
                if (currentValues[i] <= 0)
                {                    
                    currentValues[i] = 0;
                }
                if (currentValues[i] >= 100)
                {
                    currentValues[i] = 100;
                }
            }
            this.gameObject.GetComponent<MenuScript>().qualityTextValue.text = q.ToString();
            this.gameObject.GetComponent<MenuScript>().durabilityTextValue.text = currentValues[2].ToString();
            this.gameObject.GetComponent<MenuScript>().weightTextValue.text = currentValues[3].ToString();
            this.gameObject.GetComponent<MenuScript>().sharpnessTextValue.text = currentValues[4].ToString();
            this.gameObject.GetComponent<MenuScript>().intricacyTextValue.text = currentValues[5].ToString();            

        }        
        else
        {
            //check if energy is 0%
            if (currentValues[0] <= 0)
            {
                //if it is lower than/equal to 0, the player has run out of energy
                //close the game panel                
                this.gameObject.GetComponent<MenuScript>().gamePanel.SetActive(false);
                //show the fail panel
                this.gameObject.GetComponent<MenuScript>().failPanel.SetActive(true);
            }
        }

    }

    float[] adjustValues (string abilityPressed, float[] currentValues)
    {
        Debug.Log("adjust values");
        float[] newValues = new float[6];
        switch(abilityPressed)
        {
            case "Basic 1":
                newValues = b1.UseAbility(currentValues);
                break;
            case "Basic 2":
                newValues = b2.UseAbility(currentValues);
                break;
            case "Leather 1":
                newValues = l1.UseAbility(currentValues);
                break;
            case "Leather 2":
                newValues = l2.UseAbility(currentValues);
                break;
            case "Leather 3":
                newValues = l3.UseAbility(currentValues);
                break;
            case "Smith 1":
                newValues = bs1.UseAbility(currentValues);
                break;
            case "Smith 2":
                newValues = bs2.UseAbility(currentValues);
                break;
            case "Smith 3":
                newValues = bs3.UseAbility(currentValues);
                break;
            case "Cook 1":
                newValues = c1.UseAbility(currentValues);
                break;
            case "Cook 2":
                newValues = c2.UseAbility(currentValues);
                break;
            case "Cook 3":
                newValues = c3.UseAbility(currentValues);
                break;
            case "Carpent 1":
                newValues = car1.UseAbility(currentValues);
                break;
            case "Carpent 2":
                newValues = car2.UseAbility(currentValues);
                break;
            case "Carpent 3":
                newValues = car3.UseAbility(currentValues);
                break;
            case "Gold 1":
                newValues = g1.UseAbility(currentValues);
                break;
            case "Gold 2":
                newValues = g2.UseAbility(currentValues);
                break;
            case "Gold 3":
                newValues = g3.UseAbility(currentValues);
                break;
            case "Jewel 1":
                newValues = j1.UseAbility(currentValues);
                break;
            case "Jewel 2":
                newValues = j2.UseAbility(currentValues);
                break;
            case "Jewel 3":
                newValues = j3.UseAbility(currentValues);
                break;
        }
        return newValues;
    }

    float getQuality(float[] currentValues)
    {
        float quality;
        ItemScript iScript = this.GetComponent<ItemScript>();
        quality = iScript.GetQuality(currentValues);
        return quality;
    }

    void UpdateProgressBars(float[] currentValues, float q)
    {
        Debug.Log("update progress bars");
        //divide the current values by 100 to get between 0 and 1
        float energy = currentValues[0] / 100;
        Debug.Log("energy " + energy + " updated by " + currentValues[0]);
        float progress = currentValues[1] / 100;
        float quality = q / 100;
        float durability = currentValues[2] / 100;
        float weight = currentValues[3] / 100;
        float sharpness = currentValues[4] / 100;
        float intricacy = currentValues[5] / 100;
        //if any of these are over 100, set the fill amount to 1
        //otherwise do as normal
        if (energy > 1)
        {
            energyBar.fillAmount = 1;
        }
        else
        {
            energyBar.fillAmount = energy;
        }
        if (progress > 1)
        {
            progressBar.fillAmount = 1;
        }
        else
        {
            progressBar.fillAmount = progress;
        }
        if (quality > 1)
        {
            qualityBar.fillAmount = 1;
        }
        else
        {
            qualityBar.fillAmount = quality;
        }
        if (durability > 1)
        {
            durabilityBar.fillAmount = 1;
        }
        else
        {
            durabilityBar.fillAmount = durability;
        }
        if (weight > 1)
        {
            weightBar.fillAmount = 1;
        }
        else
        {
            weightBar.fillAmount = weight;
        }
        if (sharpness > 1)
        {
            sharpnessBar.fillAmount = 1;
        }
        else
        {
            sharpnessBar.fillAmount = sharpness;
        }
        if (intricacy > 1)
        {
            intricacyBar.fillAmount = 1;
        }
        else
        {
            intricacyBar.fillAmount = intricacy;
        }
    }
}
