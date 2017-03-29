using UnityEngine;
using System.Collections;

public class Cooking1 : Ability {

    //constructor takes in the values for each variable
    public Cooking1(float c, float p, float d, float w, float s, float i)
    {
        EnergyCost = c;
        Progress = p;
        Durability = d;
        Weight = w;
        Sharpness = s;
        Intricacy = i;
    }

    public override string HoverText(int level)
    {
        string h;
        if (level < 50)
        {
            h = "Restore some Energy.";
        }
        else
        {
            h = "Restore 5% of your Energy.";
        }
        return h;
    }
}
