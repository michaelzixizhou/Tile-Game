using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This will manage unit spawning, both for allies and for enemies

This will be called by GameManager to perform said actions
*/
public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;
    public static ArrayList UnitList = new ArrayList();

    private void Awake() {
        instance = this;
    }
    

    // spawn a unit, NOT WORKING RIGHT NOW
    public void spawnUnit(Unit unit, Vector2 pos) {
        Vector3 currpos = pos;
        var spawnedUnit = Instantiate(unit, currpos, Quaternion.identity);
        UnitList.Add(spawnedUnit);
    }
}
