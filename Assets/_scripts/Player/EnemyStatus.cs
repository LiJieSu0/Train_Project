using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour, IATBobject
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

    private bool _isActing;
    void Start()
    {
        
    }
    public float baseSpeed
    {
        get { return baseProgressionSpeed; }
        set { baseProgressionSpeed = value; }
    }
    public string _name
    {
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

    public void createProgression()
    {
        //Nothing todo here, sprite is created in progressBarcontroller
    }
    public void speedAdjust(float adjustment)
    {
        baseProgressionSpeed += adjustment;
    }

}
