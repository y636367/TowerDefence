using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackRange : MonoBehaviour
{
    private void Awake()
    {
        OffAttackRange();
    }
    public void OnAttackRange(Vector3 position,int towerCode)
    {
        gameObject.SetActive(true);

        TowerAttackRange_Check(towerCode);
        transform.position=position;
    }
    public void OffAttackRange()
    {
        gameObject.SetActive(false);
    }
    public void TowerAttackRange_Check(int towerCode)
    {
        float Range = 0f;
        switch(towerCode)
        {
            case 0: //Sword
                Range = 3.2f;
                break;
            case 1: //Sycthe
                Range = 4.3f;
                break;
            case 2: //Bow
                Range = 6.0f;
                break;
            case 3: //Hammer
                Range = 3.2f;
                break;
            case 4: //Gun
                Range = 6.5f;
                break;
            case 5: //Rifle
                Range = 9.4f;
                break;
        }
        transform.localScale = new Vector3(Range, Range, 1f);
        
    }
}
