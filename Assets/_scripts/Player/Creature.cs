using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private Creature _creature;
    public float _hp = 100f;
    void Start()
    {
        _creature = GetComponent<Creature>();
    }

    void Update()
    {
    }
}
