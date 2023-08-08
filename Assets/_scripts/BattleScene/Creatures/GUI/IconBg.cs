using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconBg : MonoBehaviour
{
    [SerializeField] public Color playerColor, enemyColor;
    private RawImage _rawImage;

    public void setColor(bool _isPlayer)
    {
        _rawImage = GetComponent<RawImage>();
        _rawImage.color = _isPlayer ? playerColor : enemyColor;
    }

}
