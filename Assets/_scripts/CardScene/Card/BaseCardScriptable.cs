using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardScene
{
    public enum CardType
    {
        Damage,
        Buff,
        Debuff,
        Ability,
    }
    [CreateAssetMenu(menuName ="Card/Base")]
    public class BaseCardScriptable : ScriptableObject
    {
        public CardType _type;
        public int _targetNumber;
        public int _cost;
        public string _cardName;
        public string _cardDescription;
        public Sprite _sprite;
    }
}
