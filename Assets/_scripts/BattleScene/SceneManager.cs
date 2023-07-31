using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FieldPosition
{
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
    //Load player characters and team formation from other scene or data manager.
    public List<GameObject> playerMemberLst= new List<GameObject>();
    //Load Enemy character list and formation from other scene or data manager.
    public List<GameObject> enemyMemberLst= new List<GameObject>();
    //read dict from other scene or data manager.
    public Dictionary<string,string> player_formation_dict= new Dictionary<string,string>();

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;
    public static SceneManager _sceneManager;
    public FieldPosition currMoving;


    private void Awake()
    {
        _sceneManager = this;
        GameObject p_ft = GameObject.Find(FieldPosition.P_FT.ToString());
        GameObject p_fm = GameObject.Find(FieldPosition.P_FM.ToString());
        GameObject p_fb = GameObject.Find(FieldPosition.P_FB.ToString());
        GameObject p_bt = GameObject.Find(FieldPosition.P_BT.ToString());
        GameObject p_bm = GameObject.Find(FieldPosition.P_BM.ToString());
        GameObject p_bb = GameObject.Find(FieldPosition.P_BB.ToString());
        placeCharacter(p_ft, p1);
        placeCharacter(p_fm, p2);
        placeCharacter(p_fb, p3);
        placeCharacter(p_bt, p4);
        placeCharacter(p_bm, p5);
        placeCharacter(p_bb, p6);
        GameObject e_ft = GameObject.Find(FieldPosition.E_FT.ToString());
        GameObject e_fm = GameObject.Find(FieldPosition.E_FM.ToString());
        GameObject e_fb = GameObject.Find(FieldPosition.E_FB.ToString());
        GameObject e_bt = GameObject.Find(FieldPosition.E_BT.ToString());
        GameObject e_bm = GameObject.Find(FieldPosition.E_BM.ToString());
        GameObject e_bb = GameObject.Find(FieldPosition.E_BB.ToString());
        placeCharacter(e_ft, p1);
        //placeCharacter(e_fm, p2);
        placeCharacter(e_fb, p3);
        placeCharacter(e_bt, p4);
        placeCharacter(e_bm, p5);
        placeCharacter(e_bb, p6);


    }
    void Start()
    {
        currMoving = FieldPosition.P_FM;
    }

    void Update()
    {
        
    }
    void placeCharacter(GameObject parent,GameObject child)
    {
        Instantiate(child,parent.transform);
    }
}
