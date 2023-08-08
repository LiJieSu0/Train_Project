using System.Collections;
using System.Collections.Generic;
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
        public int currTurn;
        private SceneState _currSceneState;
        public Dictionary<GameObject,int> CardPileDict=new Dictionary<GameObject,int>();
        public string prefabPath = "Assets/Prefab/Card/Skills/Slash.prefab";
        private void Awake()
        {
            _currSceneState = SceneState.playerTurn;
        }
        void Start()
        {
            GameObject loadedPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            CardPileDict.Add(loadedPrefab, 15);
            foreach (KeyValuePair<GameObject,int> kvp in CardPileDict)
            {
                GameObject keyObj= kvp.Key;
                int value= kvp.Value;
                for(var i =0; i < kvp.Value; i++)
                {
                    GameObject tmp= Instantiate(keyObj, GameObject.Find("CardPileManager").transform);
                    tmp.transform.localPosition = new Vector3(0, 0, 0);
                    tmp.name += i;
                }
            }
        }

        void Update()
        {
            switch(_currSceneState)
            {
                case SceneState.playerTurn:
                    currTurn += 1;
                    PlayerManager._pManager.DrawCard(5);
                    _currSceneState = SceneState.pending;
                    break;
                case SceneState.pending:
                    //TODO wait for current moving change state
                    break;
                case SceneState.teamTurn: 
                    //TODO wait for teammember moving
                    break;

            }
        }

    }
}
