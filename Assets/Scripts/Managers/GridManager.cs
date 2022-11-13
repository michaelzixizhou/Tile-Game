using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private GridTile _grasstile, _watertile;
    [SerializeField] private Transform _cam;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GameObject tm_manager; 
    
    private Dictionary<Vector2, GridTile> _tiles = new Dictionary<Vector2, GridTile>();

    // Start is called before the first frame update
    void Start()
    { 
        generateGrid();
        assignSprites();
    }

    void generateGrid() {
        // Creating grid
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var randomTile = Random.Range(0, 6) == 3 ? _watertile : _grasstile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.Init();
                _tiles.Add(new Vector2(x, y), spawnedTile);
            }
        }

        // Assigning direction pointers for each tile
        foreach (Vector2 pos in _tiles.Keys) {
            GridTile currtile = _tiles[pos];
            
            if (_tiles.ContainsKey(pos + Vector2.up)) {
                currtile.up = _tiles[pos + Vector2.up];
            }
            if (_tiles.ContainsKey(pos + Vector2.down)) {
                currtile.down = _tiles[pos + Vector2.down];
            }
            if (_tiles.ContainsKey(pos + Vector2.left)) {
                currtile.left = _tiles[pos + Vector2.left];    
            }
            if (_tiles.ContainsKey(pos + Vector2.right)) {
                currtile.right = _tiles[pos + Vector2.right];
            }
            
        }
        float displaceX = _width/2 - 0.5f;
        float displaceY = _height/2 - 0.5f;
        
        // no longer need tilemap transform since sprites are integrated with grid
        Vector3 tilemappos =  new Vector3(displaceX, displaceY, 0);

        tilemap.transform.Translate(tilemappos);
        // tilemap.origin = Vector3Int.FloorToInt(tilemappos)
        _cam.transform.position = new Vector3(displaceX, displaceY, -10);
    }

    /* 
    Assigns each Tile from Tilemap at each position to the corresponding tiles at Grid
    */
    void assignSprites() {
        foreach (Vector2 pos in _tiles.Keys) {
            Vector3Int changedpos = Vector3Int.FloorToInt(pos);
            Sprite currsprite = tilemap.GetSprite(changedpos);
            getTileAt(pos).ChangeSprite(currsprite);
        }
        tm_manager.SetActive(false);
    }

    public GridTile getTileAt(Vector2 pos) {
        if (_tiles.TryGetValue(pos, out var tile)) {
            return tile;
        } 
        return null;
    }
}
