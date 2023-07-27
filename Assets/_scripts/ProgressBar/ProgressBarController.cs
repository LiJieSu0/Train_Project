using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    List<GameObject> _FullProgress;
    List<IATBobject> objList=new List<IATBobject>();
    public GameObject manager;
    private SceneManager _sceneManager;
    private float total = 160f;
    private bool _ProgressPaused;
    private struct ProgressPtr //value of actionDict
    {
        public GameObject sprite;
        public float progression;
        public ProgressPtr(GameObject sprite,float progression)
        {
            this.sprite = sprite;
            this.progression = progression;
        }
    }
    private Dictionary<IATBobject, ProgressPtr> actionDict=new Dictionary<IATBobject, ProgressPtr>();
    void Start()
    {
        _FullProgress = EventObserver.FullProgress;
        _ProgressPaused=EventObserver.ProgressPaused;
        _sceneManager = manager.GetComponent<SceneManager>();
        objList=_sceneManager.getActionList();
        createAllProgress();
        StartCoroutine(Progressing());

    }

    void FixedUpdate()
    {
        

    }
    private void Update()
    {

    }

    private void createAllProgress()
    {

        foreach(IATBobject item in objList)
        {
            Debug.Log(item._name);
            item.createProgression();
            GameObject onBar=Instantiate(item.spriteOnBar,new Vector3(0,0),Quaternion.identity);
            onBar.transform.SetParent(transform);
            onBar.transform.localPosition = new Vector3(-80f,0); //set relative pos on the bar
            onBar.transform.localScale= new Vector3(0.2f,0.2f,0); //set the sprite scale
            float initProgress = 0f;
            ProgressPtr tmp= new ProgressPtr(onBar, initProgress);
            actionDict.Add(item, tmp); //init progress default is 0;
        }
    }

    private IEnumerator Progressing()
    {
        yield return new WaitForSeconds(0.5f);

        while (!_sceneManager.isFinished)
        {
            Debug.Log("Progessing is running");
            while(_ProgressPaused)
            {
                yield return null;
            }
            progressAllObj();
            yield return new WaitForSeconds(0.5f); //TODO change the exit condition
        }
        Debug.Log("Battle is Finished");
    }

    private void progressAllObj()
    {
        foreach (var item in objList)
        {
            try
            {
                ProgressPtr dictPtr = actionDict[item];
                GameObject sprite= dictPtr.sprite;
                float currProgress= dictPtr.progression;
                if (currProgress >= 100)
                {
                    if(item is CharacterStatus)
                    {
                        CharacterStatus currPlayer = (CharacterStatus)item;
                        currPlayer.isActing = true;
                        _ProgressPaused = true;
                        StartCoroutine(PlayerMoving(currPlayer));
                    }
                    else
                    {
                        Debug.Log("Enemy is moving");
                        //TODO item is enemy or AI object
                    }
                    currProgress=0;
                }
                else
                {
                    currProgress += item.baseSpeed;
                    dictPtr.progression = currProgress;
                    setPosByProgress(sprite, currProgress);
                    actionDict[item] = dictPtr;
                    Debug.Log(currProgress);
                }

                





            }catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    private IEnumerator PlayerMoving(CharacterStatus currPlayer)
    {
        yield return WaitForPlayerCommand(currPlayer);

    }

    private IEnumerator WaitForPlayerCommand(CharacterStatus currPlayer)
    {
        currPlayer.showCommandMenu();
        while (true) {
            Debug.Log("Player is thinking");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Key pressed");
                currPlayer.isActing = false;
                _ProgressPaused = false;
                yield break;
            }
            yield return null;
        }
    }

    private void setPosByProgress(GameObject progressSprite, float currProgress) //get sprite on progression bar
    {
        float lenPerProgress=total/100f;
        Vector2 initialPos = new Vector2(-80, 0);
        initialPos.x += lenPerProgress * currProgress;
        if (initialPos.x >= 80f) //set the limitaion
        {
            initialPos.x = 80f;
        }
        progressSprite.transform.localPosition= initialPos;
    }


}
