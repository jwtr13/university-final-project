using UnityEngine;
using System.Collections;

public class Goldsmithing3 : Ability {
    //constructor takes in the values for each variable
    public Goldsmithing3(float c, float p, float d, float w, float s, float i)
    {
        EnergyCost = c;
        Progress = p;
        Durability = d;
        Weight = w;
        Sharpness = s;
        Intricacy = i;
    }

    //special ability
    //Round down all quality aspects below 30% to 0
    //Round up all quality aspects above 10% to 100

    public override float[] UseAbility(float[] defaults)
    {
        float[] values = new float[6];
        values[0] = defaults[0] - EnergyCost;
        //no change to progress        
        values[1] = values[1];
        for (int i = 2; i <= 5; i++)
        {
            if (values[i] <= 30)
            {
                values[i] = 0;
            }
            else if (values[i] >= 70)
            {
                values[i] = 100;
            }
            else
            {
                values[i] = values[i];
            }
        }
        return values;
    }

    public override string HoverText(int level)
    {
        string h;
        if (level < 50)
        {
            h = "Hugely alter Quality.";
        }
        else
        {
            h = "For each quality aspect, if the value is 30% or below, it becomes 0. If the value is 70& or higher, it becomes 100%";
        }
        return h;
    }
}
