using UnityEngine;
using System.Collections;

public class Blacksmith1 : Ability
{
    //constructor takes in the values for each variable
    public Blacksmith1(float c, float p, float d, float w, float s, float i)
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
            h = "Alter the Quality.";
        }
        else
        {
            h = "Increase the item's sharpness by 30%, but reduce the weight by 15%";
        }
        return h;
    }
}
