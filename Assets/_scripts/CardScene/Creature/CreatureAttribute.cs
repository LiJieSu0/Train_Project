using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardScene
{
    [CreateAssetMenu(menuName ="Creature/Attribute")]
    public class CreatureAttribute : ScriptableObject
    {
        public string CreatureName;
        public int MaxHP;
        public int Defense;
        public int Armor;
        public float Speed;
        public string ID;
        public int Damage;
        public Texture CreatureSprite;
    }
}