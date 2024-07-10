using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_s : MonoBehaviour
{
    public static SceneManager_s instance;

    StageChoice stageChoice;

    void Awake()
    {
        stageChoice= FindObjectOfType<StageChoice>();
    }
    public void MainLoad()
    {
        SceneManager.LoadScene("Start");
    }
    public void Stage_Load()
    {
        if (StageManager.Instance.StageClearCheck(stageChoice.i)==true)
        {
            SceneManager.LoadScene("Game");
        }
        else if (stageChoice.i == 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
    public void StageChoiceLoad()
    {
        SceneManager.LoadScene("StageChoice");
    }
    public void Quit()
    {
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();

        //#if문 유니티 에디터 적용 부분 빌드시 주석 처리 및 삭제 필요
//#endif
    }
}
