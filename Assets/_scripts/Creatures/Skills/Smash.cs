using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : BasicSkill
{
    public float damage = 50;
    public Smash(string skillName)
    {
        _skillName = skillName;
        _skillType = SkillType.Damage;
        _availablePosList.Add(FieldPosition.E_FB);
        _availablePosList.Add(FieldPosition.E_FM);
        _availablePosList.Add(FieldPosition.E_BM);
    }
}
