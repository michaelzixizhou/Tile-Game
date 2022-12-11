 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{   
    public bool snapToGrid = true;
    public bool smartDrag = true;
    public bool isDraggable = true;
    public bool isDragged = false;
    public RangeIndicator rangeIndicator;
    private int range;

    Vector2 initialPositionMouse;
    Vector2 initialPositionObject;

    void Start()
    {
        range = gameObject.GetComponent<Unit>().move_range + 1;
        rangeIndicator = gameObject.GetComponent<RangeIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragged){
            var new_pos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!smartDrag){
                transform.position = new_pos;

            } else {
                if(Mathf.Abs(Mathf.RoundToInt(new_pos.y) - Mathf.RoundToInt(initialPositionObject.y)) 
                + Mathf.Abs(Mathf.RoundToInt(new_pos.x) - Mathf.RoundToInt(initialPositionObject.x)) < range)
                {
                    transform.position = new_pos;
                }
            }
            if (snapToGrid) {
                transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
            }
        }
    }

    private void OnMouseOver() {        
        if (isDraggable && Input.GetMouseButtonDown(0)) {
            if (smartDrag) {
                initialPositionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                initialPositionObject = transform.position;
            }
            isDragged = true;
            rangeIndicator.ShowRange();
        }
    }
    private void OnMouseUp() {
        isDragged = false;
        rangeIndicator.HideRange();
    }
}
