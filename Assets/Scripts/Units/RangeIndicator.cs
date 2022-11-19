using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script controls the range indicator of the characters
*/

public class RangeIndicator : MonoBehaviour
{
    [SerializeField] public RangeTile _range;

    public Vector3 pos;

    public int range;

    private List<RangeTile> _range_tiles = new List<RangeTile>();

    private bool isOn = false;

    //Get the range variable from the character script
    void Start()
    {
       range = gameObject.GetComponent<Unit>().move_range;
    }

    void OnMouseDown(){
        //if the range indicator is not on yet
        if (!isOn){
            //get the position of the character
            pos = gameObject.GetComponent<Transform>().position;
            //goes through a sqaure of range x range to find the indicator tiles
            for(int x = 0; x < 2 * range + 1; x++)
            {
                for(int y = 0; y < 2 * range + 1; y++){
                    //if the absoluate value of the x and y coordinates is less than or equal to the range the tile should be higlighted
                    if (Mathf.Abs(x - range) + Mathf.Abs(y - range) <= range){
                        var spawnedTile = Instantiate(_range, new Vector3(pos.x + x - range, pos.y + y - range), Quaternion.identity);
                        spawnedTile.name = $"Tile {x} {y}";
                        //adds tiles to list so we can delete later
                        _range_tiles.Add(spawnedTile);
                    }
                }
            }
            isOn = true;
        //if range indicator is already on
        }else{
            //destroys all range tiles and isOn is set to false
            while(_range_tiles.Count > 0){
                Destroy(_range_tiles[0].gameObject);
                _range_tiles.RemoveAt(0);
            }
            isOn = false;
        }
        
    }
}
