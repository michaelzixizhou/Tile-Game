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
    private Dictionary<string, GameObject> unitList = new Dictionary<string, GameObject>();
    private Dictionary<Vector2, GameObject> unitPositions = new Dictionary<Vector2, GameObject>();
    private Sprite[] spriteArray;


    private void Awake() {
        instance = this;
        spriteArray = Resources.LoadAll<Sprite>("Characterset1");
    }

    /// <summary>
    /// Spawns a Unit based on the name given, at the position given
    /// </summary>
    /// <param name="name">name of the unit in string format. E.g Gorilla</param>
    /// <param name="pos">position of the unit in Vector2</param>
    public void SpawnUnit(string name, Vector2 pos) {
        GameObject spawnedUnit = new GameObject();
        unitList.Add(name, spawnedUnit);
        unitPositions.Add(pos, spawnedUnit);
        // Sorting order, script component, and name
        spawnedUnit.name = name;
        spawnedUnit.AddComponent<SpriteRenderer>();
        spawnedUnit.GetComponent<SpriteRenderer>().sortingOrder = 20;

        AddScriptAndSprite(spawnedUnit, name);
        // Position of character
        spawnedUnit.transform.position = pos;
        // Box collider size
        spawnedUnit.AddComponent<BoxCollider2D>();
        spawnedUnit.GetComponent<BoxCollider2D>().size = Vector2.one;
        // Drag and drop scripts
        spawnedUnit.AddComponent<DragAndDropController>();
        spawnedUnit.AddComponent<RangeIndicator>();
    }
    
    // helper for spawnUnit, adds the script for given unit name
    private void AddScriptAndSprite(GameObject unit, string script) {
        switch(script) {
            case "Gorilla":
                unit.AddComponent<Gorilla>();
                unit.GetComponent<SpriteRenderer>().sprite = spriteArray[2];
                break;
            case "Monkey":
                unit.AddComponent<Monkey>();
                unit.GetComponent<SpriteRenderer>().sprite = spriteArray[1];
                break;
            case "Cow":
                unit.AddComponent<Cow>();
                unit.GetComponent<SpriteRenderer>().sprite = spriteArray[0];
                break;
            case "Toucan":
                unit.AddComponent<Toucan>();
                unit.GetComponent<SpriteRenderer>().sprite = spriteArray[3];
                break;
            case "Dummy":
                unit.AddComponent<Dummy>();
                unit.GetComponent<SpriteRenderer>().sprite = spriteArray[1];
                break;
            default:
                print("An animal with this name does not exist");
                break;
        }
    }

    public GameObject GetUnit(string name){
        return unitList[name];
    }

    public GameObject GetUnit(Vector2 coord){
        return unitPositions[coord];
    }

    public void TestSpawn(){
        SpawnUnit("Monkey", new Vector2(1, 1));
        SpawnUnit("Cow", new Vector2(3, 2));
        SpawnUnit("Toucan", new Vector2(4, 5));
        SpawnUnit("Gorilla", new Vector2(3, 3));
        SpawnUnit("Dummy", new Vector2(6, 6));
    }
}
