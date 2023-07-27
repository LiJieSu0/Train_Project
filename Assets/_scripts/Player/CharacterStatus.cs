﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus:MonoBehaviour,IATBobject 
{
    [SerializeField] private string _charName;
    [SerializeField] private float baseProgressionSpeed;
    [SerializeField] private float _HP;
    [SerializeField] private float _EP;
    [SerializeField] private float _Strength;
    [SerializeField] private float _Agility;
    [SerializeField][Header("體質")] private float _Constitution;//
    [SerializeField] private float _Intelligence;
    [SerializeField] private float _Perception;
    [SerializeField] private float _Luckey;
    [SerializeField] private float _Apperance;
    [SerializeField] private GameObject _spriteOnBar;
    public bool _isActing=false;
    

    public CharacterStatus() {
    }
    void Update()
    {

    }

    public void createProgression()
    {
        //Nothing todo here, sprite is created in progressBarcontroller
    }
    public void speedAdjust(float adjustment)
    {
        baseProgressionSpeed += adjustment;
    }
    public float baseSpeed {
        get { return baseProgressionSpeed; }
        set { baseProgressionSpeed = value; }
    }
    public string _name {
        get { return _charName; }
        set { _charName = value; } 
    }
    public bool isActing
    {
        get { return _isActing; }
        set { _isActing = value; }
    }
    public GameObject spriteOnBar
    {
        get { return _spriteOnBar; }
        set { _spriteOnBar = value; } 
    }

    public void showCommandMenu()
    {
        Debug.Log("show Command");
        transform.Find("CommandMenu").gameObject.SetActive(true);
        //TODO set button function
    }
}
