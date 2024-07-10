using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnime : MonoBehaviour
{
    [SerializeField]
    private GameObject Text = null;

    [SerializeField]
    private GameObject Button = null;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void On()
    {
        Text.SetActive(true);
    }
    public void On_1()
    {
        animator.SetTrigger("TextOn");
    }
    public void Button_On()
    {
        Button.SetActive(true);
    }
}
