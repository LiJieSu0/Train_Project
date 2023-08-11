using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    Dictionary<BaseEffect,int> _effectDict {get; set;}
    public void effectExecution();
    public void effectCheckAtStart();
    public void effectCheckAtEnd();
}
