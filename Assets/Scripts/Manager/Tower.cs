using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{

    [SerializeField]
    private GameObject projectile;//발사체
    [SerializeField]
    private Transform SpawnPoint;//발사체 생성 위치

    [SerializeField]
    public Transform target = null;

    public TowerPosition towerPostion = null;

    [Header("Status")]
    [SerializeField]
    public int Level = 1;
    [SerializeField]
    public float range = 15f;//공격범위
    [SerializeField]
    public double attackSpeed = 1.5f;//공격 속도
    [SerializeField]
    public double damage = 1f;//공격력
    [SerializeField]
    public int up_cost = 0;//업그레이드 비용 = 되팔기 비용
    [SerializeField]
    public int sell_cost = 0;//되팔기 비용

    [Header("Code")]
    [SerializeField]
    public int towercode = 0;

    [Header("Sound")]
    [SerializeField]
    private string AttackSound;

    private string enemyTag = "Enemy";

    private double t_speed = 0f;

    Animator anime;

    TowerSpawner t_spawner;

    // Start is called before the first frame update
    void Start()
    {
        t_spawner = FindObjectOfType<TowerSpawner>();

        towerPostion = t_spawner.t_Position;

        t_speed = attackSpeed;
        InvokeRepeating("UpdateTarget", 0f, (float)attackSpeed);
        anime= GetComponent<Animator>();
    }

    void UpdateTarget()
    {
        GameObject[] enemies=GameObject.FindGameObjectsWithTag(enemyTag);
        float shortesDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortesDistance)
            {
                shortesDistance=distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null&&shortesDistance<=range) 
        {
            target = nearestEnemy.transform;
            RotateToTarget();
            anime.SetTrigger("TargetOn");
            Shoot();
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        if (attackSpeed != t_speed)
        {
            CancelInvoke("UpdateTarget");
            t_speed= attackSpeed;
            ReSpeed();
        }
    }
    private void ReSpeed()
    {
        InvokeRepeating("UpdateTarget", 0f, (float)attackSpeed);
    }
    private void RotateToTarget()
    {
        float dx=target.position.x-transform.position.x;
        float dy=target.position.y-transform.position.y;

        float degree=Mathf.Atan2(dy,dx)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0,0,degree);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void Shoot()
    {
        GameObject t_projectile = Instantiate(projectile, SpawnPoint.position, SpawnPoint.rotation*(Quaternion.Euler(new Vector3(0,0,180))));
        Projectile t_P=t_projectile.GetComponent<Projectile>();

        SoundManager.Instance.PlaySoundEffect(AttackSound);

        if (t_P != null)
        {
            t_P.Seek(target,damage);
        }
    }
    public void towerSell()
    {
        towerPostion.IsBuildTower= false;
        Destroy(gameObject);
    }
}
