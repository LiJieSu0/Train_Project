using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creature : MonoBehaviour
{
    //Character Attribute Design
    [SerializeField] public string _CharName;
    [SerializeField] protected float _Speed;
    [SerializeField] protected float _MaxHP;
    [SerializeField] protected float _MaxEP;
    [SerializeField] protected float _Strength;
    [SerializeField] protected float _Agility;
    [SerializeField][Header("體質")] protected float _Constitution;//
    [SerializeField] protected float _Intelligence;
    [SerializeField] protected float _Perception;
    [SerializeField] protected float _Luckey;
    [SerializeField] protected float _Apperance;
    [SerializeField] public string ID;
    [SerializeField] public Texture _CreatureIcon;

    //Character Attribute Design

    //in game attribute
    public float _CurrHP;
    public float _CurrEP;
    public float _CurrProgress;
    public float _TimeToAction;

    public FieldPosition _fieldPos;
    public void Awake()
    {
        //fieldPos = (FieldPosition)Enum.Parse(typeof(FieldPosition), gameObject.transform.parent.gameObject.name);
        //Get parent position name and turn it into Enum field position
    }

    public virtual void changePos(Creature target)
    {
        //TODO change position with target.
    }

    void Update()
    {

    }


    public float getSpeed()
    {
        return _Speed;
    }

}
