using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardScene
{
    [CreateAssetMenu(menuName ="Creature/Attribute")]
    public class CreatureAttribute : ScriptableObject
    {
        public string _CharName;
        public float _Speed;
        public float _MaxHP;
        public float _MaxEP;
        public float _Strength;
        public float _Agility;
        [Header("體質")] public float _Constitution;//
        public float _Intelligence;
        public float _Perception;
        public float _Luckey;
        public float _Apperance;
        public string ID;
        public Texture _CreatureIcon;
    }
}