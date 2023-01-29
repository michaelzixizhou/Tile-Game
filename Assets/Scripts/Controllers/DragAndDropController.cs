 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{   
    public bool snapToGrid = true;
    public bool smartDrag = true;
    public bool isDraggable = false;
    public bool isDragged = false;
    public bool isSelected = false;
    public bool mouseUp = true;
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
        //if (isDragged){
            var new_pos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!smartDrag){
                transform.position = new_pos;

            } else {
                if (rangeIndicator.inRange(Mathf.RoundToInt(new_pos.x), Mathf.RoundToInt(new_pos.y))){
                    transform.position = new_pos;
                } else if (!isDraggable){
                    transform.position = initialPositionObject;
                }
            }
            if (snapToGrid) {
                transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
            }
        //}
        if (!isDraggable && !isSelected && Input.GetMouseButton(0) && mouseUp) {
            isSelected = true;
            rangeIndicator.ShowRange();
            mouseUp = false;
        } else if (!isDraggable && isSelected && Input.GetMouseButton(0) && mouseUp){
            isSelected = false;
            initialPositionObject = transform.position;
            rangeIndicator.HideRange();
            mouseUp = false;
        }
        if(!Input.GetMouseButton(0)){
            mouseUp = true;
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
        if(isDraggable) {
            isDragged = false;
            rangeIndicator.HideRange();
        }
    }
}
