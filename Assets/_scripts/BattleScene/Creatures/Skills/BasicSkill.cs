using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SkillType
{
    SpecifiedDamage,
    AreaDamage,
    Debuff,
    Buff,
    Heal,
}



public abstract class BasicSkill 
{   
    public string _skillName;
    public SkillType _skillType;
    public List<FieldPosition> _availablePosList = new List<FieldPosition>();
    public float _damage;
    public bool _isPlayer;
    public void dealDamageToTarget(Creature target)
    {
        Debug.Log(_skillName + " deal "+_damage+" damage to target " + target._CharName);
    }
    public void waitForSelectingTarget()
    {

    }
}
