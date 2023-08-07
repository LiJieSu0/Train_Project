using System.Collections;
using System.Collections.Generic;
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
        private void Awake()
        {
            _currSceneState = SceneState.playerTurn;
        }
        void Start()
        {
            
        }

        void Update()
        {
            switch(_currSceneState)
            {
                case SceneState.playerTurn:
                    currTurn += 1;
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
