using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueNextButton : MonoBehaviour
{
    private PrologueManager prologueManager;

    private void Start()
    {
        prologueManager = GetComponent<PrologueManager>();
    }

    public void NextButtonClicked()
    {
        PrologueManager.dialgueIndex++;
        if(PrologueManager.dialgueIndex == 6)
        {
            SceneManager.LoadScene(ScenesNameConst.startScene);
        }
        prologueManager.GetDialogueLine();
    }
}
