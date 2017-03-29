using UnityEngine;
using System.Collections;

public class Leatherwork3 : Ability
{
    //constructor takes in the values for each variable
    public Leatherwork3(float c, float p, float d, float w, float s, float i)
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
            h = "Increase quality, but reduce progress.";
        }
        else
        {
            h = "Increase the Durability and Intricacy aspects of the item by 5% each, but decrease progress by 10%";
        }
        return h;
    }
}
