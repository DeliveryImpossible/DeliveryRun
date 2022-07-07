using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FilePath
{
    public static string savePath = Application.persistentDataPath + "/Saves";
                                    //Application.dataPath + "/Saves";
    public static string resourcePath = Application.persistentDataPath + "/Resources";
                                        //Application.dataPath + "/Resources";

    public static void Init()
    {
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
    }

}
