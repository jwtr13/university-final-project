using UnityEngine;
using System.Collections;

public class Leatherwork1 : Ability
{
    //constructor takes in the values for each variable
    public Leatherwork1(float c, float p, float d, float w, float s, float i)
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
            h = "Increase quality slightly.";
        }
        else
        {
            h = "Increase the item's intricacy by 5%";
        }
        return h;
    }
}
