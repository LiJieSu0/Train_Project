using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEffect : MonoBehaviour
{
    protected enum EffectTime
    {
        TurnStart,
        TurnEnd,
        Continuous,
        Permanent,
    }
    protected enum EffectType
    {
        Debuff,
        Buff,
        Damage,
        Armor,
        Special,
    }
    protected EffectType _type;

    public void ApplyEffect()
    {
        //TODO decide when to apply it
    }

}
