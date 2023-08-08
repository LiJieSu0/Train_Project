using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Anchor : MonoBehaviour
{
    // Start is called before the first frame update
    private FieldPosition _pos;
    private SpriteRenderer _spriteRenderer;
    private List<SpriteRenderer> _childrenLayout = new List<SpriteRenderer>();
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _childrenLayout.Add(transform.GetChild(i).GetComponent<SpriteRenderer>());
        }
        disableChildLayoutSprite();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
        _pos = (FieldPosition)Enum.Parse(typeof(FieldPosition), transform.parent.gameObject.name);
        GameEvents.current.onShowTargetPos += showAnchor;
        GameEvents.current.onHideTargetPos += hideAnchor;
    }

    void showAnchor(FieldPosition pos)
    {
        if (_pos == pos && transform.parent.transform.childCount > 1)
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
        if (_spriteRenderer.enabled)
        {
            enableChildLayoutSprite();
        }
    }
    private void OnMouseExit()
    {
        if (_spriteRenderer.enabled)
        {
            disableChildLayoutSprite();
        }
    }
    private void OnMouseUp()
    {
        disableChildLayoutSprite();
        GameEvents.current.clickTarget(_pos);
    }

    private void enableChildLayoutSprite()
    {
        foreach (SpriteRenderer child in _childrenLayout)
        {
            child.enabled = true;
        }
    }
    private void disableChildLayoutSprite()
    {
        foreach (SpriteRenderer child in _childrenLayout)
        {
            child.enabled = false;
        }
    }
}
