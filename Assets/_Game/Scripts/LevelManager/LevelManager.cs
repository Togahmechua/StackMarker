using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Ins;
    public int CurLevel;
    public List<Level> map;
    public Level curMap;

    void Awake()
    {
        Ins = this;
        
        CurLevel = PlayerPrefs.GetInt("CurrentLevel",1); 
    }




    #region SpawnMap
    public void SpawnMap1()
    {
        curMap = Instantiate(map[0], map[0].transform.position, map[0].transform.rotation);
        curMap.gameObject.SetActive(true);
    }

    // public void DestroyMap1()
    // {

    //     Level levelComponent = FindObjectOfType<Level>();
    //     if (levelComponent != null)
    //     {
    //         GameObject map1 = levelComponent.gameObject;
    //         map1.SetActive(false);
    //         // Destroy(map1);
    //         // Làm việc với map1
    //     }
    //     else
    //     {
    //         // Xử lý trường hợp không tìm thấy Level
    //         Debug.Log("Cant not find");
    //     }
    // }

    public void SpawnMap2()
    {
        // LoadMap(CurLevel);

        curMap = Instantiate(map[1], map[1].transform.position, map[1].transform.rotation);
        map[1].gameObject.SetActive(true);
    }

    // public void DestroyMap2()
    // {
    //     Level levelComponent = FindObjectOfType<Level>();
    //     if (levelComponent != null)
    //     {
    //         GameObject map1 = levelComponent.gameObject;
    //         map1.SetActive(false);
    //         // Destroy(map1);
    //         // Làm việc với map1
    //     }
    //     else
    //     {
    //         // Xử lý trường hợp không tìm thấy Level
    //         Debug.Log("Cant not find");
    //     }
    // }

    public void SpawnMap3()
    {
        curMap = Instantiate(map[2], map[2].transform.position, map[2].transform.rotation);
        map[2].gameObject.SetActive(true);
    }

    // public void DestroyMap3()
    // {
    //     Level levelComponent = FindObjectOfType<Level>();
    //     if (levelComponent != null)
    //     {
    //         GameObject map1 = levelComponent.gameObject;
    //         map1.SetActive(false);
    //         // Destroy(map1);
    //         // Làm việc với map1
    //     }
    //     else
    //     {
    //         // Xử lý trường hợp không tìm thấy Level
    //         Debug.Log("Cant not find");
    //     }
    // }


    public void Load_Scene()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

    public void DestroyMap()
    {
        if (curMap != null)
        {
            curMap.gameObject.SetActive(false);
            // Destroy(curMap.gameObject);
        }
    }

    public void Check()
    {
        if (CurLevel >= 4)
        {
            CurLevel = 3;
        }
    }

    public void LoadMap(int level)
    {
        if (CurLevel == 1)
        {
            this.SpawnMap1();
        }
        else if (CurLevel == 2)
        {
            this.SpawnMap2();
        }
        else if (CurLevel == 3)
        {
            this.SpawnMap3();
        }
    }

    public void ResetMap()
    {
        CurLevel--;
    }

    public void NewGame()
    {
        CurLevel = 1;
        // PlayerPrefs.DeleteAll();
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
