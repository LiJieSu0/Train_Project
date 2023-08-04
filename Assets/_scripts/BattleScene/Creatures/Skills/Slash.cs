using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : BasicSkill
{
    public Slash(bool isPlayer)
    {
        _isPlayer = isPlayer;
        if (isPlayer)
        {
            _skillName = "Slash";
            _skillType = SkillType.SpecifiedDamage;
            _damage = 60f;
            _availablePosList.Add(FieldPosition.E_FB);
            _availablePosList.Add(FieldPosition.E_FM);
            _availablePosList.Add(FieldPosition.E_FT);
        }
    }

}
