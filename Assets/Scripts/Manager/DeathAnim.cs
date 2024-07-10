using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnim : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField]
    private string MonsterDeath;
    public void Destroy()
    {
        SoundManager.Instance.PlaySoundEffect(MonsterDeath);
        Destroy(this.gameObject);
    }
}
