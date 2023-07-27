using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadFileSys : MonoBehaviour
{
    public Button loadBtn;
    public Button cancelBtn;
    public GameObject hideWhileLoading;
    public GameObject showMenuWhileLoading;
    public GameObject prefabSavedFileBtn;
    //TODO hide obj, show canvas, show loaded file,
    private Vector2 StartPos = new Vector2(0, 360);
    void Start()
    {
        cancelBtn.onClick.AddListener(cancelLoadBtn);
        loadBtn.onClick.AddListener(showLoadFiles);
    }

    // Update is called once per frame

    void showLoadFiles()
    {
        hideWhileLoading.SetActive(false);
        showMenuWhileLoading.SetActive(true);
        SavedFileManager savedFileManager = new SavedFileManager();
        string[] fileArr= savedFileManager.getSavedFiles();

        DateTime currTime= DateTime.Now;
        for(int i=0;i<fileArr.Length;i++)
        {
            string filePath = fileArr[i];
            
            string fileName = filePath.Replace(Application.persistentDataPath+"\\", "").Replace(".dat", "");
            GameObject fileObj = Instantiate(prefabSavedFileBtn, showMenuWhileLoading.transform);
            fileObj.transform.localPosition = StartPos + new Vector2(0, -220 * i);
            fileObj.name = "SavedFileBtn" + i;
            GameObject txt = fileObj.transform.GetChild(0).gameObject;
            string fileStr = $"FileNo: {i}\nFileName: {fileName}\nFileDate:{currTime.ToString("HH:mm:ss")}";
            txt.GetComponent<TMP_Text>().text = fileStr;

        }






        /* After select saved file
        close menu
        load file
        load scene
         
         */
    }
    void cancelLoadBtn()
    {
        showMenuWhileLoading.SetActive(false);
        hideWhileLoading.SetActive(true );
    }
}
