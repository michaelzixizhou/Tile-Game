using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is the base character class universal variables such as max_heath, move_range can be found here
*/

public class Unit : MonoBehaviour
{
    public int max_health;
    public int curr_health;
    public int move_range;
    public HealthBarBehaviour healthBar;

    private void Awake() {
        max_health = 1;
        move_range = 1;
        SetHP(max_health);
    }

    protected void SetHP(int HP) {
        curr_health = HP;
        healthBar.SetHPBar(curr_health, max_health);
    }
    
    //unit ability attack etc
    public virtual void Ability() { 
    }

    public void TakeHit(int dmg){
        curr_health -= dmg;
        healthBar.SetHPBar(curr_health, max_health);

        if (curr_health <= 0){
            Destroy(gameObject);
        }
    }

}
