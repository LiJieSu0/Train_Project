using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardScene
{
    public class BaseCardObj : MonoBehaviour,IPlayCard
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
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
