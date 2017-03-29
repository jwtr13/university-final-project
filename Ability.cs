using UnityEngine;
using System.Collections;

public class Ability {

    //[SerializeField]
    private float energyCost;
    public float EnergyCost { get { return energyCost; } set { energyCost = value; } }
    //[SerializeField]
    private float progress;
    public float Progress { get { return progress; } set { progress = value; } }
    //[SerializeField]
    private float durability;
    public float Durability { get { return durability; } set { durability = value; } }
    //[SerializeField]
    private float weight;
    public float Weight { get { return weight; } set {weight = value; } }
    //[SerializeField]
    private float sharpness;
    public float Sharpness { get { return sharpness; } set { sharpness = value; } }
    //[SerializeField]
    private float intricacy;
    public float Intricacy { get { return intricacy; } set { intricacy = value; } }

    public virtual float[] UseAbility (float[] defaults)
    {
        Debug.Log("use ability");
        Debug.Log("Energy cost is " + EnergyCost);
        //this method will be called when an ability is used
        //it will take in a float array of the current energy, progress, durability, weight, sharpness and intricacy values
        //and modify them depending on the values of the ability that has been pressed
        //the default for this method is here
        float[] values = new float[6];
        //the energy level is decreased
        values[0] = defaults[0] - energyCost;
        Debug.Log("Current " + values[0] + " = " + defaults[0] + " - " + energyCost);
        //the values are increased by the amount set for each ability
        values[1] = defaults[1] + progress;
        values[2] = defaults[2] + durability;
        values[3] = defaults[3] + weight;
        values[4] = defaults[4] + sharpness;
        values[5] = defaults[5] + intricacy;
        return values;
    }

    public virtual string HoverText(int level)
    {
        string h = "Hover over an ability button to find out more.";
        return h;
    }
}