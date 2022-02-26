using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueManager : MonoBehaviour
{
    public static int dialgueIndex = 0;

    private DialogueParser parser;
    private PrologueAnimations animations;

    public GameObject dialogueBox;
    private Text name;
    private Text line;
    private void Start()
    {
        parser = GetComponent<DialogueParser>();
        animations = GetComponent<PrologueAnimations>();
        name = dialogueBox.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        line = dialogueBox.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        GetDialogueLine();
    }
    public void GetDialogueLine()
    {
        animations.FindAnimationEvent(dialgueIndex);

        if (dialgueIndex == parser.getEndLine()) return;

        Dialogue dialogue = parser.prologueDialogueDic[dialgueIndex];
        name.text = dialogue.name;
        line.text = dialogue.line;

        DialogueEvent();

    }

    private void DialogueEvent()
    {
        if (dialgueIndex == 0)
        {
            line.text += PlayerInfo.name;
        }
        if(name.text == "main")
        {
            name.text = " " + PlayerInfo.name;
        }
    }
}
