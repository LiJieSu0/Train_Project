using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPaused=false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }
}