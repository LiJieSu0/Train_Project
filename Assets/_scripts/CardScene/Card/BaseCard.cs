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
    public class BaseCard : MonoBehaviour
    {
        public CardType _type;
        public int _targetNumber;
        public int cost;

        public void PlayCard(Creature target=null)
        {

        }
    }
}
