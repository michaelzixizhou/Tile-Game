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
        health = 5;
        move_range = 2;
    }
    public override void Ability() {
        
    }
}
