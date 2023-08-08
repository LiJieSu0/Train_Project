using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardScene
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager _pManager;
        private const int HandCardLimit = 10;
        private int _currHandCard = 0;
        private GameObject _cardPile;
        private GameObject _graveyard;
        private List<GameObject> _handCard=new List<GameObject>();
        void Start()
        {
            _pManager = this;
            _cardPile = GameObject.Find("CardPileManager");
            _graveyard = GameObject.Find("GraveyardManager");
        }

        void Update()
        {
        }

        public void DrawCard(int drawNumber=5)
        {
            Debug.Log(drawNumber);
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