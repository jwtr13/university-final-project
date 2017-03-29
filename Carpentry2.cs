using UnityEngine;
using System.Collections;

public class Carpentry2 : Ability {

    //constructor takes in the values for each variable
    public Carpentry2(float c, float p, float d, float w, float s, float i)
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
            h = "Decrease the item's Intricacy by 10% to increase Durability by 10%";
        }
        return h;
    }
}
