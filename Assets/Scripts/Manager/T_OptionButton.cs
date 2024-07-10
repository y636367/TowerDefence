using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class T_OptionButton : MonoBehaviour
{
    [SerializeField]
    private TowerAttackRange towerAttackRange;
    [SerializeField]
    private GameObject Texts = null;

    [Header("Status")]
    [SerializeField]
    private Text Level_text = null;
    [SerializeField]
    private Text Damage = null;
    [SerializeField]
    private Text Speed = null;
    [SerializeField]
    private Text UpCost = null;
    [SerializeField]
    private Text SellCost = null;


    Tower tower;
    TotalMoney money;
    TowerSpawner towerSpawner;
    
    void Start()
    {
        tower=FindObjectOfType<Tower>();
        money=FindObjectOfType<TotalMoney>();
        towerSpawner=FindObjectOfType<TowerSpawner>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OffStatus();
        }
    }
    public void GetTower(Tower t_tower)
    {
        tower = t_tower;
    }
    public void OnStatus()
    {
        Texts.SetActive(true);
        towerAttackRange.OnAttackRange(tower.transform.position, tower.towercode);

        Level_text.text = tower.Level.ToString();
        Damage.text=tower.damage.ToString();
        Speed.text=tower.attackSpeed.ToString();
        if (tower.Level == 5)
        {
            UpCost.text = "MAX";
        }else
            UpCost.text=tower.up_cost.ToString();
        SellCost.text=tower.sell_cost.ToString();
    }
    public void OffStatus()
    {
        Texts.SetActive(false);
        towerAttackRange.OffAttackRange();
    }
    public void LevelUP()
    {
        double t_damage = 0f;
        if (tower.Level < 5&&money.currentCoin>=tower.up_cost)
        {
            tower.Level++;
            tower.attackSpeed -= 0.2d;
            money.SetCoin(tower.up_cost++);
            tower.sell_cost++;
            t_damage = tower.damage * 1.5f;
            tower.damage=Math.Round(t_damage ,1);
        }else if (money.currentCoin < tower.up_cost)
        {
            towerSpawner.CashFalse();
        }
        OnStatus();
    }
    public void Sell()
    {
        tower.towerSell();
        money.GetCoin(tower.sell_cost);
    }
}
