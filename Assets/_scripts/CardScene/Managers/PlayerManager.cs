using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CardScene
{
    public enum PlayerState{
        Waiting,
        PreparePhase,
        CardPlayingPhase,
        DiscardPhase,
        SelectingPhase,
        ConfirmationPhase
    }

    public class PlayerManager : MonoBehaviour,IProgress,IEffect,IBattle
    {
        public static PlayerManager _pManager;
        public PlayerAttribute _attr;
        private const int HandCardLimit = 10;
        private int _currHandCard = 0;
        private GameObject _cardPile;
        private GameObject _graveyard;
        private List<GameObject> _handCard=new List<GameObject>();


        //Player Status
        public PlayerState _currPlayerState;
        private float speed;
        private float currProgress;
        private float timeToAction;
        private int MaxHp;
        private int _currHp;
        public int MaxEp;
        public int _currEp;
        private GameObject _healthBar;
        private TextMeshProUGUI _epState;
        private Dictionary<BaseEffect, int> effectDict = new Dictionary<BaseEffect, int>();
        //Player Status


        void Awake()
        {
            _pManager = this;
            _speed = _attr.Speed;
            MaxHp = _attr.MaxHP;
        }
        void Start()
        {
            _cardPile = GameObject.Find(SceneManager.CARDPILE);
            _graveyard = GameObject.Find(SceneManager.GRAVEYARD);
            _epState = GameObject.Find("EP_State").GetComponent<TextMeshProUGUI>();
            _currPlayerState = PlayerState.Waiting;
            //TODO reduce EP when playing card
        }

        void Update()
        {
            switch (_currPlayerState)
            {
                case PlayerState.Waiting:
                    break;
                case PlayerState.PreparePhase:
                    if (_currEp < 6) _currEp += SceneManager._currSceneManager._currRound - 1;
                    drawCard();
                    //TODO check effect list
                    _currPlayerState = PlayerState.CardPlayingPhase;
                    break;
                case PlayerState.CardPlayingPhase:

                    break;
                case PlayerState.DiscardPhase: 
                    discardAllToGrave();
                    break;
            }
        }

        public float _speed
        {
            get { return speed; }
            set { this.speed = value; }
        }
        public float _timeToAction
        {
            get { return timeToAction; }
            set { timeToAction = value; }
        }
        public float _currProgress
        {
            get { return currProgress; }
            set { this.currProgress= value; }
        }
        public GameObject _gameObject
        {
            get { return this.gameObject; }

        }

        public Dictionary<BaseEffect, int> _effectDict
        {
            get { return effectDict; }
            set { this.effectDict= value; }
        }

        public void effectExecution(BaseEffect effect)
        {
            foreach(var eType in effect._typeList)
            {
                switch (eType)
                {
                    case EffectType.Damage:
                        takeDamage(effect._hpAdjustment);
                        effectDict[effect] -= 1;
                        break;
                    case EffectType.Armor:
                        break;
                    case EffectType.EP:
                        break;
                    case EffectType.DefenseAdjust:
                        break;
                    case EffectType.AttackAdjust:
                        break;
                    case EffectType.SpeedAdjust:
                        break;
                }
            }
        }
        public void effectExeAtStart()
        {
            foreach(var effect in effectDict.Keys)
            {
                if (effect._executionTime == EffectExecutionTime.TurnStart)
                {
                    effectExecution(effect);
                }
            }
        }

        public void effectExeAtEnd()
        {
            foreach (var effect in effectDict.Keys)
            {
                if (effect._executionTime == EffectExecutionTime.TurnEnd)
                {
                    effectExecution(effect);
                }
            }
        }

        public void addEffectToDict(BaseEffect effect)
        {
            if (effect._executionTime != EffectExecutionTime.Permanent) {
                effectDict.Add(effect, effect._effectDuration);
            }
            else
            {
                //TODO apply permanent effect here
            }
        }
        public void removeEffet(BaseEffect effect)
        {

        }
        public void takeDamage(int damage)
        {
            _currHp += damage;
        }

        public void attackTarget(List<GameObject> targetList)
        {
            return;
        }

        public void buffApply(int heal, List<BaseEffect> effectList = null)
        {
            _currHp += heal;
        }


        public void drawCard(int drawNumber=5)
        {
            for(int i= 0; i < drawNumber; i++) {
                if (_handCard.Count >= 10) { return; }
                if (_cardPile.transform.childCount > 0)
                {
                    drawOneCard();
                }
                else
                {
                    GraveyardManager._currGraveyardManager.recycling();
                    CardPileManager._currCardPileManager.shuffle();
                    drawOneCard();
                }
            }
            showHandCard();
        }
        
        public void showHandCard()//TODO change the hand card displaying method
        {
            for(int i=0; i < _handCard.Count; i++)
            {
                GameObject tmpCardObj = _handCard[i];
                tmpCardObj.transform.localPosition= new Vector3(0+i*1f,0,0);
            }
        } 

        public void discardAllToGrave()
        {
            foreach(var i in _handCard)
            {
                i.GetComponent<FlipCard>().flip();
                i.GetComponent<DragCard>().toggleDraggable();
                i.transform.parent = _graveyard.transform;
                i.transform.localPosition= new Vector3(0,0,0);
            }
            _handCard.Clear();
        }

        public void drawOneCard()
        {
            GameObject tmpCard = _cardPile.transform.GetChild(0).gameObject;
            tmpCard.transform.parent = this.gameObject.transform;
            tmpCard.transform.localPosition = new Vector3(0, 0, 0);
            _handCard.Add(tmpCard);
            tmpCard.GetComponent<FlipCard>().flip();
            tmpCard.GetComponent<DragCard>().toggleDraggable();
        }
        public void endPlayerRound()
        {
            _currPlayerState = PlayerState.DiscardPhase;
        }


    }
}