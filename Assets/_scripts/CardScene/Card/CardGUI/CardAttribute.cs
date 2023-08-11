using CardScene;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardAttribute : MonoBehaviour
{
    public BaseCardScriptable card;
    private Transform _cardFront;
    private GameObject _cardCost;
    private GameObject _cardName;
    private GameObject _cardDesc;
    private GameObject _cardPic;
    void Start()
    {
        _cardFront = this.transform.GetChild(0);
        _cardCost = _cardFront.Find("CardCost").Find("CardCost").gameObject;
        _cardName = _cardFront.Find("CardName").Find("CardName").gameObject;
        _cardDesc = _cardFront.Find("CardDescription").Find("CardDescription").gameObject;
        _cardPic = _cardFront.Find("CardPic").Find("CardPic").gameObject;
        _cardCost.GetComponent<TextMeshPro>().text = card._cost.ToString();
        _cardName.GetComponent<TextMeshPro>().text=card._cardName.ToString();
        _cardDesc.GetComponent<TextMeshPro>().text=card._cardDescription.ToString();
        _cardPic.GetComponent<SpriteRenderer>().sprite = card._sprite;
    }


}
