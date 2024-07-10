using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;

public class ViewOption : MonoBehaviour
{
    [SerializeField]
    private Dropdown resolution;
    List<Resolution> resolutions = new List<Resolution>();

    FullScreenMode fullScreenMode;

    [SerializeField]
    private Toggle screenbutton; //전체화면 체크

    int resolutionNum;
    void Awake()
    {
        SetResolution();
    }
    public void SetResolution()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate >= 60)//화면 재생 빈도 60이상 인 값만 추가
                resolutions.Add(Screen.resolutions[i]);
        }
        resolution.options.Clear();
        //DropDown메뉴의 리스트 요소 제거

        int optionValue = 0;

        foreach (Resolution item in resolutions) // 가져온 해상도 개수 만큼 반복
        {
            Dropdown.OptionData option = new Dropdown.OptionData(); // optiondata 객체화를 위한 객체 생성
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz"; //보이기 위한 텍스트화
            resolution.options.Add(option); // 해상도 옵션 추가

            if (item.width == Screen.width && item.height == Screen.height)
            {//현재 선택된 해상도로 DropDown메뉴의 값 변경
                resolution.value = optionValue;
            }
            optionValue++;
        }
        resolution.RefreshShownValue();//options 변경 되었으니 새로고침

        screenbutton.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }
    public void OptionChange(int x)
    {
        resolutionNum = x;
    }
    public void ChoiceButtion()
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, fullScreenMode);
        //선택된 해상도 적용
    }
    public void FullScreenCheck(bool isFull)
    {
        fullScreenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        //참이면 전체화면, 거짓이면 창모드
    }
}
