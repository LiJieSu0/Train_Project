using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardScene
{
    public interface IProgress 
    {
        float _speed { get; set; }
        float _timeToAction { get; set; }
        float _currProgress { get; set; }
        GameObject _gameObject { get; }
    }
}