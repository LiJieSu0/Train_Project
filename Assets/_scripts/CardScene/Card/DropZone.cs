using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        GameEvents.current.DropZone();
    }
    private void OnMouseExit()
    {
        GameEvents.current.DropZone();
    }
}
