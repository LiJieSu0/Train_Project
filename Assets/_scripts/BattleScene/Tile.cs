using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, offSetColor;
    [SerializeField] private GameObject _highLight;


    public void Init(bool isOffSet)
    {
        GetComponent<SpriteRenderer>().color=isOffSet ? _baseColor : offSetColor;
    }

    private void OnMouseEnter()
    {
        EventObserver.currObj = gameObject;
        _highLight.SetActive(true);
    }
    private void OnMouseExit()
    {
        _highLight.SetActive(false);
        EventObserver.currObj = null;
    }
}
