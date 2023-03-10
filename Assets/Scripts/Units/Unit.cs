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
    public BaseTeam curr_team;

    private void Awake()
    {
        max_health = 1;
        move_range = 1;
        AddHPBar();
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
        healthBar.SetHPBar(curr_health);

        var des = false;
        if (curr_health <= 0){
            des = true;
            gameObject.GetComponent<RangeIndicator>().HideRange();

        }
        if (des) Destroy(gameObject);

    }

    protected void AddHPBar() {
        GameObject hp = Instantiate(Resources.Load<GameObject>("HPBar"));
        hp.transform.SetParent(transform);

        healthBar = hp.GetComponent<HealthBarBehaviour>();
        SetHP(max_health);
    }

    public void SetTeam(BaseTeam team){
        curr_team = team;
    }
    // private void OnMouseDown() {
    //     TakeHit(1);
    // }
}
