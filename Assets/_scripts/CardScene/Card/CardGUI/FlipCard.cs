using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    private bool isFlipped = true; //default is back;
    private GameObject front;
    private GameObject back;
    void Start()
    {
        front=transform.GetChild(0).gameObject;
        back=transform.GetChild(1).gameObject;
        back.SetActive(isFlipped);
        front.SetActive(!isFlipped);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void flip()
    {
        isFlipped = !isFlipped;
        back.SetActive(isFlipped);
        front.SetActive(!isFlipped);
    }
    private void OnMouseUp()
    {

    }
}
