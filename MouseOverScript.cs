using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class MouseOverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    public Text descriptionTextBox;
    public GameObject eventHandler;

    //The descriptions will become more detailed the higher level the player is

    void Start()
    {
        //default set the description to blank
        descriptionTextBox.text = "";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //set the description back to blank
        //Debug.Log("Stopped Hovering");
        descriptionTextBox.text = "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        string hoveredButton = this.transform.GetComponentInChildren<Text>().text;
        Debug.Log(hoveredButton);
        //Find the instance of the Basic1 class from AbilityHandler
        AbilityHandler ah = eventHandler.GetComponent<AbilityHandler>();
        switch (hoveredButton)
        {
            case "Basic 1":                
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.b1.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Basic 2":                
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.b2.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Smith 1":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.bs1.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Smith 2":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.bs2.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Smith 3":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.bs3.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Leather 1":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.l1.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Leather 2":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.l2.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Leather 3":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.l3.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Cook 1":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.c1.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Cook 2":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.c2.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Cook 3":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.c3.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Carpent 1":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.car1.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Carpent 2":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.car2.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Carpent 3":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.car3.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Gold 1":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.g1.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Gold 2":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.g2.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Gold 3":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.g3.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Jewel 1":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.j1.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Jewel 2":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.j2.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
            case "Jewel 3":
                //Use the HoverText method, using the level set in MenuScript
                descriptionTextBox.text = ah.j3.HoverText(eventHandler.GetComponent<MenuScript>().level);
                break;
        }
    }
}
