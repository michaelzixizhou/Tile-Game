using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Gorilla character
*/

public class Gorilla : Unit
{
    void Awake()
    {
        max_health = 5;
        move_range = 2;
        SetHP(max_health);
    }
    public override void Ability() {
        
    }

    // private void OnMouseDown() {
    //     TakeHit(1);
    // }
}
