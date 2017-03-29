using UnityEngine;
using System.Collections;

public class Leatherwork2 : Ability
{
    //constructor takes in the values for each variable
    public Leatherwork2(float c, float p, float d, float w, float s, float i)
    {
        EnergyCost = c;
        Progress = p;
        Durability = d;
        Weight = w;
        Sharpness = s;
        Intricacy = i;
    }

    //special ability
    //increase a random quality aspect by 40% but decrease another by 20%
    public override float[] UseAbility(float[] defaults)
    {
        float[] values = new float[6];
        values[0] = defaults[0] - EnergyCost;
        values[1] = defaults[1] + Progress;
        //this method needs to randomly choose 2 qualities and increase one by 40 and the other by 20
        int rIncrease;
        int rDecrease;
        bool selected = false;
        while (!selected)
        {
            rIncrease = Random.Range(2, 5);
            rDecrease = Random.Range(2, 5);
            if (rIncrease != rDecrease)
            {
                values[rIncrease] = defaults[rIncrease] + 40;
                values[rDecrease] = defaults[rDecrease] - 20;
                selected = true;
            }
        }
        return values;
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
            h = "Increase a random aspect of the item's quality by 40%, but decrease another by 20%";
        }
        return h;
    }
}
