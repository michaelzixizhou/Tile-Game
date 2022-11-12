using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] public GameObject _highlight;
    public Tile up = null;
    public Tile down = null;
    public Tile left = null;
    public Tile right = null;

    // Start is called before the first frame update
    public virtual void Init() {
    }
    private void OnMouseEnter() {
        _highlight.SetActive(true);
    }

    private void OnMouseExit() {
        _highlight.SetActive(false);
    }
}
