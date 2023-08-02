using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum PlayerState
{
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
        sceneCut,
        battleStart,
        battleEnd,
        win,
        lose,
    }
    //Load player characters and team formation from other scene or data manager.
    public List<GameObject> playerMemberLst= new List<GameObject>();
    //Load Enemy character list and formation from other scene or data manager.
    public List<GameObject> enemyMemberLst= new List<GameObject>();
    private List<Creature> creatureList= new List<Creature>();

    public bool _isSelecting=false;
    [SerializeField] public GameObject _iconBg;
    private GameObject orderSeq;
    private float _currTimeToAction;

    public static SceneManager _sceneManager;
    private void Awake()
    {
        _sceneManager = this;
        setFieldPosObj();
        setCreatureList();
        orderSeq = GameObject.Find("OrderSeq");
        createCreatureIconOnSeq();
    }
    void Start()
    {
        calTimeToAction();
        sortCreatureList();
        calProgressAfterTTA();
        //TODO some creature acting, and calTTA
    }

    void Update()
    {
        
    }

    void createCreatureIconOnSeq()
    {
        for (int i = 0; i < creatureList.Count; i++)
        {
            GameObject tmpBg = Instantiate(_iconBg, orderSeq.transform.GetChild(i));
            tmpBg.GetComponent<CreatureIconBg>().setColor(creatureList[i].GetComponent<Creature>() is Player);
            //TODO attach icon to bg
        }
    }

    private void placeCharacter(GameObject parent,GameObject child)
    {
        Instantiate(child,parent.transform);
    }
    private void setFieldPosObj()
    {
        //Player_Field
        GameObject p_ft = GameObject.Find(FieldPosition.P_FT.ToString());
        GameObject p_fm = GameObject.Find(FieldPosition.P_FM.ToString());
        GameObject p_fb = GameObject.Find(FieldPosition.P_FB.ToString());
        GameObject p_bt = GameObject.Find(FieldPosition.P_BT.ToString());
        GameObject p_bm = GameObject.Find(FieldPosition.P_BM.ToString());
        GameObject p_bb = GameObject.Find(FieldPosition.P_BB.ToString());

        //Enemy_Field
        GameObject e_ft = GameObject.Find(FieldPosition.E_FT.ToString());
        GameObject e_fm = GameObject.Find(FieldPosition.E_FM.ToString());
        GameObject e_fb = GameObject.Find(FieldPosition.E_FB.ToString());
        GameObject e_bt = GameObject.Find(FieldPosition.E_BT.ToString());
        GameObject e_bm = GameObject.Find(FieldPosition.E_BM.ToString());
        GameObject e_bb = GameObject.Find(FieldPosition.E_BB.ToString());

        //PlayerCreature
        if(playerMemberLst[0]!=null)placeCharacter(p_ft, playerMemberLst[0]);
        if (playerMemberLst[1] != null) placeCharacter(p_fm, playerMemberLst[1]);
        if (playerMemberLst[2] != null) placeCharacter(p_fb, playerMemberLst[2]);
        if (playerMemberLst[3] != null) placeCharacter(p_bt, playerMemberLst[3]);
        if (playerMemberLst[4] != null) placeCharacter(p_bm, playerMemberLst[4]);
        if (playerMemberLst[5] != null) placeCharacter(p_bb, playerMemberLst[5]);

        if (enemyMemberLst[0]!=null) placeCharacter(e_ft, enemyMemberLst[0]);
        if (enemyMemberLst[1] != null) placeCharacter(e_fm, enemyMemberLst[1]);
        if (enemyMemberLst[2] != null) placeCharacter(e_fb, enemyMemberLst[2]);
        if (enemyMemberLst[3] != null) placeCharacter(e_bt, enemyMemberLst[3]);
        if (enemyMemberLst[4] != null) placeCharacter(e_bm, enemyMemberLst[4]);
        if (enemyMemberLst[5] != null) placeCharacter(e_bb, enemyMemberLst[5]);
    }

    private void setCreatureList()
    {
        for (var i = 0; i < playerMemberLst.Count; i++)
        {
            if (playerMemberLst[i] != null)
            {
                creatureList.Add(playerMemberLst[i].GetComponent<Creature>());
            }
            if (enemyMemberLst[i] != null)
            {
                creatureList.Add(enemyMemberLst[i].GetComponent<Creature>());
            }
        }
    }

    private void sortCreatureList()
    {
        creatureList.Sort((c1, c2) => c1._TimeToAction.CompareTo(c2._TimeToAction));
        _currTimeToAction = creatureList[0]._TimeToAction;
    }

    private void calTimeToAction()
    {
        foreach(var c in creatureList)
        {
            c._TimeToAction = (100f - c._CurrProgress) / c.getSpeed();
        }
    }

    private void calProgressAfterTTA() //TTA means time to action
    {
        
        creatureList[0]._CurrProgress = 0;//first item progress is 100 need to be reset after action.
        for (var i =1; i < creatureList.Count; i++)
        {
            Creature c = creatureList[i];
            c._CurrProgress += _currTimeToAction * c.getSpeed();
        }
    }

}
