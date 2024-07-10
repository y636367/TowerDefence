using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingMask : MonoBehaviour
{
    public void OffObject()
    {
        Camera.main.cullingMask = ~(1 << LayerMask.NameToLayer("Object"));
    }
    public void OnObject()
    {
        Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Object");
    }
}
