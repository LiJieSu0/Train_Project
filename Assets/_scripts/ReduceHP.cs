using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ReduceHP : MonoBehaviour
{
    // Start is called before the first frame update
    private Button myBtn;
    private Creature myCreature;
    [SerializeField]
    private float btnDamage;
    public GameObject myHero;
    private void Start()
    {
        myBtn = GetComponent<Button>();
        myCreature = myHero.GetComponent<Creature>();
        myBtn.onClick.AddListener(() => OnButtonClick(myCreature));
    }
    public void OnButtonClick(Creature myCreature)
    {
        //myCreature._hp -= btnDamage;
        GameEvents.current.HpReduce(myCreature);
    }
}
