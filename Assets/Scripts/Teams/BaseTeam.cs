using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTeam : MonoBehaviour
{
    public string team_name;
    public List<GameObject> units = new List<GameObject>();
    private bool is_turn = false;

    /// <summary>
    /// Add a Unit to the given Team, also assigns the team attribute of the Unit for you.
    /// </summary>
    /// <param name="unit"> The GameObject that you are adding to the Team.</param>
    public void AddUnit(GameObject unit){
        unit.GetComponent<Unit>().SetTeam(this);
        units.Add(unit);
    }

    /// <summary>
    /// Toggles the boolean that allows the Units under this Team to move.
    /// </summary>
    public void ToggleMovement(){
        if (is_turn){
            is_turn = false;
        } else is_turn = true;
    }

    /// <summary>
    /// Returns if it is currently this team's turn, such that their Units can move.
    /// </summary>
    /// <returns>If it is this team's turn</returns>
    public bool IsTurn(){
        return is_turn;
    }
}
