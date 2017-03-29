using UnityEngine;
using System.Collections;

public class Jewellery3 : Ability {

    //constructor takes in the values for each variable
    public Jewellery3(float c, float p, float d, float w, float s, float i)
    {
        EnergyCost = c;
        Progress = p;
        Durability = d;
        Weight = w;
        Sharpness = s;
        Intricacy = i;
    }

    //special ability
    //Completely reduce progress, and max out intricacy

    public override float[] UseAbility(float[] defaults)
    {
        float[] values = new float[6];
        values[0] = defaults[0] - EnergyCost;
        //this method needs reset the progress to 0
        //if not, it will just be increased by the value set in AbilityHandler
        values[1] = 0;
        //set the rest of the values array as normal
        values[2] = defaults[2] + Durability;
        values[3] = defaults[3] + Weight;
        values[4] = defaults[4] + Sharpness;
        //intricacy needs to be set to the max
        values[5] = 100;
        return values;
    }

    public override string HoverText(int level)
    {
        string h;
        if (level < 50)
        {
            h = "Hugely increase the item's Quality, at a severe cost to the Progress.";
        }
        else
        {
            h = "Reset Progress to 0, to fully increase the Intricacy of the item.";
        }
        return h;
    }
}
