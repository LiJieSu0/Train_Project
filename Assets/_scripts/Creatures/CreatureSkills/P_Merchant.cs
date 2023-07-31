using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class P_Merchant : Player
{
    public class Smash : BasicSkill
    {
        public float damage = 50;
        public Smash(string skillName)
        {
            _skillName= skillName;
            _availablePosList.Add(FieldPosition.E_FB);
            _availablePosList.Add(FieldPosition.E_FM);
            _availablePosList.Add(FieldPosition.E_FT);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        initBtnList();
        Smash merchantSmash = new Smash("Merchant Smash!");
        Debug.Log(skillBtnList[0] == null);
        skill1(skillBtnList[0],merchantSmash);
        skillBtnList[1].onClick.AddListener(skill2);
        skillBtnList[2].onClick.AddListener(skill3);
        skillBtnList[3].onClick.AddListener(skill4);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(skillBtnList[0].gameObject.transform.GetChild(0).gameObject.name);
    }
    public void skill1(Button btn1,BasicSkill skill)
    {
        btn1.gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = skill._skillName;
        Debug.Log(btn1.gameObject.name);
    }
    public void skill2()
    {

    }
    public void skill3()
    {

    }
    public void skill4()
    {

    }
}
