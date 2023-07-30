﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus:MonoBehaviour,IATBobject,Iinfo
{
    [SerializeField] private string _charName;
    [SerializeField] private float baseProgressionSpeed;
    [SerializeField] private float _MaxHP;
    [SerializeField] private float _CurrHP;
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
    private GameObject CommandMenu;
    private GameObject UICanvas;
    private GameObject HealthBar;



    public CharacterStatus() {
    }
    public void Start()
    {
        UICanvas = transform.Find("CharacterUICanvas").gameObject;
        CommandMenu = UICanvas.transform.Find("CommandMenu").gameObject;
        HealthBar = UICanvas.transform.Find("HealthBar").gameObject;
        
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
        CommandMenu.SetActive(true);
        commandBtnFunc();
        //TODO set button function
    }
    public void commandBtnFunc() //take list of skills? ISkill 
    {
        
        int btnCount= CommandMenu.transform.childCount;
        List<Button> btnList=new List<Button>();
        for(int i=0; i<btnCount; i++)//Btn function here
        {
            GameObject tmp = CommandMenu.transform.GetChild(i).gameObject;
            Button tmpBtn = tmp.GetComponent<Button>();
            tmpBtn.onClick.AddListener(()=>tempBtnFunc(tmp.name));
            btnList.Add(tmpBtn);
        }
    }
    private void tempBtnFunc(string name)
    {
        switch (name)
        {
            case "Fire":
                break;
            case "Move":
                Debug.Log("Move!!");
                break;
            case "End":
                Debug.Log("End!!");
                break;
            default:
                Debug.Log("some command button");
                break;
        }

    }

    private IEnumerator FireButtonFunc()
    {
        /*
         
         */
        yield return null;
    }

    public float getCurrHealth() {
        return _CurrHP;
    }
    public float getMaxHealth()
    {
        return _MaxHP;
    }

    private void OnMouseEnter()
    {
        HealthBar.SetActive(true);
    }
    private void OnMouseExit()
    {
        //TODO hide Healthbar
        HealthBar.SetActive(false);

        Debug.Log("Hide HealthBar");
    }

}
