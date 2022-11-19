using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/*
Overarching manager for Tilemaps, used to get tilemaps
and toggle their visibility
*/
public class TilemapManager : MonoBehaviour
{
    public static TilemapManager instance;

    [SerializeField] public Tilemap groundTilemap;
    [SerializeField] public Tilemap abovegroundTilemap;
    [SerializeField] public Tilemap elevationTilemap;

    private void Awake() {
        instance = this;
    }

    public void Toggle(Tilemap tilemap, bool tog) {
        tilemap.gameObject.SetActive(tog);
    }
}
