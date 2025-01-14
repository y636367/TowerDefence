using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static Monster Instance;
    [SerializeField]
    private float monsterSpeed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    public double HP;
    public double Cost;

    MonsterSpawn monsterSpawn;
    WayPoints waypoint;
    TotalMoney money;
    Tomb tomb;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;

        waypoint = FindObjectOfType<WayPoints>();
        monsterSpawn = FindObjectOfType<MonsterSpawn>();
        money = FindObjectOfType<TotalMoney>();
        tomb = FindObjectOfType<Tomb>();

        target = waypoint.wayPoints[0];
        HP = monsterSpawn.Health;
        Cost= monsterSpawn.Cost;

    }

    private void Update()
    {
        Vector3 t_dir = target.position - transform.position;
        transform.Translate(t_dir.normalized * monsterSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.35f)
        {
            GetNextWayPoint();
        }
    }
    private void GetNextWayPoint()//방향 전환 함수
    {
        if (waypointIndex >= waypoint.wayPoints.Length - 1)//목적지 도달시 파괴
        {
            Destroy(gameObject);
            money.Decrease_Life();
            if (monsterSpawn.StageBoss == true)
            {
                GameManager.Instance.OverPanel();
            }
            return;
        }
        waypointIndex++;
        target = waypoint.wayPoints[waypointIndex];
    }
    public void TakeDamage(double damage,Monster monster)
    {
        monster.HP -= damage;
        if (monster.HP <= 0)
        {
            if (monsterSpawn.StageBoss == true)
            {
                GameManager.Instance.ClearPanel();            
            }
            money.GetCoin(monster.Cost);
            tomb.Death(monster);
            Destroy(monster.gameObject);
        }
    }
}
