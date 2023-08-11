using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEffect : MonoBehaviour
{
    enum EffectType
    {
        Debuff,
        Buff,
        Damage,
        Armor,
    }
    private EffectType _type;


}
