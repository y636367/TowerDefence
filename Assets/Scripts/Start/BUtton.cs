using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BUtton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [SerializeField]
    private RectTransform Text = null;
    [SerializeField]
    private RectTransform Press = null;
    [SerializeField]
    private RectTransform Default = null;

    StageChoice stageChoice;

    bool pressed = false;

    void Start()
    {
        stageChoice=FindObjectOfType<StageChoice>();
    }
   public void OnPointerDown(PointerEventData eventData)
    {
        Text.transform.position=Press.transform.position;
        pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Text.transform.position=Default.transform.position;
        pressed = false;
    }
    public void StartButton()
    {
        if (stageChoice.WarningText.gameObject.activeSelf == true)
        {
            stageChoice.WarningText.gameObject.SetActive(false);
        }
        if (stageChoice.i != 0&& stageChoice.WarningText.gameObject.activeSelf == false)
        {
            stageChoice.WarningText.gameObject.SetActive(true);
        }
    }
}
