using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectExecutionTime
{
    TurnStart,
    TurnEnd,
    Permanent,
}
public enum EffectType
{
    Buff,
    Debuff,
    Damage,
    Armor,
    EP,
    Recover,
    DefenseAdjust,
    AttackAdjust,
    SpeedAdjust,
    TurnAdjust,
    Special,
}

[CreateAssetMenu(fileName = "BaseEffect", menuName = "Effect/BaseEffect")]
public class BaseEffect : ScriptableObject
{

    public string _effectName;
    public List<EffectType> _typeList;
    public EffectExecutionTime _executionTime;
    public int _effectDuration;
    public int _stopActionTurn;
    public int _speedAdjustment;
    public int _armorAdjustment;
    public int _hpAdjustment;
    public int _epAdjustment;
    public void ApplyEffectToCreature(IEffect target)
    {
        target.addEffectToDict(this);
    }

}
