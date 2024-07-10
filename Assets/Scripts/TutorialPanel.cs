using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.AllStop();
    }
    public void Panel_Destroy()
    {
        GameManager.Instance.Following();
        Destroy(gameObject);
    }
}
