using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattle
{
    public void takeDamage(int damage,List<BaseEffect> effectList=null);
    public void attackTarget(List<GameObject> targetList);
    
    public void buffApply(int heal, List<BaseEffect> effectList = null);

}
