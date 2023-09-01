using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace CardScene
{
    public enum EnemyState
    {
        Waiting,
        Acting,
        Pending,
        Ending,
    }
    public class BaseEnemyObj : MonoBehaviour,IProgress,IBattle
    {

        //Enemy Attribute
        public CreatureAttribute _attribute;
        private int MaxHp;
        private int _currHp;
        public GameObject _healthBar;
        private GameObject _copiedHealthBar;
        public float speed;
        private int _damage;
        //Enemy Attribute

        public EnemyState _currEnemyState;
        private float timeToAction;
        private float currProgress;
        private Dictionary<BaseEffect,int> effectDict= new Dictionary<BaseEffect,int>();
        public List<GameObject> targetList= new List<GameObject>(); 

        //GUI
        public Vector3 healthBarOffset;
        //GUI

        void Awake()
        {
            MaxHp = _attribute.MaxHP;
            _currHp = MaxHp;
            speed = _attribute.Speed;
            _damage = _attribute.Damage;
        }

        void Start()
        {
            _copiedHealthBar = Instantiate(_healthBar,GameObject.Find(SceneManager.CANVAS).transform);
            _copiedHealthBar.transform.position=Camera.main.WorldToScreenPoint(this.transform.position+ healthBarOffset);
            targetList.Add(GameObject.Find("PlayerManager"));//tmp for testing
        }

        void Update()
        {
            _copiedHealthBar.GetComponent<Slider>().value = (float)_currHp / MaxHp;
            switch (_currEnemyState)
            {
                case EnemyState.Waiting:
                    //TODO some anime here
                    break;

                case EnemyState.Acting:
                    //TODO AI HERE
                    Debug.Log(this.gameObject.name);
                    StartCoroutine(AIcoroutine());
                    
                    //TODO get all actions selection

                    break;

                case EnemyState.Pending:
                    Debug.Log("Wait for AI finished");
                    break;

                case EnemyState.Ending:
                    Debug.Log("AI finished");
                    Debug.Log(SceneManager._currSceneManager._currSceneState);
                    SceneManager._currSceneManager._currSceneState = SceneState.calOrder;
                    _currEnemyState= EnemyState.Waiting;
                    break;
            }

        }

        public void takeDamage(int damage)
        {
            _currHp -= damage;
        }
        public void attackTarget(List<GameObject> targetList)
        {

        }

        public void buffApply(int heal, List<BaseEffect> effectList = null)
        {
            _currHp += heal;
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
        public Dictionary<BaseEffect, int> _effectDict
        {
            get { return effectDict; }
            set { this.effectDict = value; }
        }
        public void AttackTarget(List<GameObject> targetList)
        {
            int targetIdx=Random.Range(0,targetList.Count);
            GameObject target= targetList[targetIdx];
            target.GetComponent<IBattle>().takeDamage(_damage);

        }
        public void effectExecution()
        {

        }
        public void effectCheckAtStart()
        {

        }
        public void effectCheckAtEnd()
        {

        }


        private IEnumerator AIcoroutine()
        {
            _currEnemyState = EnemyState.Pending;
            Debug.Log("selecting action");
            Debug.Log("perform action");
            Debug.Log("action finish");
            _currEnemyState = EnemyState.Ending;
            yield return new WaitForSeconds(0.1f);
        }


    }
}
