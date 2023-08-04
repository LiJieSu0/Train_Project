using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public GameObject pointedObj;

    void Awake()
    {
        current = this;
    }

    public event Action<FieldPosition> onShowTargetPos;
    public event Action<FieldPosition> onHideTargetPos;
    public event Action<FieldPosition> onClickTarget;

    public event Action<Creature> onTurnChange;

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            pointedObj = hit.collider.gameObject;
            FieldPosition hitPos = (FieldPosition)
                        Enum.Parse(typeof(FieldPosition), pointedObj.transform.parent.gameObject.name);
        }
        else
        {
            pointedObj = null;
        }
    }

    public void showTargetPos(FieldPosition pos)
    {
        if(onShowTargetPos != null)
        {
            onShowTargetPos(pos);
        }
    }
    public void hideTargetPos(FieldPosition pos)
    {
        if (onHideTargetPos != null)
        {
            onHideTargetPos(pos);
        }
    }
    public void clickTarget(FieldPosition pos) { 
        if(onClickTarget != null)
        {
            onClickTarget(pos);
        }
    }

    public void turnChange(Creature c)
    {
        if(onTurnChange != null)
        {
            onTurnChange(c);
        }
    }

}
