using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    void Awake()
    {
        current = this;
    }
    public event Action<Creature> onHpReduce;
    public void HpReduce(Creature obj)
    {
        if(onHpReduce != null)
        {
            onHpReduce(obj);
        }
    }
}
