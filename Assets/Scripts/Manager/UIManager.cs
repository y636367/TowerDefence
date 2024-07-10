using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private int SceneIndex = 0;

    [Header("Sound")]
    [SerializeField]
    private string[] BGM;

   void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
                Destroy(this.gameObject);
        }
        SoundManager.Instance.PlaySoundBGM(BGM[0]);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != SceneIndex)
        {
            BGMStop();
            SceneIndex = SceneManager.GetActiveScene().buildIndex;
            BGMPlay();
        }
    }
    public void BGMPlay()
    {
        SoundManager.Instance.PlaySoundBGM(BGM[SceneIndex]);
    }
    public void BGMStop()
    {
        SoundManager.Instance.StopAllSoundBGM();
    }
}
