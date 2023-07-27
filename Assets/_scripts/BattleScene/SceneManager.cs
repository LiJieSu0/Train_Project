using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private List<IATBobject> objList=new List<IATBobject>();
    public GameObject player; //Temp for testing
    public bool isFinished=false;
    private void Awake()
    {
        objList.Add(player.GetComponent<IATBobject>());
    }
    void Start()
    {
    }

    void Update()
    {
    }
    public List<IATBobject> getActionList()
    {
        return objList;
    }
}
