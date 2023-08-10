using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CardScene
{
    public class BaseEnemyObj : MonoBehaviour,IProgress
    {
        public CreatureAttribute _attribute;
        private int MaxHp;
        private int _currHp;
        public GameObject _healthBar;
        private float speed;
        private float timeToAction;
        private float currProgress;


        void Start()
        {
            MaxHp = _attribute.MaxHP;
            _currHp = MaxHp;
            speed=_attribute.Speed;
        }

        public void reduceHp(int damage)
        {
            _currHp -= damage;
        }


        public float _speed
        {
            get { return speed; }
            set { this.speed = value; }
        }
        public float _timeToAction
        {
            get { return timeToAction; }
            set { this.timeToAction = value; }
        }
        public float _currProgress
        {
            get { return currProgress; }
            set { this.currProgress = value; }
        }

        public GameObject _gameObject
        {
            get { return this.gameObject; }
        }
    }
}
