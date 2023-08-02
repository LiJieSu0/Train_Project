using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public GameObject pointedLayout;

    void Awake()
    {
        current = this;
    }

    public event Action<FieldPosition> onShowTargetPos;
    public event Action<FieldPosition> onHideTargetPos;
    public event Action<FieldPosition> onClickTarget;

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            pointedLayout = hit.collider.gameObject;
            FieldPosition hitPos = (FieldPosition)
                        Enum.Parse(typeof(FieldPosition), pointedLayout.transform.parent.gameObject.name);

            
        }
        else
        {

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
}
