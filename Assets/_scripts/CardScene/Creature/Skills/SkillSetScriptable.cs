using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillSet", menuName = "Creature/SkillSet")]
public class SkillSetScriptable : ScriptableObject
{
    public SkillScriptable[] skillSet;
}
