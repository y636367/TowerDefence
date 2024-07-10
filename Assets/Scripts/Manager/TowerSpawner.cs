using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] towerPrefab;

    [SerializeField]
    private GameObject Impossible_panel = null;
    [SerializeField]
    private GameObject To_Expensive = null;

    [Header("Sound")]
    [SerializeField]
    private string towerBuild;
    [SerializeField]
    private string Warning;

    public int choiceNum = 0;
    public int t_Cost = 0;

    TotalMoney money;
    TowerChoice choice;

    public TowerPosition t_Position;

    void Awake()
    {
        money=FindObjectOfType<TotalMoney>();
        choice=FindObjectOfType<TowerChoice>();

        Impossible_panel.SetActive(false);
        To_Expensive.SetActive(false);
    }
    public void SpawnTower(Transform towerTransform)
    {
        t_Position=towerTransform.GetComponent<TowerPosition>();

        money.SetCoin(t_Cost);
        //타워 건설 여부 확인
        if (money.Cash == true)
        {
            if (t_Position.IsBuildTower == true)
            {
                BuildFalse();
                money.GetCoin(t_Cost);
                choice.Choice = false;
                return;
            }
            else
            {
                t_Position.IsBuildTower = true;
                GameObject t_tower = Instantiate(towerPrefab[choiceNum], towerTransform.position, Quaternion.identity);
                //t_tower.transform.SetParent(TowerCanvas.transform);
                SoundManager.Instance.PlaySoundEffect(towerBuild);
                money.Cash = false;
                choice.Choice = false;
            }
        }
        else
        {
            CashFalse();
            money.Cash = false;
        }
    }
    public void BuildFalse()
    {
        Impossible_panel.SetActive(true);
        SoundManager.Instance.PlaySoundEffect(Warning);
        Invoke("OffPanel", 1.5f);
    }
    public void CashFalse()
    {
        To_Expensive.SetActive(true);
        SoundManager.Instance.PlaySoundEffect(Warning);
        Invoke("OffPanel", 1.5f);
    }
    public void OffPanel()
    {
        Impossible_panel.SetActive(false);
        To_Expensive.SetActive(false);
    }
}
