using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageChoice : MonoBehaviour
{
    [SerializeField]
    private GameObject[] StageList= null;

    [SerializeField]
    private Transform[] Stageposition = null;

    [SerializeField]
    private Text StageCount = null;

    [SerializeField]
    public Text WarningText = null;

    public bool ChoiceOk = false;

    public int i = 0;
    int j = 1;
    int k = 4;
    void Start()
    {
        StageCount.text = (i+1).ToString(); 
        StageList[0].transform.position = Stageposition[1].position;
        StageList[1].transform.position = Stageposition[2].position;
        StageList[4].transform.position = Stageposition[0].position;
        StageList[2].SetActive(false);
        StageList[3].SetActive(false);
    }
    void Update()
    {
        StageList[i].transform.position = Stageposition[1].position;
        StageList[j].transform.position = Stageposition[2].position;
        StageList[k].transform.position = Stageposition[0].position;
    }

    public void NextStage()
    {
        if (i < 4)
        {
            StageList[++i].transform.position = Stageposition[1].position;
            StageList[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            i = 0;
            StageList[i].transform.position = Stageposition[1].position;
            StageList[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (j < 4)
        {
            StageList[++j].SetActive(true);
            StageList[j].transform.position = Stageposition[2].position;
            StageList[j].transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        else
        {
            j = 0;
            StageList[j].SetActive(true);
            StageList[j].transform.position = Stageposition[2].position;
            StageList[j].transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        if(k<4)
        {
            StageList[k].SetActive(false);
            StageList[++k].transform.position = Stageposition[0].position;
            StageList[k].transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        else
        {
            StageList[k].SetActive(false);
            k = 0;
            StageList[k].transform.position = Stageposition[0].position;
            StageList[k].transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        StageCount.text = (i + 1).ToString();
    }
    public void PrevStage()
    {
        if (i > 0)
        {
            StageList[--i].transform.position = Stageposition[1].position;
            StageList[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            i = 4;
            StageList[i].transform.position = Stageposition[1].position;
            StageList[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (j > 0)
        {
            StageList[j].SetActive(false);
            StageList[--j].transform.position = Stageposition[2].position;
            StageList[j].transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        else
        {
            StageList[j].SetActive(false);
            j = 4;
            StageList[j].transform.position = Stageposition[2].position;
            StageList[j].transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        if (k > 0)
        {
            StageList[--k].SetActive(true);
            StageList[k].transform.position = Stageposition[0].position;
            StageList[k].transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        else
        {
            k = 4;
            StageList[k].SetActive(true);
            StageList[k].transform.position = Stageposition[0].position;
            StageList[k].transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        StageCount.text = (i + 1).ToString();
    }
}
