using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script controls the range indicator of the characters
*/

public class RangeIndicator : MonoBehaviour
{
    [SerializeField] public Object _range;

    [SerializeField] public Object _unitSelect;

    private Object unitTile;

    public Vector3 pos;

    private int range;

    private List<Object> _range_tiles = new List<Object>();

    public GridManager grid_manager;

    //floodfill algorithm to find places where the character can move
    public void FloodFill(int x, int y, int moves_left, int prev_tile) {
        int elevation;
        bool new_tile = true;

        //scenarios where we should return
        if (moves_left == 0) return;
        try {
            elevation = grid_manager.GetTileAt(new Vector2(x,y)).getElevation();
        } catch {
            return;
        }
        if (Mathf.Abs(elevation - prev_tile) > 1) return;

        //is this tile not in our list
        for (int i = 0; i < _range_tiles.Count; i++) {
            if (_range_tiles[i].name == $"Tile {x} {y}"){
                new_tile = false;
            }
        }
        
        //spawns new range indicator tile
        if (new_tile) {
            var spawnedTile = Instantiate(_range, new Vector3(x,y), Quaternion.identity);
            spawnedTile.name = $"Tile {x} {y}";
            _range_tiles.Add(spawnedTile);
        }

        // next step four-way
        FloodFill(x + 1, y, moves_left - 1, elevation);
        FloodFill(x - 1, y, moves_left - 1, elevation);
        FloodFill(x, y + 1, moves_left - 1, elevation);
        FloodFill(x, y - 1, moves_left - 1, elevation);
    }

    //get variables on awake
    void Awake()
    {
        range = gameObject.GetComponent<Unit>().move_range + 1;
        _range = Resources.Load("RangeSquare");
        _unitSelect = Resources.Load("UnitSelect");
        grid_manager = GameObject.FindWithTag("GridManager").GetComponent<GridManager>();
    }

    public void ShowRange(){
        pos = gameObject.GetComponent<Transform>().position;
        FloodFill((int) pos.x, (int) pos.y, range, grid_manager.GetTileAt(pos).getElevation());
    }

    public void HideRange(){
        //destroys all range tiles and isOn is set to false
        while(_range_tiles.Count > 0){
            Destroy(_range_tiles[0]);
            _range_tiles.RemoveAt(0);
        }
        Destroy(unitTile);
    }
    /// <summary>
    /// function to see if given position is a legal move based on if it is in range
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool inRange(int x, int y) {
        for (int i = 0; i < _range_tiles.Count; i++) {
            if (_range_tiles[i].name == $"Tile {x} {y}"){
                return true;
            }
        } 
        return false;
    }  
}
