using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCard : MonoBehaviour
{
    private Vector2 initPos;
    private Quaternion initRot;
    private bool isDragging = false;
    private Vector2 offset;
    private bool isInDropZone=false;
    void Start()
    {
        initPos = transform.position;
        initRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position=mousePos+offset; 
        }

    }
    private void OnMouseDown()
    {
        isDragging = true;
        offset = (Vector2)transform.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0f; // Ensure the card remains on the same Z position
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;

            // Check if the card is over the drop zone
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("CardDropZone"))
                {
                    // Card is dropped in the drop zone
                    return;
                }
            }

            // Card is not dropped in the drop zone, return to initial position
            transform.position = initPos;
            transform.rotation = initRot;
        }

    }

}
