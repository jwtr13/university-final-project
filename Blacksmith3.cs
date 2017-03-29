using UnityEngine;
using System.Collections;

public class Blacksmith3 : Ability {
    //constructor takes in the values for each variable
    public Blacksmith3(float c, float p, float d, float w, float s, float i)
    {
        EnergyCost = c;
        Progress = p;
        Durability = d;
        Weight = w;
        Sharpness = s;
        Intricacy = i;
    }

    //special ability
    //increase progress by 10%, if within 15% of completion, complete instantly

    public override float[] UseAbility (float[] defaults)
    {        
        float[] values = new float[6];
        values[0] = defaults[0] - EnergyCost;
        //this method needs to check the current progress value
        //if it is 85 or higher, then it is instantly set to 100
        //if not, it will just be increased by the value set in AbilityHandler
        if (defaults[1] >= 85)
        {
            values[1] = 100;
        }
        else
        {
            values[1] = defaults[1] + Progress;
        }
        //set the rest of the values array as normal
        values[2] = defaults[2] + Durability;
        values[3] = defaults[3] + Weight;
        values[4] = defaults[4] + Sharpness;
        values[5] = defaults[5] + Intricacy;
        return values;
    }

    public override string HoverText(int level)
    {
        string h;
        if (level < 50)
        {
            h = "Increase Progress greatly.";
        }
        else
        {
            h = "Increase the progress by 10%. If you are within 15% of completing the item, the item is completed instantly.";
        }
        return h;
    }
}
