using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int rows = 8;
    [SerializeField]
    private int cols = 10;
    [SerializeField]
    private float tileSize = 1;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid() {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("grasstile"));
        for (int row = 0; row < rows; row++){
            for (int col = 0; col < cols; col++){
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);
                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(referenceTile);

        float gridW = cols * tileSize;
        float gridH = rows * tileSize;
        transform.position = new Vector2(-gridW/2 + tileSize/2 + 0.5f, gridH/2 - tileSize/2 - 0.5f);
    }
}
