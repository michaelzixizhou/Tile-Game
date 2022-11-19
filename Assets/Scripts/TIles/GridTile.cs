using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
GRIDTILES SHOULD NOT BE INSTANTIATED ON ITS OWN, USE ITS SUBCLASSES

GridTiles have a pointer in each cardinal direction to its neigbours,
if empty, it is set to null. 

Each GridTile can contain a Unit, otherwise, it is set to null.

Each GridTile has an elevation, use getElevation() to get it.

These tiles are completely transparent until a mouse hovers over them,
them they becoming translucent for a highlight effect.
*/
public class GridTile : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected int elevation;
    public GridTile up = null;
    public GridTile down = null;
    public GridTile left = null;
    public GridTile right = null;
    public Unit containedUnit = null;

    private Color baseColor = new Color(1f, 1f, 1f, 0f);
    private Color onHoverColor = new Color(1f, 1f, 1f, 0.5f);

    // Adds reference to its own SpriteRenderer
    public virtual void Init() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = baseColor;
        spriteRenderer.sortingOrder = 10;
    }

    // Highlight System
    private void OnMouseEnter() {
        spriteRenderer.color = onHoverColor;
    }
    private void OnMouseExit() {
        spriteRenderer.color = baseColor;
    }

    // Returns GridTile elevation integer
    public int getElevation() {
        return elevation;
    }

    // Changes the current Tile's sprite to input sprite
    public void ChangeSprite(Sprite sprite) {
        spriteRenderer.sprite = sprite;
    }
}
