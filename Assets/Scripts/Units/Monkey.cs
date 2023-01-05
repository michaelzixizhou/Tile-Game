using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : Unit
{
    void Awake()
    {
        max_health = 3;
        move_range = 4;
        SetHP(max_health);
    }
    public override void Ability() {
        
    }
}
