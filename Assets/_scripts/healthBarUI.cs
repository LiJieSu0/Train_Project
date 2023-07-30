using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class healthBarUI : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider mySlider;
    private Creature creature;

    void Start()
    {
        mySlider = gameObject.GetComponent<Slider>();
        mySlider.value = 1;
        GameEvents.current.onHpReduce += updateHP;
        creature = transform.parent.gameObject.
               transform.parent.GetComponent<Creature>();
    }

    void updateHP(Creature creatureFromPublisher)
    {
        if (creatureFromPublisher == this.creature )
        {
            mySlider.value = creature._hp / 100;
            Debug.Log("update hp bar");
        }
    }
}
