using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class P_Merchant : Player
{
    enum state
    {
        btnSelecting,
        targetSelecting,
        skillCasting,
        finished,
    }
    private state _currState=state.btnSelecting;
    private BasicSkill _selectedSkill=null;
    private FieldPosition targetPos=FieldPosition.NULL;
    public class Smash : BasicSkill
    {
        public float damage = 50;
        public Smash(string skillName)
        {
            _skillName= skillName;
            _availablePosList.Add(FieldPosition.E_FB);
            _availablePosList.Add(FieldPosition.E_FM);
            _availablePosList.Add(FieldPosition.E_FT);
        }
    }
    void Start()
    {
        initBtnList();
        Smash merchantSmash = new Smash("Merchant Smash!");
        setSkill1(skillBtnList[0],merchantSmash);
        skillBtnList[1].onClick.AddListener(skill2);
        skillBtnList[2].onClick.AddListener(skill3);
        skillBtnList[3].onClick.AddListener(skill4);
        GameEvents.current.onClickTarget += getPos;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_currState);
        switch (_currState)
        {
            case state.btnSelecting:
                Debug.Log("Player is thinking");
                break;
            case state.targetSelecting:
                if (Input.GetMouseButtonDown(1))
                {
                    foreach(var i in _selectedSkill._availablePosList)
                    {
                        GameEvents.current.hideTargetPos(i);
                    }
                    _currState = state.btnSelecting;
                    break;
                }
                Debug.Log("targetPos " + targetPos);
                break;
            case state.skillCasting:

                Debug.Log("some casting animation");
                break;
            case state.finished:
                Debug.Log("goto next moving creature");
                break;
            default:
                Debug.Log("Player default State");
                break;
        }
    }
    public void setSkill1(Button btn1,BasicSkill skill)
    {
        btn1.gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = skill._skillName;
        btn1.onClick.AddListener(()=>skill1Func(skill));
        //TODO make decision, attack or not cancel action
        //
    }
    public void skill2()
    {

    }
    public void skill3()
    {

    }
    public void skill4()
    {

    }
    public void skill1Func(BasicSkill skill) {
        Debug.Log("skill1 Pressed");
        _selectedSkill = skill;
        _currState = state.targetSelecting;
        foreach(var i in skill._availablePosList)
        {
            GameEvents.current.showTargetPos(i);
        }
        //TODO show available position;
    }

    public void getPos(FieldPosition pos)
    {
        targetPos = pos;
    }
}
