using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Unit
{    
    void Awake()
    {
        max_health = 5;
        move_range = 3;
        AddHPBar();
    }

    public override void Ability() {
        
    }
}
