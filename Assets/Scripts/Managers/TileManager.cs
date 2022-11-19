using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/*
Existing tile library for comparisons and grid initialization
*/
public class TileManager : MonoBehaviour
{
    public static TileManager instance;
    [SerializeField] private VoidTile voidTile;
    [SerializeField] private WaterTile waterTile;
    [SerializeField] private GrassTile grassTile;
    [SerializeField] private HillTile hillTile;
    [SerializeField] private MountainTile mountainTile;
    [SerializeField] private Tile voidtileprefab;
    [SerializeField] private Tile watertileprefab;
    [SerializeField] private Tile grasstileprefab;
    [SerializeField] private Tile hilltileprefab;
    [SerializeField] private Tile mountaintileprefab;
     
    private void Awake() {
        instance = this;
    }
    /*
    Returns the tile type at given location in elevation map
    Used to initialize the board

    Each color indicates a different elevation:
    -2: Grey
    -1: Blue
    0: Green
    1: Yellow
    2: Red
    The colors used are the built in Color.insertcolor ones
    */
    public GridTile assignTile(Vector3 pos, Tilemap tilemap) {
        Vector3Int changedpos = Vector3Int.FloorToInt(pos);
        TileBase currtile = tilemap.GetTile(changedpos);

        if (currtile == grasstileprefab) {
            return grassTile;
        } else if (currtile == hilltileprefab) {
            return hillTile;
        } else if (currtile == watertileprefab) {
            return waterTile;
        } else if (currtile == mountaintileprefab) {
            return mountainTile;
        } else if (currtile == voidtileprefab) {
            return voidTile;
        } else {
            print("Tile not found at assignTile!");
            return null;
        }
    }

}
