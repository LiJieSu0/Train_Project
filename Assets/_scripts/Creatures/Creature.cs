using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creature : MonoBehaviour
{
    //Character Attribute Design
    [SerializeField] protected string _charName;
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
    [SerializeField] public GameObject _CreatureIcon;

    //Character Attribute Design

    //in game attribute
    [SerializeField] public float _CurrHP;
    [SerializeField] public float _CurrEP;
    [SerializeField] public float _CurrProgress=0;
    [SerializeField] public float _TimeToAction=999;

    protected FieldPosition fieldPos;
    public void Awake()
    {
        fieldPos = (FieldPosition)Enum.Parse(typeof(FieldPosition), gameObject.transform.parent.gameObject.name);
        //Get parent position name and turn it into Enum field position
    }

    public virtual void changePos(Creature target)
    {
        //TODO change position with target.
    }

    void Update()
    {

    }
    public FieldPosition getPos()
    {
        return fieldPos;
    }

    public float getSpeed()
    {
        return _Speed;
    }
}
