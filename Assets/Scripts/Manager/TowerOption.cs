using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOption : MonoBehaviour
{
    [SerializeField]
    private GameObject OptionPanel = null;
    [SerializeField]
    private GameObject Button = null;

    public void O_button_Create(Transform towertransform)
    {
        GameObject t_button = Instantiate(Button, towertransform.position, Quaternion.identity);
        t_button.transform.SetParent(OptionPanel.transform, true);
        t_button.transform.localScale= new Vector3(1f,1f,1f);
    }
}
