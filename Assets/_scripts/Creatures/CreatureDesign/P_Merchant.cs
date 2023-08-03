using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class P_Merchant : Player
{

    private PlayerState _currState = PlayerState.noAction;
    private BasicSkill _selectedSkill=null;
    private FieldPosition _targetPos=FieldPosition.NULL;

    

    void Start()
    {
        initBtnList();
        Smash merchantSmash = new Smash("Merchant Smash!");
        setSkill1(skillBtnList[0],merchantSmash);
        skillBtnList[1].onClick.AddListener(skill2);
        skillBtnList[2].onClick.AddListener(skill3);
        skillBtnList[3].onClick.AddListener(skill4);
        GameEvents.current.onClickTarget += setTargetPos;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currState)
        {
            case PlayerState.noAction:
                break;
            case PlayerState.btnSelecting:
                break;
            case PlayerState.targetSelecting:
                if (Input.GetMouseButtonDown(1))
                {
                    foreach(var i in _selectedSkill._availablePosList)
                    {
                        GameEvents.current.hideTargetPos(i);
                    }
                    _currState = PlayerState.btnSelecting;
                    _selectedSkill = null;
                    break;
                }
                //get enemy creature
                Debug.Log("targetPos " + _targetPos);
                if (_targetPos != FieldPosition.NULL) { 
                    dealDamgeToTarget(_selectedSkill);
                }
                break;  
            case PlayerState.skillCasting:

                Debug.Log("some casting animation");
                
                break;
            case PlayerState.finished:
                Debug.Log("goto next moving creature");
                _currState = PlayerState.noAction;
                
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
        _selectedSkill = skill;
        _currState = PlayerState.targetSelecting;
        foreach(var i in skill._availablePosList)
        {
            GameEvents.current.showTargetPos(i);
        }
        //TODO show available position;
    }

    public void setTargetPos(FieldPosition pos)
    {
        if(_currState == PlayerState.targetSelecting)
        {
            _targetPos = pos;
        }
    }

    public void dealDamgeToTarget(BasicSkill skill)
    {
        Smash tmp = (Smash)skill;
        Debug.Log("Damage Dealt to " + tmp.damage+" at position "+_targetPos);
        foreach (var i in _selectedSkill._availablePosList)
        {
            if (i == _targetPos) continue;//TODO change anchor color
            GameEvents.current.hideTargetPos(i);
        }
        _currState = PlayerState.skillCasting;
    }
}
