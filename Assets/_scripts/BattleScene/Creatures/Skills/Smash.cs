using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : BasicSkill
{
    public Smash(bool isPlayer)
    {
        _isPlayer = isPlayer;
        if (isPlayer)
        {
            _skillName = "Smash";
            _skillType = SkillType.SpecifiedDamage;
            _damage = 50f;
            _availablePosList.Add(FieldPosition.E_FB);
            _availablePosList.Add(FieldPosition.E_FM);
            _availablePosList.Add(FieldPosition.E_FT);
        }
    }
}
