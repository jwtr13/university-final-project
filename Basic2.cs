using UnityEngine;
using System.Collections;

public class Basic2 : Ability
{
    //constructor takes in the values for each variable
    public Basic2(float c, float p, float d, float w, float s, float i)
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
            h = "Slightly increase quality.";
        }
        else
        {
            h = "Increase each aspect of the item's quality by 1%";
        }
        return h;
    }
}
