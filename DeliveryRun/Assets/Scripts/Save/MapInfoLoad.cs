using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class MapInfoLoad : MonoBehaviour
{
    private MapInfo mapInfoMain;
    public bool isResult;

    private void Awake()
    {
        mapInfoMain = new MapInfo();
    }

    private void Start()
    {
        CountLoad(); 
        if(!isResult)
            GetComponent<MapLockUnLocked>().UpdateMapStatus();
    }

    public void CountLoad()
    {
        if (File.Exists(FilePath.savePath + "/MapInfo.json"))
        {
            string tempMapJsonString = File.ReadAllText(FilePath.savePath  + "/MapInfo.json");
            Debug.Log(tempMapJsonString);
            MapInfo tempMapData = JsonUtility.FromJson<MapInfo>(tempMapJsonString);
            mapInfoMain.SetMapInfo(tempMapData);
        }
        else
            return;
    }

    private void CountSave()
    {
        string tempMapJsonString = JsonUtility.ToJson(mapInfoMain);
        File.WriteAllText(FilePath.savePath  +"/MapInfo.json", tempMapJsonString);
    }

    public MapInfo GetMapInfo()
    {
        return mapInfoMain;
    }

    public void SaveMapInfo(MapInfo map)
    {
        mapInfoMain.SetMapInfo(map);
        CountSave();
    }
}
