using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoving_S : MonoBehaviour
{
    [SerializeField]
    private RectTransform S_transform = null;
    [SerializeField]
    private RectTransform F_transform = null;

    bool position = false;

    void Awake()
    {
        StartCoroutine(Moving_1());
    }
    private IEnumerator Moving_1()
    {
        position = false;

        Vector3 dir = S_transform.position - transform.position;

        while (Vector3.Distance(transform.position, S_transform.position) >= 0.4f)
        {
            transform.Translate(dir.normalized * Time.deltaTime * 8f);
            yield return null;
        }
        transform.position = S_transform.position;
        StartCoroutine(Delay());
    }
    private IEnumerator Moving_2()
    {
        position = true;

        Vector3 dir= F_transform.position - transform.position;

        while (Vector3.Distance(transform.position, F_transform.position) >= 0.4f)
        {
            transform.Translate(dir.normalized * Time.deltaTime * 8f);
            yield return null;
        }
        transform.position = F_transform.position;
        StartCoroutine(Delay());
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.5f);

        if (position == false)
        {
            StartCoroutine(Moving_2());
        }else
        {
            StartCoroutine(Moving_1());
        }
    }
}
