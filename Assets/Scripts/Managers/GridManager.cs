using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/*
Use GridManager.GetTileAt() to get tile at Vector2(x, y).
Please check GenerateGrid() documentation for more info
*/
public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    [SerializeField] private int _width, _height;
    [SerializeField] private Transform _cam;
    [SerializeField] private TileManager tileManager;
    [SerializeField] private TilemapManager tilemapManager; 
    
    private Dictionary<Vector2, GridTile> _tiles = new Dictionary<Vector2, GridTile>();

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    { 
        // toggle off the elevation layer
    }

    /// <summary>
    ///     This creates a _width * _height grid that takes in the elevation
    /// map, and instantiates tiles based on the color at (x, y). The
    /// instantiated tiles are then stored in a dictionary of 
    /// Vector2: GridTile format. 
    /// <br/>
    /// Each tile is assigned a pointer to each of its neighbours in 
    /// the directions of Up, Down, Left, Right 
    /// <br/>
    /// Check TileManager.AssignTile() for more documentation on elevation.
    /// Check GridTile for more documentation on pointers
    /// <br/>
    /// ========= PRECONDITIONS =========
    /// <br/>
    /// dimensions of grid == dimensions of tilemaps
    /// </summary>
    public void GenerateGrid() {
        // Creating grid
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                Vector2 currpos = new Vector2(x, y);
                // check tile type from elevation map
                var spawnedTile = Instantiate(tileManager.assignTile(currpos, tilemapManager.elevationTilemap), new Vector3(x, y, 1), Quaternion.identity);
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
        
        tilemapManager.groundTilemap.transform.Translate(tilemappos);
        tilemapManager.abovegroundTilemap.transform.Translate(tilemappos);
        tilemapManager.elevationTilemap.transform.Translate(tilemappos);

        _cam.transform.position = new Vector3(displaceX, displaceY, -10);

        tilemapManager.Toggle(tilemapManager.elevationTilemap, false);
    }

    /// <summary>
    /// O B S O L E T E 
    /// <br/>
    /// Changes each GridTile's sprite to the corresponding sprite of the same coordinates on the Tilemap
    /// </summary>
    private void AssignSprites() {
        foreach (Vector2 pos in _tiles.Keys) {
            Vector3Int changedpos = Vector3Int.FloorToInt(pos);
            Sprite currsprite = tilemapManager.groundTilemap.GetSprite(changedpos);
            GetTileAt(pos).ChangeSprite(currsprite);
        }
    }

    /// <summary>
    /// Get tile at given Vector2 coordinate
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public GridTile GetTileAt(Vector2 pos) {
        if (_tiles.TryGetValue(pos, out var tile)) {
            return tile;
        } 
        return null;
    }
}
