using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("Creature/Player"))]
public class PlayerAttribute : ScriptableObject
{
    public int MaxHP;
    public int Defense;
    public int Armor;
    public float Speed;
}
