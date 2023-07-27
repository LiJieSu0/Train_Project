using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Vector3 _initPos;
    private void Start()
    {
        _initPos= transform.position; 
    }
    void OnMouseDown()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the offset between the object's position and the mouse position
        offset = transform.position - mousePosition;
        Debug.Log(offset);
        // Set the dragging flag to true
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Get the current mouse position in world coordinates
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Set the object's position based on the mouse position and the offset
            transform.position = currentMousePosition + offset;
        }
    }

    void OnMouseUp()
    {
        GameObject bumped = EventObserver.currObj;
        if(bumped != null)
        {
            transform.parent= bumped.transform;
            transform.localPosition=new Vector3(0,0,0);
        }
        else
        {
            transform.position = _initPos;
        }
        isDragging = false;
    }
}
