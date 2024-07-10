using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public bool Clear_1 = false;
    public bool Clear_2 = false;
    public bool Clear_3 = false;
    public bool Clear_4 = false;
    public bool Clear_5 = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public void StageClear_1()
    {
        Clear_1 = true;
    }
    public void StageClear_2()
    {
        Clear_2 = true;
    }
    public void StageClear_3()
    {
        Clear_3 = true;
    }
    public void StageClear_4()
    {
        Clear_4 = true;
    }
    public void StageClear_5()
    {
        Clear_5 = true;
    }
    public bool StageClearCheck(int i)
    {
        switch(i)
        {
            case 0: return Clear_1;
            case 1: return Clear_2;
            case 2: return Clear_3;
            case 3: return Clear_4;
            case 4: return Clear_5;
            default:
                return false;
        }
    }
}
