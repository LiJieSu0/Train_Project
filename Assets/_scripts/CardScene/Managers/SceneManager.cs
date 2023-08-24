using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

namespace CardScene
{
    public enum SceneState
    {
        cutScene,
        battleStart,
        calOrder,
        playerRound,
        teammateRound,
        enemyRound,
        pending,
        win,
        lose,
        battleEnd,
    }
    public class SceneManager : MonoBehaviour
    {
        //STATIC VARIABLE
        public static SceneManager _currSceneManager;
        public static string GRAVEYARD = "GraveyardManager";
        public static string PLAYER = "PlayerManager";
        public static string CARDPILE = "CardPileManager";
        public static string EXILEZONE = "ExileZoneManager";
        public static string CANVAS = "Canvas";
        //STATIC VARIABLE

        //READ FROM STAGE SETTING
        public List<GameObject> EnemyList = new List<GameObject>();
        public Dictionary<string,int> CardPile=new Dictionary<string,int>();

        //READ FROM STAGE SETTING

        public SceneState _currSceneState;
        public int _currRound;
        public Dictionary<GameObject,int> CardPileDict=new Dictionary<GameObject,int>();
        public List<IProgress> _orderList= new List<IProgress>();
        private float _currTimeToAction;



        private string BasicCardPath = "Assets/_Prefab/Card/SkillCards/";
        private string PREFABEXTENSION = ".prefab";

        private void Awake()
        {
            _currSceneManager = this;
        }
        void Start()
        {   
            _currSceneState = SceneState.cutScene;
            //tmp for creating card pile
            CardPile.Add("Slash", 15);
            //tmp for creating card pile
            createPile();
            CardPileManager._currCardPileManager.shuffle();


        }

        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                calTimeToAction();
                sortOrderList();
                calProgressAfterTTA();
                foreach(var i in _orderList) 
                {
                    print(i._gameObject.name);
                }

            }
            switch (_currSceneState)
            {
                case SceneState.cutScene:
                    //TODO play some animaition
                    _currSceneState = SceneState.battleStart;
                    break;

                case SceneState.battleStart:
                    createOrderList();
                    _currSceneState = SceneState.calOrder;
                    break;

                case SceneState.calOrder:
                    Debug.Log("calOrder");
                    calTimeToAction();
                    sortOrderList();
                    calProgressAfterTTA();
                    decideActionRound();
                    break;

                case SceneState.playerRound:
                    _currRound += 1;
                    PlayerManager._pManager._currPlayerState = PlayerState.PreparePhase;
                    _currSceneState = SceneState.pending;
                    break;
                case SceneState.pending:
                    //TODO wait for current creature change state
                    break;
                case SceneState.teammateRound: 
                    //TODO wait for teammember moving
                    break;
                case SceneState.enemyRound:
                    //TODO wait for AI working
                    _orderList[0]._gameObject.GetComponent<BaseEnemyObj>()._currEnemyState=EnemyState.Acting;
                    _currSceneState = SceneState.pending;
                    break;
                default:
                    print("Default Scene State");
                    break;
            }
        }


        private void createOrderList()
        {
            _orderList.Add(PlayerManager._pManager);
            _orderList.Add(GameObject.Find("Enemy1").GetComponent<BaseEnemyObj>());
            _orderList.Add(GameObject.Find("Enemy2").GetComponent<BaseEnemyObj>());
            _orderList.Add(GameObject.Find("Enemy3").GetComponent<BaseEnemyObj>());
            _orderList.Add(GameObject.Find("Enemy4").GetComponent<BaseEnemyObj>());
        }

        private void createPile()
        {
            foreach (KeyValuePair<string, int> kvp in CardPile)
            {
                string keyStr = kvp.Key;
                int cardNum = kvp.Value;
                string prefabPath = Path.Combine(BasicCardPath, keyStr + PREFABEXTENSION);
                GameObject loadedPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                for (int i = 0; i < cardNum; i++)
                {
                    GameObject tmp = Instantiate(loadedPrefab, GameObject.Find(CARDPILE).transform);
                    tmp.transform.localPosition = new Vector3(0, 0, 0);
                    tmp.name += i;
                }
            }
        }
        private void calTimeToAction()
        {
            foreach (var i in _orderList)
            {
                i._timeToAction= (float)Math.Round((100f - i._currProgress) / i._speed, 2);
            }
        }
        private void sortOrderList()
        {
            _orderList.Sort((p1,p2)=>p1._timeToAction.CompareTo(p2._timeToAction));
            _currTimeToAction = _orderList[0]._timeToAction;
        }
        private void calProgressAfterTTA() //TTA means time to action
        {
            _orderList[0]._currProgress = 0;//first item progress is 100 need to be reset after action.
            for (var i = 1; i < _orderList.Count; i++)
            {
                _orderList[i]._currProgress+= (float)Math.Round(_currTimeToAction * _orderList[i]._speed, 2);
            }

        }
        private void decideActionRound()
        {
            //Debug.Log(_orderList[0]._gameObject.name);
            switch (_orderList[0])
            {
                case PlayerManager:
                    Debug.Log("Player turn");
                    _currSceneState = SceneState.playerRound;
                    break;
                case BaseEnemyObj:
                    Debug.Log("Enemy turn");
                    _currSceneState = SceneState.enemyRound;
                    break;
            }
        }

    }
}
