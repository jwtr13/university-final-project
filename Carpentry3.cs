using UnityEngine;
using System.Collections;

public class Carpentry3 : Ability {

    //constructor takes in the values for each variable
    public Carpentry3(float c, float p, float d, float w, float s, float i)
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
            h = "Increase the Progress, but change the Quality.";
        }
        else
        {
            h = "Increase the Progress by 5% by decreasing the Weight by 10%";
        }
        return h;
    }
}
