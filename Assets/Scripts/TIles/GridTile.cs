using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridTile : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected int elevation;
    public GridTile up = null;
    public GridTile down = null;
    public GridTile left = null;
    public GridTile right = null;

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
