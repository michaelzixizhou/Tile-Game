using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : Unit
{
    void Awake()
    {
        max_health = 3;
        move_range = 4;
        AddHPBar();
    }
    public override void Ability() {
        
    }
}
