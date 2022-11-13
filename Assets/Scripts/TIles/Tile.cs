using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridTile : MonoBehaviour
{
    [SerializeField] private GameObject _highlight;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    public GridTile up = null;
    public GridTile down = null;
    public GridTile left = null;
    public GridTile right = null;

    // Adds reference to its own SpriteRenderer
    public virtual void Init() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
    }
    private void OnMouseEnter() {
        _highlight.SetActive(true);
    }

    private void OnMouseExit() {
        _highlight.SetActive(false);
    }

    // Changes the current Tile's sprite to input sprite
    public void ChangeSprite(Sprite sprite) {
        spriteRenderer.sprite = sprite;
    }
}
