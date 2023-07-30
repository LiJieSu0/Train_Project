using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private List<IATBobject> objList=new List<IATBobject>();
    public GameObject player; //Temp for testing
    public GameObject enemy;
    public bool isFinished=false;
    private void Awake()
    {
        objList.Add(player.GetComponent<IATBobject>());
        objList.Add(enemy.GetComponent<IATBobject>());
    }
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                GameObject clickedObject = hit.transform.gameObject;
                Debug.Log("Left mouse button clicked on: " + clickedObject.name);
            }
        }
    }
    public List<IATBobject> getActionList()
    {
        return objList;
    }
}
