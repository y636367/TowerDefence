using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Sound
{
    public string name;//재생할 곡 이름
    public AudioClip clip; //곡
}
public class SoundManager : MonoBehaviour
{
    static public SoundManager Instance;
    //싱글톤 적용
    #region Singleton
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        BGMSlider=BGMSlider.GetComponent<Slider>();
        SFXSlider=SFXSlider.GetComponent<Slider>();
    }
    #endregion Singleton

    public AudioSource[] audioSourcesEffect;
    public AudioSource[] audioSourceBgm;

    public string[] playSoundName;

    public Sound[] EffectSound;
    public Sound[] BgmSound;

    public AudioMixer audioMixer;
    //오디오 믹서
    public Slider BGMSlider;
    public Slider SFXSlider;

    private int Sceneindex = 0;

    public Text BGM_Text;
    public Text SFX_Text;

    float bgm_value = -30;
    float sfx_value = -30;

    void Start()
    {
        playSoundName=new string[audioSourcesEffect.Length];

        SetFunction_UI();
    }
    void LateUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex!=Sceneindex)
        {
            FInd_slider();
            Sceneindex= SceneManager.GetActiveScene().buildIndex;
        }

        SetBgm();
        SetSfx();
    }
    #region SoundEffect
    public void PlaySoundEffect(string name)
    {
        for (int i = 0; i < EffectSound.Length; i++)
        {
            if (name == EffectSound[i].name)
            {
                for (int j = 0; j < audioSourcesEffect.Length; j++)
                {
                    if (!audioSourcesEffect[j].isPlaying)
                    {
                        playSoundName[j] = EffectSound[i].name;
                        audioSourcesEffect[j].clip = EffectSound[i].clip;
                        audioSourcesEffect[j].Play();
                        return;
                    }
                }
                Debug.Log("모든 가용 AudioSource가 사용중");
                return;
            }
        }
        Debug.Log(name+"사운드가 Manager에 등록되지 않았습니다.");
    }

    public void StopAllSoundEffect()
    {
        for (int i = 0; i < audioSourcesEffect.Length; i++)
        {
            audioSourcesEffect[i].Stop();
        }
    }
    public void StopSoundEffect(string name)
    {
        for (int i = 0; i < audioSourcesEffect.Length; i++)
        {
            if (playSoundName[i] == name)
            {
                audioSourcesEffect[i].Stop();
                return;
            }
        }
        Debug.Log("재생중인" + name + "사운드가 없습니다.");
    }
    #endregion SoundEffect
    #region Bgm
    public void PlaySoundBGM(string name)
    {
        for (int i = 0; i < BgmSound.Length; i++)
        {
            if (name == BgmSound[i].name)
            {
                for (int j = 0; j < audioSourceBgm.Length; j++)
                {
                    if (!audioSourceBgm[j].isPlaying)
                    {
                        playSoundName[j] = BgmSound[i].name;
                        audioSourceBgm[j].clip = BgmSound[i].clip;
                        audioSourceBgm[j].Play();
                        return;
                    }
                }
                Debug.Log("모든 가용 AudioSource가 사용 중");
                return;
            }
        }
        Debug.Log(name + "사운드가 SoundManager에 등록되지 않았습니다.");
    }
    public void StopAllSoundBGM()
    {
        for (int i = 0; i < audioSourceBgm.Length; i++)
        {
            audioSourceBgm[i].Stop();
        }
    }
    public void StopSoundBGM(string name)
    {
        for (int i = 0; i < audioSourceBgm.Length; i++)
        {
            if (playSoundName[i] == name)
            {
                audioSourceBgm[i].Stop();
                return;
            }
        }
        Debug.Log("재생중인" + name + "사운드가 없습니다.");
    }
    public void MuteOnBGM()
    {
        for (int i = 0; i < audioSourceBgm.Length; i++)
        {
            audioSourceBgm[i].mute = true;
        }
    }
    public void MuteOffBGM()
    {
        for (int i = 0; i < audioSourceBgm.Length; i++)
        {
            audioSourceBgm[i].mute = false;
        }
    }
    #endregion Bgm
    public void SetBgm()
    {
        audioMixer.SetFloat("BGM", BGMSlider.value);
        //로그 연산 값 전달
    }
    public void SetSfx()
    {
        audioMixer.SetFloat("SFX", SFXSlider.value);
    }
    public void FInd_slider()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("InGame");
        GameObject option_panel= option_panel = canvas.transform.Find("Option_Panel").gameObject;
        GameObject bgm_back = option_panel.transform.Find("BGM_Back").gameObject;
        GameObject sfx_back = option_panel.transform.Find("SFX_Back").gameObject;

        BGMSlider = bgm_back.transform.Find("BGM_Slider").gameObject.GetComponent<Slider>();
        SFXSlider = sfx_back.transform.Find("SFX_Slider").gameObject.GetComponent<Slider>();

        BGM_Text= bgm_back.transform.Find("BGM_Shame").gameObject.GetComponent<Text>();
        SFX_Text = sfx_back.transform.Find("SFX_Shame").gameObject.GetComponent<Text>();

        SetValue_UI();
    }
    #region First_Set_Sound_Slder
    private void SetFunction_UI()
    {
        ResetFunction_UI();

        BGMSlider.onValueChanged.AddListener(Function_Slider_BGM);
        SFXSlider.onValueChanged.AddListener(Function_Slider_SFX);
    }
    private void Function_Slider_BGM(float _value)
    {
        BGM_Text.text = (_value + 80).ToString();
        bgm_value = _value;
    }
    private void Function_Slider_SFX(float _value)
    {
        SFX_Text.text = (_value + 80).ToString();
        sfx_value = _value;
    }
    private void ResetFunction_UI()
    {
        BGMSlider.maxValue = 20f;
        SFXSlider.maxValue = 20f;

        BGMSlider.minValue = -80f;
        SFXSlider.minValue = -80f;

        BGMSlider.value = -30f;
        SFXSlider.value = -30f;

        BGMSlider.wholeNumbers = true;
        SFXSlider.wholeNumbers = true;

        audioMixer.SetFloat("BGM", BGMSlider.value);
        audioMixer.SetFloat("SFX", SFXSlider.value);
    }
    #endregion
    private void SetValue_UI()
    {
        BGMSlider.maxValue = 20f;
        SFXSlider.maxValue = 20f;

        BGMSlider.minValue = -80f;
        SFXSlider.minValue = -80f;
        //값 재설정 필요함

        BGMSlider.value = bgm_value;
        SFXSlider.value = sfx_value;

        BGM_Text.text = (bgm_value+80).ToString();
        SFX_Text.text = (sfx_value+80).ToString();

        BGMSlider.wholeNumbers = true;
        SFXSlider.wholeNumbers = true;

        audioMixer.SetFloat("BGM", BGMSlider.value);
        audioMixer.SetFloat("SFX", SFXSlider.value);

        BGMSlider.onValueChanged.AddListener(Function_Slider_BGM);
        SFXSlider.onValueChanged.AddListener(Function_Slider_SFX);
    }
}
