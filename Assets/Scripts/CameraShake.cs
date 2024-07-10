using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private float ShakeAmount;

    [SerializeField]
    private Canvas canvas;

    float ShakeTime;
    Vector3 initialPosition;

    public void VibrateForTime(float time)
    {
        ShakeTime= time;
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.renderMode = RenderMode.WorldSpace;
    }
    void Start()
    {
        initialPosition = new Vector3(84f, -51.28331f, 5f);
    }
    void Update()
    {
        if (ShakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime-=Time.deltaTime;
        }
        else
        {
            ShakeTime= 0.0f;
            transform.position=initialPosition;
            canvas.renderMode=RenderMode.ScreenSpaceCamera;
        }
    }
}
