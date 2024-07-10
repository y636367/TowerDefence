using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb : MonoBehaviour
{
    [SerializeField]
    private GameObject death = null;
    [SerializeField]
    private GameObject Canvas= null;
    public void Death(Monster Death_Place)
    {
        GameObject t_death=Instantiate(death, Death_Place.transform.position, Quaternion.identity);
        t_death.transform.SetParent(Canvas.transform);
    }
}
