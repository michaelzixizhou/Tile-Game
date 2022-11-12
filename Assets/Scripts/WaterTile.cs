using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : Tile
{
    public override void Init()
    {
        SpriteRenderer _spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        _spriterenderer.color = Color.blue;
    }
}
