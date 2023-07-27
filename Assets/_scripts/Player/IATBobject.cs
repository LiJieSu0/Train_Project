using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IATBobject { //ATB Active Time Battle 
    float baseSpeed { get; set; }
    string _name { get; set; }
    bool isActing { get; set; }
    GameObject spriteOnBar { get; set; }
    void createProgression();
    void speedAdjust(float adjustment);
}
