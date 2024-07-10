using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalMoney : MonoBehaviour
{
    [SerializeField]
    private Text Coin = null;

    [SerializeField]
    private Text Life= null;

    public double currentCoin = 15;
    public double currentLife = 1;

    public bool Cash = false;

    [Header("Sound")]
    [SerializeField]
    private string Life_D;

    CameraShake cameraShake;

    void Awake()
    {
        Coin.text = "0";
        Life.text = "0";
    }
    void Start()
    {
        cameraShake=GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }
    void Update()
    {
        Coin.text = string.Format("{0:#,##0}", currentCoin);
        Life.text = string.Format("{0:#,##0}", currentLife);
    }
    public void GetCoin(double cost)
    {
        currentCoin +=cost;
    }
    public void SetCoin(double cost)
    {
        if (currentCoin >= cost)
        {
            currentCoin -= cost;
            Cash = true;
        }
        else
        {
            Cash= false;
        }
    }
    public void Decrease_Life()
    {
        currentLife--;
        SoundManager.Instance.PlaySoundEffect(Life_D);
        if(currentLife > 0)
            cameraShake.VibrateForTime(0.1f);
        if (currentLife <= 0)
        {
            GameManager.Instance.OverPanel();
        }
    }
}
