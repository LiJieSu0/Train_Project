using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState
{
    noAction,
    btnSelecting,
    targetSelecting,
    skillCasting,
    finished,
}
public enum FieldPosition
{
    NULL=-1,
    P_BB = 0,
    P_BM = 1,
    P_BT = 2,
    P_FB = 3,
    P_FM = 4,
    P_FT = 5,
    E_BB = 6,
    E_BM = 7,
    E_BT = 8,
    E_FB = 9,
    E_FM = 10,
    E_FT = 11
}
public class SceneManager : MonoBehaviour
{
    private enum SceneState
    {
        cutScene,
        battleStart,
        calOrder,
        playerTurn,
        enemyTurn,
        pending,
        win,
        lose,
        battleEnd,
    }
    public static SceneManager _sceneManager;
    [SerializeField] public GameObject _iconBg;
    //Load player characters and team formation from other scene or data manager.
    public List<GameObject> playerMemberLst= new List<GameObject>();
    //Load Enemy character list and formation from other scene or data manager.
    public List<GameObject> enemyMemberLst= new List<GameObject>();
    
    private List<GameObject> _creatureObjList= new List<GameObject>();
    private List<GameObject> _fixedSeqObjList=new List<GameObject> ();
    private Dictionary<String,GameObject> _iconBgDict=new Dictionary<string, GameObject>();

    private GameObject orderSeq;
    private float _currTimeToAction;
    private SceneState _currSceneState;
    public Creature _currPlayer=null;
    
    private void Awake()
    {
        _sceneManager = this;
        setFieldPosObj();
        orderSeq = GameObject.Find("OrderSeq");
        setFixedSeqList();
    }
    void Start()
    {
        calTimeToAction();
        sortCreatureList();
        createCreatureIconOnSeq();
        calProgressAfterTTA();
        //Debug.Log("start coroutine");
        //StartCoroutine(SeqOrder());
        _currSceneState = SceneState.cutScene;
    }

    void Update()
    {
        Debug.Log(_currSceneState);
        switch (_currSceneState)
        {
            case SceneState.cutScene:
                _currSceneState = SceneState.battleStart;
                break;
            case SceneState.battleStart:
                _currSceneState= SceneState.calOrder;
                if (_creatureObjList[0].GetComponent<Creature>() is Player)
                {
                    _currSceneState = SceneState.playerTurn;
                }
                else
                {
                    _currSceneState = SceneState.enemyTurn;
                }
                break;

            case SceneState.calOrder:

                calTimeToAction();
                sortCreatureList();
                changeSeqIconPos();
                calProgressAfterTTA();

                if (_creatureObjList[0].GetComponent<Creature>() is Player)
                {
                    _currSceneState = SceneState.playerTurn;
                }
                else
                {
                    _currSceneState = SceneState.enemyTurn;
                }
                break;

            case SceneState.playerTurn:
                //TODO get current player script and status
                _currPlayer = _creatureObjList[0].GetComponent<Creature>();
                GameEvents.current.turnChange(_currPlayer);
                _currSceneState = SceneState.pending;
                break;

            case SceneState.enemyTurn:
                //TDOO perform AI action
                if (Input.GetKeyUp(KeyCode.R))
                {
                    _currSceneState= SceneState.calOrder;
                }
                break;
            case SceneState.pending:
                Debug.Log("Wait for state change by the current creature!");
                break;
            case SceneState.battleEnd:
                Debug.Log("pass data to another scene");
                break;
            default:
                break;
        }

    }



    private void setFieldPosObj()
    {

        for(int i = 0; i < 6; i++)
        {
            if (playerMemberLst[i] != null)
            {
                FieldPosition tmpField = (FieldPosition)i;
                GameObject pos = GameObject.Find(tmpField.ToString());
                GameObject c=Instantiate(playerMemberLst[i], pos.transform);
                c.GetComponent<Creature>()._fieldPos = tmpField;
                _creatureObjList.Add(c);
            }
            if (enemyMemberLst[i] != null)
            {
                FieldPosition tmpField = (FieldPosition)i+6;
                GameObject pos = GameObject.Find(tmpField.ToString());
                GameObject c = Instantiate(enemyMemberLst[i], pos.transform);
                c.GetComponent<Creature>()._fieldPos = tmpField;
                _creatureObjList.Add(c);

            }
        }

    }

    private void setFixedSeqList()
    {
        for(var i =0;i<orderSeq.transform.childCount;i++)
        {
            _fixedSeqObjList.Add(orderSeq.transform.GetChild(i).gameObject);
        }
    }


    private void calTimeToAction()
    {
        foreach(var obj in _creatureObjList)
        {
            Creature c=obj.GetComponent<Creature>();
            c._TimeToAction = (float)Math.Round((100f - c._CurrProgress) / c.getSpeed(),2);
        }
    }
    private void sortCreatureList()
    {
        _creatureObjList.Sort((c1, c2) => c1.GetComponent<Creature>()._TimeToAction.
                                        CompareTo(c2.GetComponent<Creature>()._TimeToAction));
        _currTimeToAction = _creatureObjList[0].GetComponent<Creature>()._TimeToAction;
    }


    private void createCreatureIconOnSeq()
    {
        for (int i = 0; i < _creatureObjList.Count; i++)
        {
            GameObject tmpBg = Instantiate(_iconBg, orderSeq.transform.GetChild(i));
            
            tmpBg.name = _creatureObjList[i].GetComponent<Creature>()._CharName;
            tmpBg.GetComponent<IconBg>().setColor(_creatureObjList[i].GetComponent<Creature>() is Player);
            tmpBg.transform.GetChild(0).GetComponent<RawImage>().texture = _creatureObjList[i].GetComponent<Creature>()._CreatureIcon;
            _iconBgDict.Add(tmpBg.name,tmpBg);
        }
    }

    private void calProgressAfterTTA() //TTA means time to action
    {
        
        _creatureObjList[0].GetComponent<Creature>()._CurrProgress = 0;//first item progress is 100 need to be reset after action.
        for (var i =1; i < _creatureObjList.Count; i++)
        {
            Creature c = _creatureObjList[i].GetComponent<Creature>();
            c._CurrProgress += (float)Math.Round(_currTimeToAction * c.getSpeed(),2);
        }

    }
    private void changeSeqIconPos() 
    {
        for(int i=0;i< _creatureObjList.Count; i++)
        {
            GameObject tmpBg = _iconBgDict[_creatureObjList[i].GetComponent<Creature>()._CharName];
            tmpBg.transform.SetParent(orderSeq.transform.GetChild(i));
            tmpBg.transform.localPosition=new Vector3(0,0,0);  
            tmpBg.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private IEnumerator SeqOrder()
    {
        yield return new WaitForSeconds(5);
        while(true)
        {
            calTimeToAction();
            sortCreatureList();
            changeSeqIconPos();
            calProgressAfterTTA();
            yield return new WaitForSeconds(5f);
        }
    }

    public void setSceneStateCal()
    {
        _currSceneState = SceneState.calOrder;
        _currPlayer = null;
    }


}
