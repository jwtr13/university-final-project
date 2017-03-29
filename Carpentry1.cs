using UnityEngine;
using System.Collections;

public class Carpentry1 : Ability {

    //constructor takes in the values for each variable
    public Carpentry1(float c, float p, float d, float w, float s, float i)
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
            h = "Alter the item's Quality.";
        }
        else
        {
            h = "Decrease the item's Sharpness by 10% to increase Intricacy by 10%";
        }
        return h;
    }
}
