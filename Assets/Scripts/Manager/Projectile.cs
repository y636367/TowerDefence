using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float Speed = 70f;

    [SerializeField]
    public double damage = 0f;

    Monster monster;

    void Start()
    {
        monster= FindObjectOfType<Monster>();
    }

    public void Seek(Transform _target, double t_damage)
    {
        target = _target;
        damage= t_damage;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFarm = Speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFarm)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFarm, Space.World);

    }
    void HitTarget()
    {
        Monster t_M = target.GetComponent<Monster>();
        monster.TakeDamage(damage,t_M);
        Destroy(gameObject);
    }
}
