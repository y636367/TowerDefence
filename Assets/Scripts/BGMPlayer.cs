using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
    public static BGMPlayer Instance;

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
                Destroy(gameObject);
        }
    }
    void Start()
    {
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
