using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameSettingButton : MonoBehaviour
{
    public InputField nameField;

    private void Awake()
    {
        FilePath.Init();
    }
    public void SettingName()
    {
        PlayerInfo.name = nameField.text;
        SavePlayerInfo.Save();
        SceneManager.LoadScene(ScenesNameConst.prologue);
    }
}
