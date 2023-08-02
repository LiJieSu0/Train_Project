using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SkillType
{
    Damage,
    Debuff,
    Buff,
    Heal,
}

public abstract class BasicSkill 
{   
    public string _skillName;
    public SkillType _skillType;
    public List<FieldPosition> _availablePosList = new List<FieldPosition>();

}
