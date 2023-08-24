using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Creature/Skill")]
public class SkillScriptable : ScriptableObject
{
    public string skillName;
    public int damage;
    public int targetNums;
    public BaseEffect effect;


}
