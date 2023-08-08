using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

namespace CardScene
{
    public class GraveyardManager : MonoBehaviour
    {
        public static GraveyardManager _currGraveyardManager;
        private Transform _graveyard;
        private Transform cardPile;
        private void Start()
        {
            _currGraveyardManager = this;
            _graveyard = this.transform;
            cardPile = GameObject.Find("CardPileManager").transform;
        }

        public void recycling()
        {
            List<GameObject> _currCardList = new List<GameObject>();
            for(int i=0;i< _graveyard.childCount; i++)
            {
                GameObject tmp=_graveyard.GetChild(i).gameObject;
                _currCardList.Add(tmp);
            }
            foreach(var i in _currCardList)
            {
                i.transform.parent = cardPile;
                i.transform.localPosition = Vector3.zero;
            }
            CardPileManager._currCardPileManager.shuffle();
        }

    }

}

