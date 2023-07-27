using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using System.Linq;

public class SavedFileManager 
{
    // Start is called before the first frame update
    private string persistentDataPath = Application.persistentDataPath;
    private string[] files;
    public SavedFileManager()
    {
        files = Directory.GetFiles(persistentDataPath).Where(fileFilter).ToArray();
        foreach (string file in files)
        {
            Debug.Log(file);
        }
    }

    public string[] getSavedFiles()
    {
        Debug.Log(files.Length);
        return files;
    }
    public bool fileFilter(string filename)
    {
        string[] tmp =filename.Split(".");
        if (tmp[1] != "dat")
        {
            return false;
        }
        else { return true; }
    }
}
