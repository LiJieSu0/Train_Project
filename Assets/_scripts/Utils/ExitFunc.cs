using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitFunc : MonoBehaviour
{
    void Start()
    {
        Button exitBtn = GetComponent<Button>();
        exitBtn.onClick.AddListener(() => {
            Application.Quit();
            Debug.Log("Quit On click");
            });
    }

}
