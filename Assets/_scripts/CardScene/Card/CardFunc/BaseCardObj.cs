using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardScene
{
    public class BaseCardObj : MonoBehaviour,IPlayCard
    {

        void Start()
        {
        
        }

        void Update()
        {
        
        }
        public void PlayCard(GameObject target=null)
        {
            if(target != null)
            {
                target.GetComponent<BaseEnemyObj>().reduceHp(5); //tmp for slash

            }
        }
    }
}
