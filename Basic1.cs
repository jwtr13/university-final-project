using UnityEngine;
using System.Collections;

public class Basic1 : Ability {

    //constructor takes in the values for each variable
    public Basic1(float c, float p, float d, float w, float s, float i)
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
        if (level < 25)
        {
            h = "Slightly increase Progress.";
        }
        else
        {
            h = "Increase Progress by 5%";
        }
        return h;
    }
}
