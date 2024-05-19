using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;

    public GameObject SettingButton;
    public GameObject GoEndGameUI;
    public GameObject FinalLevelUI;
    public TextMeshProUGUI txtNextLevel;
    public Button btnNextLevel;

    private bool isTouching = false;


    private void Awake()
    {
        if (UIManager.instance != null) Debug.LogError("There are 2 UIManager exist");
        UIManager.instance = this;
        // btnNextLevel.onClick.AddListener(OnClickNextLevel);
    }

    // public void OnClickNextLevel()
    // {
    //     LevelManager.Ins.LoadMap(LevelManager.Ins.CurLevel);
    // }

    #region SettingUi
    public void Setting()
    {
        isTouching = !isTouching;
        SettingButton.SetActive(isTouching);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
        isTouching = !isTouching;
        SettingButton.SetActive(isTouching);
    }

    public void Restart()
    {
        
    }
    #endregion

    #region  WinUI

    public void Win(GameObject Level)
    {
        GoEndGameUI.SetActive(true);
        txtNextLevel.text = (LevelManager.Ins.CurLevel).ToString();
    }

    public void Win2()
    {
        FinalLevelUI.SetActive(true);
    }
    #endregion
}
