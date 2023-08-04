using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePunch : BasicSkill
{
    // Start is called before the first frame update
    public FacePunch(bool isPlayer)
    {
        _isPlayer = isPlayer;
        if (isPlayer)
        {
            _skillName = "Facepunch";
            _skillType = SkillType.SpecifiedDamage;
            _damage = 40f;
            _availablePosList.Add(FieldPosition.E_FB);
            _availablePosList.Add(FieldPosition.E_FM);
            _availablePosList.Add(FieldPosition.E_FT);
        }
    }
}
