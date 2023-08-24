using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    Dictionary<BaseEffect,int> _effectDict {get; set;}
    void effectExecution(BaseEffect effect);
    void effectExeAtStart();
    void effectExeAtEnd();

    void removeEffet(BaseEffect effect);

    void addEffectToDict(BaseEffect effect);

}
