using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardScene
{
    public class BaseEnemyObj : MonoBehaviour
    {
        public CreatureAttribute _attribute;
        private float MaxHp;
        private float _currHp;
        public GameObject _healthBar;

        void Start()
        {
            print(_attribute._MaxHP);
            MaxHp = _attribute._MaxHP;
            _currHp = MaxHp;
            print(_currHp);
        }



        public void reduceHp(float damage)
        {
            _currHp -= damage;
            print(_currHp);
        }
    }
}
