using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCover : MonoBehaviour
{
    private void Update()
    {
        if(SceneManager._sceneManager._currPlayer == null)
        {
            this.gameObject.GetComponent<Image>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<Image>().enabled = false;

        }
    }
}
