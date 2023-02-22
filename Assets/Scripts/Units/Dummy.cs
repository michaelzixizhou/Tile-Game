using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Unit
{
    void Awake()
    {
        max_health = 10;
        move_range = 1;
        AddHPBar();
    }
    public override void Ability() {
        
    }
}
