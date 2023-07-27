using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    List<IATBobject> objList=new List<IATBobject>();
    public GameObject manager;
    private SceneManager _sceneManager;
    private float total = 160f;
    private bool isMoving = false;
    private Dictionary<IATBobject, float> actionDict=new Dictionary<IATBobject, float>();
    void Start()
    {
        _sceneManager=manager.GetComponent<SceneManager>();
        objList=_sceneManager.getActionList();
        
        createAllProgress();
        StartCoroutine(Progressing());

    }

    void FixedUpdate()
    {
        

    }
    private void Update()
    {
        Debug.Log(objList.Count);
    }

    private void createAllProgress()
    {
        foreach(IATBobject item in objList)
        {
            item.createProgression();
            GameObject onBar=Instantiate(item.spriteOnBar,new Vector3(0,0),Quaternion.identity);
            onBar.transform.parent = transform;
            onBar.transform.localPosition = new Vector3(-80f,0);
            onBar.transform.localScale= new Vector3(0.2f,0.2f,0);
            actionDict.Add(item, 0f); //init progress default is 0;
        }
    }

    private IEnumerator Progressing()
    {
        yield return new WaitForSeconds(0.5f);
        while (!isMoving)
        {
            progressAllObj();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void progressAllObj()
    {
        foreach (var item in objList)
        {
            try
            {
                float curr= actionDict[item];
                curr += item.baseSpeed;
                Debug.Log(curr);
                actionDict[item] = curr;
            }catch (Exception e)
            {
                Debug.Log(e);
            }


        }
    }

    private void setPosByProgress(GameObject progression, float currProgress) //get sprite on progression bar
    {
        float lenPerProgress=total/100f;
        Vector2 initialPos = new Vector2(-80, 0);
        initialPos.x += lenPerProgress * currProgress;
        progression.transform.localPosition= initialPos;
    }


}
