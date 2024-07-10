using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private TowerSpawner towerSpawner;

    Camera mainCamera;

    private Ray ray;
    private RaycastHit hit;

    private RaycastHit t_hit;

    TowerChoice choice;
    T_OptionButton optionButton;

    private void Awake()
    {
        //maincamera 태그 오브젝트 탐색, 컴포넌트 정보 전달
        mainCamera= Camera.main;
        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 와 동일

        choice=FindObjectOfType<TowerChoice>();
        optionButton=FindObjectOfType<T_OptionButton>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            //카메라 위치에서 화면의 마우스 위치를 관통하는 광선 생성
            //ray.origin : 광선의 시작 위치(=카메라 위치)
            //ray.Direction : 광선의 진행방향

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            //2D 모니터를 통해 3D 월드의 오브젝트를 마우스로 선택
            //광선에 부딪히는 오브젝트를 검출해서 hit에 저장
            {
                if (hit.transform.CompareTag("TowerPosition"))
                //광선에 부딪힌 오브젝트의 태그가 TowerPosition이면
                {
                    if (choice.Choice == true)
                    {
                        towerSpawner.SpawnTower(hit.transform);
                        //타워를 생성하는 SpawnTower호출
                    }
                }else if (hit.transform.CompareTag("Tower"))
                {
                    optionButton.GetTower(hit.transform.GetComponent<Tower>());
                    optionButton.OnStatus();
                }
                else if(t_hit.transform!=hit.transform)
                {
                    optionButton.OffStatus();
                }
                t_hit = hit;
                choice.Choice = false;
                
            }
        }
    }
}
