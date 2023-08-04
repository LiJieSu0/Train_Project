using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : BasicSkill
{
    public Stab(bool isPlayer)
    {
        _isPlayer = isPlayer;
        if (isPlayer)
        {
            _skillName = "Stab";
            _skillType = SkillType.SpecifiedDamage;
            _damage = 55f;
            _availablePosList.Add(FieldPosition.E_FB);
            _availablePosList.Add(FieldPosition.E_FM);
            _availablePosList.Add(FieldPosition.E_FT);
        }
    }
}
