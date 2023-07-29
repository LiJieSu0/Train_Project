using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus:MonoBehaviour,IATBobject,Iinfo
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
    GameObject panel;



    public CharacterStatus() {
    }
    public void Start()
    {
        panel = transform.Find("CharacterUICanvas").Find("CommandMenu").gameObject;
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
        panel.SetActive(true);
        commandBtnFunc();
        //TODO set button function
    }
    public void commandBtnFunc() //take list of skills? ISkill 
    {
        
        int btnCount=panel.transform.childCount;
        List<Button> btnList=new List<Button>();
        for(int i=0; i<btnCount; i++)//Btn function here
        {
            GameObject tmp = panel.transform.GetChild(i).gameObject;
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
                Debug.Log("Fire!!");
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

    public float getCurrHealth() {
        return _HP;
    }

    private void OnMouseEnter()
    {
        //TODO show Healthbar
        Debug.Log("Show HealthBar");
    }
    private void OnMouseExit()
    {
        //TODO hide Healthbar
        Debug.Log("Hide HealthBar");
    }

}
