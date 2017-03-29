using UnityEngine;
using System.Collections;

public class Goldsmithing1 : Ability {

    //constructor takes in the values for each variable
    public Goldsmithing1(float c, float p, float d, float w, float s, float i)
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
            h = "Increase the Quality.";
        }
        else
        {
            h = "Increase Durability by 5%";
        }
        return h;
    }
}
