using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class P_Merchant : Player
{
    public P_Merchant()
    {
        _firstSkill = new Smash(true);
        _secondSkill = new Slash(true);
        _thirdSkill = new Stab(true);
        _forthSkill = new BladeStorm(true);
    }

}
