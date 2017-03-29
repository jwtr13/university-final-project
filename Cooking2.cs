using UnityEngine;
using System.Collections;

public class Cooking2 : Ability {

    //constructor takes in the values for each variable
    public Cooking2(float c, float p, float d, float w, float s, float i)
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
            h = "Increase Progress.";
        }
        else
        {
            h = "Increase Progress by 10%.";
        }
        return h;
    }
}
