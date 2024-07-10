using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerChoice : MonoBehaviour
{
    private int towerNumber = 0;

    TowerSpawner spawner;

    public bool Choice = false;

    void Start()
    {
        spawner=FindObjectOfType<TowerSpawner>();
    }
    public void Sword_tower()
    {
        spawner.choiceNum = 0;
        spawner.t_Cost = 5;
        Choice= true;
    }
    public void Sycthe_tower()
    {
        spawner.choiceNum = 1;
        spawner.t_Cost = 7;
        Choice = true;
    }
    public void Bow_tower()
    {
        spawner.choiceNum = 2;
        spawner.t_Cost = 6;
        Choice = true;
    }
    public void Hammer_tower()
    {
        spawner.choiceNum = 3;
        spawner.t_Cost = 10;
        Choice = true;
    }
    public void Gun_tower()
    {
        spawner.choiceNum = 4;
        spawner.t_Cost = 12;
        Choice = true;
    }
    public void Rifle_tower()
    {
        spawner.choiceNum = 5;
        spawner.t_Cost = 20;
        Choice = true;
    }
}
