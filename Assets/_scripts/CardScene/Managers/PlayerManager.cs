using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardScene
{
    public class PlayerManager : MonoBehaviour,IProgress
    {
        public static PlayerManager _pManager;
        public PlayerAttribute _attr;
        private const int HandCardLimit = 10;
        private int _currHandCard = 0;
        private GameObject _cardPile;
        private GameObject _graveyard;
        private List<GameObject> _handCard=new List<GameObject>();


        private float speed;
        private float currProgress;
        private float timeToAction;
        public int MaxHp;
        private int _currHp;

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

        }

        void Update()
        {
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
        public void DrawCard(int drawNumber=5)
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
        
        public void showHandCard()
        {
            for(int i=0; i < _handCard.Count; i++)
            {
                GameObject tmpCardObj = _handCard[i];
                tmpCardObj.transform.localPosition= new Vector3(0+i*1f,0,0);
            }
        } //TODO change the hand card displaying method

        public void discardAllToGrave()
        {
            foreach(var i in _handCard)
            {
                i.GetComponent<FlipCard>().flip();
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
        }

    }
}