using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class Dialogue
{
    public string name;
    public string line;
}
public class DialogueParser : MonoBehaviour
{
    public Dictionary<int, Dialogue> prologueDialogueDic = new Dictionary<int, Dialogue>();
    private void Start()
    {
        Parse();
    }

    private void Parse()
    {
        TextAsset prologueLineString = Resources.Load<TextAsset>("PrologueScript");
        JsonData prologueLineData = JsonMapper.ToObject(prologueLineString.ToString());

        for(int i = 0; i <  prologueLineData.Count; i++)
        {
            Dialogue dialogue = new Dialogue();
            dialogue.name = prologueLineData[i]["name"].ToString();
            dialogue.line = prologueLineData[i]["line"].ToString();
            prologueDialogueDic.Add(i, dialogue);
        }
    }


}
