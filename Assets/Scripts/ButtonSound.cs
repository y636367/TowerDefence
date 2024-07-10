using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField]
    private string Click;

    public void Click_Sound()
    {
        SoundManager.Instance.PlaySoundEffect(Click);
    }
}
