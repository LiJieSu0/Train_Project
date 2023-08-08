using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Creature
{
    public PlayerState _currPlayerState = PlayerState.noAction;
    private BasicSkill _selectedSkill = null;
    private FieldPosition _targetPos = FieldPosition.NULL;
    protected GameObject commandPanel;
    protected List<Button> skillBtnList= new List<Button>();
    [SerializeField] protected BasicSkill _firstSkill;
    [SerializeField] protected BasicSkill _secondSkill;
    [SerializeField] protected BasicSkill _thirdSkill;
    [SerializeField] protected BasicSkill _forthSkill;

    [SerializeField] protected Vector3 _offset;

    private void Start()
    {
        GameEvents.current.onClickTarget += setTargetPos;
        GameEvents.current.onTurnChange += setPlayerStart;
        initBtnList();
        if(healthBar != null ) //TODO resize healthbar and change the position
        _healthBar = Instantiate(healthBar, GameObject.Find("Canvas").transform);


    }


    // Update is called once per frame
    void Update()
    {

        if (healthBar != null)
        {
            Vector3 characterScreenPos=Camera.main.WorldToScreenPoint(this.gameObject.transform.position)+_offset;
            RectTransform tmp=_healthBar.GetComponent<RectTransform>();
             tmp.position= characterScreenPos;
        }

        switch (_currPlayerState)
        {
            case PlayerState.noAction:
                //some idle animation
                break;
            case PlayerState.btnSelecting:
                setSkillBtn(_firstSkill,0);
                setSkillBtn(_secondSkill,1);
                setSkillBtn(_thirdSkill,2);
                setSkillBtn(_forthSkill,3);
                //TODO show button on command panel

                break;
            case PlayerState.targetSelecting:
                cancelSelecting();
                selectTargetType();
                break;
            case PlayerState.skillCasting:

                Debug.Log("some casting animation");
                _currPlayerState = PlayerState.finished;
                break;
            case PlayerState.finished:
                Debug.Log("goto next moving creature");
                _currPlayerState = PlayerState.noAction;
                SceneManager._sceneManager._currPlayer = null;
                SceneManager._sceneManager.setSceneStateCal();
                break;

        }
    }

    private void initBtnList()
    {
        commandPanel = GameObject.Find("CommandPanel");
        for (int i = 0; i < commandPanel.transform.childCount; i++)
        {
            skillBtnList.Add(commandPanel.transform.GetChild(i).GetComponent<Button>());
        }
    }
    private void setSkillBtn(BasicSkill skill,int idx)
    {
        //foreach(Button btn in  skillBtnList)
        //{
            Button btn = skillBtnList[idx];
        GameObject btnTxtObj = btn.gameObject.transform.GetChild(0).gameObject;
        btnTxtObj.GetComponent<TMPro.TextMeshProUGUI>().text = skill._skillName;
            switch(skill._skillType)
            {
                case SkillType.SpecifiedDamage:
                    btn.onClick.AddListener(()=> waitForSelectingTarget(skill));
                    break;
                case SkillType.AreaDamage:
                    btn.onClick.AddListener(()=> waitForSelectingTarget(skill));
                    break;


                default:
                    Debug.Log("Normal Skill");
                    break;
            }

        //}
        

    }

    public void waitForSelectingTarget(BasicSkill skill)
    {
        _currPlayerState = PlayerState.targetSelecting;
        showSkillValidPos(skill);
        _selectedSkill = skill;
    }

    public void selectTargetType()
    {
        switch(_selectedSkill._skillType)
        {
            case SkillType.SpecifiedDamage:
                if (_targetPos != FieldPosition.NULL)
                {
                    //_selectedSkill.dealDamageToTarget();
                    Debug.Log("targetPos " + _targetPos);
                    hideAnchor();
                    GameObject p = GameObject.Find(_targetPos.ToString());
                    for (int i = 0; i < p.transform.childCount; i++)
                    {
                        GameObject c = p.transform.GetChild(i).gameObject;
                        if (c.GetComponent<Creature>() != null)
                        {
                            _selectedSkill.dealDamageToTarget(c.GetComponent<Creature>());
                        }
                    }
                    _targetPos = FieldPosition.NULL;
                    _selectedSkill = null;
                    _currPlayerState = PlayerState.skillCasting;
                }
                break;
            case SkillType.AreaDamage:
                //TODO show hint this is area damage.
                if(Input.GetMouseButtonDown(0))
                {
                    hideAnchor();
                    Debug.Log("Deal area damage " + _secondSkill._damage);
                    foreach(var pos in _selectedSkill._availablePosList)
                    {
                        GameObject p = GameObject.Find(pos.ToString());
                        for (int i = 0; i < p.transform.childCount; i++)
                        {
                            GameObject c = p.transform.GetChild(i).gameObject;
                            if (c.GetComponent<Creature>() != null)
                            {
                                _selectedSkill.dealDamageToTarget(c.GetComponent<Creature>());
                                Debug.Log(c.GetComponent<Creature>()._CharName);
                            }
                        }
                    }
                    _targetPos = FieldPosition.NULL;
                    _selectedSkill = null;
                    _currPlayerState = PlayerState.skillCasting;
                }
                break;

        }
    }


    public void showSkillValidPos(BasicSkill skill)
    {
        if(_currPlayerState == PlayerState.targetSelecting)
        {
            foreach (var i in skill._availablePosList)
            {
                GameEvents.current.showTargetPos(i);
            }
        }
    }

    private void cancelSelecting() //cancel selecting, back to choosing skills
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("cancel selecting");
            foreach (var i in _selectedSkill._availablePosList)
            {
                GameEvents.current.hideTargetPos(i);
            }
            _currPlayerState = PlayerState.btnSelecting;
            _selectedSkill = null;
        } 
    } 
    public void setTargetPos(FieldPosition pos)
    {
        if (_currPlayerState == PlayerState.targetSelecting)
        {
            _targetPos = pos;
        }
    }

    private void hideAnchor()
    {
        foreach (var i in _selectedSkill._availablePosList)
        {
            GameEvents.current.hideTargetPos(i);
        }
    }
    public void setPlayerStart(Creature c)
    {
        if (c == this.GetComponent<Creature>())
        {
            _currPlayerState = PlayerState.btnSelecting;
        }
    }

}
