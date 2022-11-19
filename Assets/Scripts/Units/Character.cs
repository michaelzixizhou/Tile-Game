using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is the base character class universal variables such as health, move_range can be found here
*/

public class Unit : MonoBehaviour
{
    public int health;  
    public int move_range;
    
    //unit ability attack etc
    public virtual void Ability() { 
    }

}
