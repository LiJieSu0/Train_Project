using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Vector3 _initPos;
    private bool _isDraggable;
    private void Start()
    {
        _isDraggable = true; //TODO only in deploy stage;
        _initPos= transform.position; //TODO set as the first position in prepartion area.
    }
    void OnMouseDown()
    {
        if(!_isDraggable)
            return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (!_isDraggable)
            return;
        if (isDragging)
        {
            // Get the current mouse position in world coordinates
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Set the object's position based on the mouse position and the offset
            transform.position = currentMousePosition + offset;
        }
    }

    //void OnMouseUp()
    //{
    //    if (!_isDraggable)
    //        return;
    //    GameObject bumped = EventObserver.currObj;
        
    //    if(bumped != null&& bumped.transform.parent.gameObject.name == "PlayerField")
    //    {
    //        transform.parent= bumped.transform;
    //        transform.localPosition=new Vector3(0,0,0);
    //    }
    //    else
    //    {
    //        transform.position = _initPos;
    //    }
    //    isDragging = false;
    //}
}
