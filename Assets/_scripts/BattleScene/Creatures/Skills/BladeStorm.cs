using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeStorm : BasicSkill
{
    public BladeStorm(bool isPlayer)
    {
        _isPlayer = isPlayer;
        if (isPlayer)
        {
            _skillName = "Bladestorm";
            _skillType = SkillType.AreaDamage;
            _damage = 30f;
            _availablePosList.Add(FieldPosition.E_FB);
            _availablePosList.Add(FieldPosition.E_FM);
            _availablePosList.Add(FieldPosition.E_FT);
        }
    }
}
