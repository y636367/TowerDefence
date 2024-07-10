using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPosition : MonoBehaviour
{
    //자동 구현 프로퍼티 사용, 해당 위치에 타워가 건설되어있는 지 검사
    public bool IsBuildTower { set; get; }

    private void Awake()
    {
        IsBuildTower = false;
    }
   
}
