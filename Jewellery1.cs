using UnityEngine;
using System.Collections;

public class Jewellery1 : Ability {

    //constructor takes in the values for each variable
    public Jewellery1(float c, float p, float d, float w, float s, float i)
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
            h = "Decrease Weight and Sharpness by 10%";
        }
        return h;
    }
}
