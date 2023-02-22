 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{   
    public bool isDraggable = false;
    public bool isSelected = false;
    public RangeIndicator rangeIndicator;
    private int range;
    Vector2 initialPositionObject;

    void Start()
    {
        range = gameObject.GetComponent<Unit>().move_range + 1;
        rangeIndicator = gameObject.GetComponent<RangeIndicator>();
        transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
    }

    // Update is called once per frame
    void Update()
    {
        //update new position to mouse position
        Vector2Int new_pos = Vector2Int.RoundToInt((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
        
        if (rangeIndicator.inRange(new_pos.x, new_pos.y)) {
            transform.position = new Vector2(new_pos.x, new_pos.y);
        } else if (!isDraggable) {
            transform.position = initialPositionObject;
        }
    }

    private void OnMouseDown() {        
        //for dragging movement
        if (isDraggable) {
            initialPositionObject = transform.position;   
            isSelected = true;
            rangeIndicator.ShowRange();
        //for 2 click movement
        } else if (!isDraggable) {
            if (!isSelected) {
                isSelected = true;
                rangeIndicator.ShowRange();
            } else {
                isSelected = false;
                initialPositionObject = transform.position;
                rangeIndicator.HideRange();
            }
        }
    }

    //hide range indicator for dragging movement
    private void OnMouseUp() {
        if (isDraggable && isSelected) {
            isSelected = false;
            initialPositionObject = transform.position;
            rangeIndicator.HideRange();
        }
    }

    //hover range indicator only for dragging movement
    private void OnMouseOver() {
        if(isDraggable && !isSelected){
            rangeIndicator.ShowRange();
        }
    }

    private void OnMouseExit() {
        if(isDraggable && !isSelected){
            rangeIndicator.HideRange();
        }
    }
}
