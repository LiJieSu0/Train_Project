using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
namespace CardScene
{
    public class CardPileManager : MonoBehaviour
    {
        Button btn;
        public static CardPileManager _currCardPileManager;
        private void Start()
        {
            btn = GameObject.Find("shuffleBtn").GetComponent<Button>();
            btn.onClick.AddListener(() => shuffle());
            _currCardPileManager = this;
        }

        public void shuffle()
        {
            Transform _cardPile = this.transform;

            for (int i = 0; i < _cardPile.childCount; i++)
            {
                int randomIdx = Random.Range(0, _cardPile.childCount);
                Transform tmp = _cardPile.GetChild(i);
                tmp.SetSiblingIndex(randomIdx);
            }
        }

    }

}