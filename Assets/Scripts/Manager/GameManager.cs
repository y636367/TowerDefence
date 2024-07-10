using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    bool SpeedUP_One = false;
    bool SpeedUP_Two = false;

    bool Over_Clear = false;

    bool Pause = false;

    [SerializeField]
    private Text Two = null;
    [SerializeField]
    private Text Three = null;

    [SerializeField]
    private GameObject gameOverPanel = null;
    [SerializeField]
    private GameObject clearPanel = null;

    CullingMask cullingMask;
    T_OptionButton optionButton;
    MonsterSpawn monsterSpawn;

    [Header("Sound")]
    [SerializeField]
    private string GameOver;
    [SerializeField]
    private string StageClear;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        cullingMask=FindObjectOfType<CullingMask>();
        optionButton=FindObjectOfType<T_OptionButton>();
        monsterSpawn=FindObjectOfType<MonsterSpawn>();

        Over_Clear = false;
        SpeedUP_One = false;
        SpeedUP_Two = false;
    }

    void Update()
    {
        if (SpeedUP_One == true)
        {
            if (SpeedUP_Two == true)
            {
                Time.timeScale = 3f;
            }
            else
            {
                Time.timeScale = 2f;
            }
        }
        else
            Time.timeScale = 1f;

        if(Pause== true)
        {
            Time.timeScale = 0f;
        }

        if(Over_Clear== true)
        {
            Time.timeScale = 1f;
        }
    }

    public void AllStop()
    {
        Pause = true;
    }
    public void Following()
    {
        Pause = false;
    }


    public void UP_One()
    {
        if (SpeedUP_One == true)
        {
            Two.gameObject.SetActive(false);
            UP_Two();
        }
        else
        {
            SpeedUP_One = true;
            Two.gameObject.SetActive(true);
        }
    }
    public void UP_Two()
    {
        if (SpeedUP_Two == true)
        {
            SpeedUP_One = false;
            SpeedUP_Two = false;
            Two.gameObject.SetActive(false);
            Three.gameObject.SetActive(false);
        }
        else
        {
            SpeedUP_Two = true;
            Three.gameObject.SetActive(true);
        }
    }
    public void OverPanel()
    {
        cullingMask.OffObject();
        optionButton.OffStatus();
        gameOverPanel.SetActive(true);
        SoundManager.Instance.PlaySoundEffect(GameOver);
        Over_Clear = true;
    }
    public void ClearPanel()
    {
        cullingMask.OffObject();
        optionButton.OffStatus();
        clearPanel.SetActive(true);
        SoundManager.Instance.PlaySoundEffect(StageClear);
        Over_Clear = true;
    }
    public void NextWave()
    {
        monsterSpawn.ReadyTime = 1;
    }
}
