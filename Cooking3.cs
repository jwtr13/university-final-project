using UnityEngine;
using System.Collections;

public class Cooking3 : Ability {

    //constructor takes in the values for each variable
    public Cooking3(float c, float p, float d, float w, float s, float i)
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
            h = "Increase the item's Quality.";
        }
        else
        {
            h = "Increase the Intricacy by 5%.";
        }
        return h;
    }
}
