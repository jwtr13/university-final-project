using UnityEngine;
using System.Collections;

public class Blacksmith2 : Ability
{
    //constructor takes in the values for each variable
    public Blacksmith2(float c, float p, float d, float w, float s, float i)
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
            h = "Increase progress, at the cost of some quality.";
        }
        else
        {
            h = "Increase the progress by 10%, but reduce the quality by around 10%";
        }
        return h;
    }
}
