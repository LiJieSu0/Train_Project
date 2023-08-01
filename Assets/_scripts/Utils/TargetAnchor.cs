using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TargetAnchor : MonoBehaviour
{
    // Start is called before the first frame update
    private FieldPosition _pos;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        }
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
        _pos = (FieldPosition)Enum.Parse(typeof(FieldPosition),transform.parent.gameObject.name);
        GameEvents.current.onShowTargetPos += showAnchor;
        GameEvents.current.onHideTargetPos += hideAnchor;   

    }

    void showAnchor(FieldPosition pos)
    {
        if(_pos == pos)
        {
            _spriteRenderer.enabled = true;
        }
    }
    void hideAnchor(FieldPosition pos)
    {
        if (_pos == pos)
        {
            _spriteRenderer.enabled = false;
        }
    }
    private void OnMouseEnter()
    {
        for (int i = 0; i < transform.childCount; i++)//TODO edit the sprite shape
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    private void OnMouseExit()
    {
        for (int i = 0; i < transform.childCount; i++)//TODO edit the sprite shape
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnMouseUp()
    {
        GameEvents.current.clickTarget(_pos);
        //TODO return _pos to P_Merchant
    }
}
