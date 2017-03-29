using UnityEngine;
using System.Collections;

public class Goldsmithing2 : Ability {

    //constructor takes in the values for each variable
    public Goldsmithing2(float c, float p, float d, float w, float s, float i)
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
            h = "Increase Progress and Quality.";
        }
        else
        {
            h = "Increase progress by 2%, intricacy by 5% and weight by 15%";
        }
        return h;
    }
}
