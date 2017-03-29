using UnityEngine;
using System.Collections;

public class Jewellery2 : Ability {

    //constructor takes in the values for each variable
    public Jewellery2(float c, float p, float d, float w, float s, float i)
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
            h = "Alter Quality to increase Progress.";
        }
        else
        {
            h = "Reduce all Quality aspects by 5% to increase Progress by 10%";
        }
        return h;
    }
}
