using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Creature
{
    private PlayerState _currState = PlayerState.noAction;
    private BasicSkill _selectedSkill = null;
    private FieldPosition _targetPos = FieldPosition.NULL;
    protected GameObject commandPanel;
    protected List<Button> skillBtnList= new List<Button>();
    // Start is called before the first frame update


    public void initBtnList()
    {
        commandPanel = GameObject.Find("CommandPanel");
        for (int i = 0; i < commandPanel.transform.childCount; i++)
        {
            skillBtnList.Add(commandPanel.transform.GetChild(i).GetComponent<Button>());
        }
    }
    // Update is called once per frame
    void Update()
    {

    }


}
