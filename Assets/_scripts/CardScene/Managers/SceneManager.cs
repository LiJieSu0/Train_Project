using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace CardScene
{
    public enum SceneState
    {
        cutScene,
        battleStart,
        calOrder,
        playerTurn,
        teamTurn,
        enemyTurn,
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
        //STATIC VARIABLE

        //READ FROM STAGE SETTING
        public List<GameObject> EnemyList = new List<GameObject>();
        public Dictionary<string,int> CardPile=new Dictionary<string,int>();

        //READ FROM STAGE SETTING

        public SceneState _currSceneState;
        public int currTurn;
        public Dictionary<GameObject,int> CardPileDict=new Dictionary<GameObject,int>();
        public List<IProgress> _orderList= new List<IProgress>();



        private string BasicCardPath = "Assets/_Prefab/Card/SkillCards/";
        private string _PREFABEXTENSION = ".prefab";
        private string _cardName = "Slash";

        private void Awake()
        {
            _currSceneManager = this;
        }
        void Start()
        {   
            _currSceneState = SceneState.playerTurn;
            //tmp for creating card pile
            string tmp = Path.Combine(BasicCardPath, _cardName + _PREFABEXTENSION);
            GameObject loadedPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(tmp);
            CardPileDict.Add(loadedPrefab, 15);
            //tmp for creating card pile
            createOrderList();
            calTimeToAction();
            
            createPile();

        }

        void Update()
        {

            
            switch (_currSceneState)
            {
                case SceneState.playerTurn:
                    print(_orderList[1]._currProgress);
                    print(_orderList[1]._gameObject.name);
                    currTurn += 1;
                    PlayerManager._pManager.DrawCard();
                    _currSceneState = SceneState.pending;
                    break;
                case SceneState.pending:
                    //TODO wait for current moving change state
                    break;
                case SceneState.teamTurn: 
                    //TODO wait for teammember moving
                    break;
                default:
                    print("Default Scene State");
                    break;
            }
        }

        private void createPile()
        {
            foreach (KeyValuePair<GameObject, int> kvp in CardPileDict)
            {
                GameObject keyObj = kvp.Key;
                int value = kvp.Value;
                for (var i = 0; i < kvp.Value; i++)
                {
                    GameObject tmp = Instantiate(keyObj, GameObject.Find(CARDPILE).transform);
                    tmp.transform.localPosition = new Vector3(0, 0, 0);
                    tmp.name += i;
                }
            }
        }

        private void createOrderList()
        {
            _orderList.Add(PlayerManager._pManager);
            _orderList.Add(GameObject.Find("Enemy1").GetComponent<BaseEnemyObj>());
        }

        private void calTimeToAction()
        {
            foreach (var i in _orderList)
            {
                i._timeToAction= (float)Math.Round((100f - i._currProgress) / i._speed, 2);
            }
        }


    }
}
