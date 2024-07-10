using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefab = null;
    [SerializeField]
    private GameObject MonsterPrefab = null;
    [SerializeField]
    private RectTransform spawnPoint = null;
    [SerializeField]
    private Text Stage_Text = null;

    [Header("Sound")]
    [SerializeField]
    private string WaveStart;

    [SerializeField]
    private Text enemycount = null;

    [SerializeField]
    public float SpawnTime = 5f;

    private float spawncountdown = 2f;
    private int waveNumber = 0;
    public float ReadyTime = 0;
    public int Wave = 1;
    public int Stage = 1;
    private int MonsterCategory = 0;
    private int MonsterCount = 1;

    public float Health = 0;
    public float Cost = 0;

    bool BossTime;
    public bool StageBoss = false;

    void Start()
    {
        Stage_Text.text=Stage.ToString();
    }
    private void Update()
    {
        if (spawncountdown <= 0f&&ReadyTime==0f&&StageBoss==false)
        {
            Category();
            StartCoroutine(SpawnWave());
            StageCount();
            spawncountdown = SpawnTime;
            ReadyTime = 30;
            SoundManager.Instance.PlaySoundEffect(WaveStart);
        }
        if (spawncountdown != 0f)
        {
            spawncountdown -= Time.deltaTime;
        }
        if (ReadyTime <= 30)
        {
            if (ReadyTime > 0)
            {
                ReadyTime -= Time.deltaTime;
            }else if (ReadyTime < 0)
            {
                ReadyTime = 0f;
            }
        }
        enemycount.text=Mathf.Round(ReadyTime).ToString();
    }
    IEnumerator SpawnWave()
    {
        if (Stage == 1 || Stage == 2 || Stage == 4)
        {
            if (Wave < 5 || (Wave > 5 && Wave < 10))
            {
                waveNumber = (MonsterCount++) * 3;
            }
            else if (Wave == 5||Wave==10||Wave==25)
            {
                waveNumber = 3;
                MonsterCount = 1;
            }
            if (BossTime != true)
            {
                if (Wave > 10 && Wave < 16)
                {
                    waveNumber = MonsterCount++ * 3;
                    if (MonsterCount == 6)
                        MonsterCount = 1;
                }
                else if (Wave > 15 && Wave < 21)
                {
                    waveNumber = MonsterCount++ * 3;
                    if (MonsterCount == 6)
                        MonsterCount = 1;
                }
                else if (Wave > 20 && Wave < 25)
                {
                    waveNumber = MonsterCount++ * 3;
                    if (MonsterCount == 5)
                        MonsterCount = 1;
                }
            }
            else if (BossTime == true)
            {
                if (Wave == 11 || Wave == 21 || Wave == 26)
                    waveNumber = 1;
            }
        }
        else if (Stage == 3 || Stage==5)
        {
            if (Wave < 6)
            {
                waveNumber = MonsterCount++ * 3;
                if (MonsterCount == 6)
                    MonsterCount = 1;
            }else if (Wave > 5 && Wave < 11)
            {
                waveNumber = MonsterCount++ * 3;
                if (MonsterCount == 6)
                    MonsterCount = 1;
            }else if (Wave > 10 && Wave < 16)
            {
                waveNumber = MonsterCount++ * 3;
                if (MonsterCount == 6)
                    MonsterCount = 1;
            }else if (Wave > 15 && Wave < 21)
            {
                waveNumber = MonsterCount++ * 3;
                if (MonsterCount == 6)
                    MonsterCount = 1;
            }
            if (Wave == 21 && BossTime == true)
                waveNumber = 1;

        }
        Debug.Log(Wave+" Wave");
        Debug.Log(MonsterCount-1+" Count");
        Debug.Log(waveNumber+" Monster");
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
        Wave++;
    }
    private void SpawnEnemy()//적 생성
    {
        GameObject t_monster = Instantiate(enemyPrefab[MonsterCategory],spawnPoint.anchoredPosition, Quaternion.identity);
        t_monster.transform.SetParent(MonsterPrefab.transform,false);   
    }
    private void StageCount()
    {
        Stage_Text.text = Stage.ToString();
        if (StageBoss == false)
        {
            if (BossTime == true)
            {
                BossTime = false;
            }
            if (Wave == 11 && Stage == 1)
            {
                Stage++;
                Wave = 0;
            }
            else if (Wave == 21 && Stage == 2)
            {
                Stage++;
                Wave = 0;
            }
            else if (Wave == 21 && Stage == 3)
            {
                Stage++;
                Wave = 0;
            }
            else if (Wave == 26 && Stage == 4)
            {
                Stage++;
                Wave = 0;
            }
            else if (Wave == 21 && Stage == 5)
            {
                Stage = 1;
                Wave = 0;
            }
        }
    }
    private void Category()
    {
        #region Stage1
        if (Stage == 1)
        {
            if (Wave < 5)
            {
                MonsterCategory = 0;
                Health = 3;
                Cost = 1;
            }
            else if (Wave == 5)
            {
                MonsterCategory = 2;
                Health = 5;
                Cost = 3;
            }
            else if (Wave > 5 && Wave < 10)
            {
                MonsterCategory = 1;
                Health = 10;
                Cost = 1;
            }
            else if (Wave == 10)
            {
                MonsterCategory = 3;
                Health = 15;
                Cost = 3;
            }
            else if (Wave == 11)
            {
                MonsterCategory = 15;
                Health = 30;
                Cost = 10;
                BossTime = true;
            }
        }
        #endregion
        #region Stage2
        if (Stage == 2)
        {
            if (Wave < 5)
            {
                MonsterCategory = 4;
                Health = 15;
                Cost = 1;
            }
            else if (Wave == 5)
            {
                MonsterCategory = 8;
                Health = 25;
                Cost = 3;
            }
            else if (Wave > 5 && Wave < 10)
            {
                MonsterCategory = 5;
                Health = 30;
                Cost = 1;
            }
            else if (Wave == 10)
            {
                MonsterCategory = 9;
                Health = 40;
                Cost = 3;
            }
            else if (Wave > 10 && Wave < 16)
            {
                MonsterCategory = 2;
                Health = 35;
                Cost = 1;
            }
            else if (Wave > 15 && Wave <= 20)
            {
                MonsterCategory = 3;
                Health = 45;
                Cost = 1;
            }
            else if (Wave == 21)
            {
                MonsterCategory = 16;
                Health = 90;
                Cost = 10;
                BossTime = true;
            }
        }
        #endregion
        #region Stage3
        if (Stage == 3)
        {
            Cost = 1f;
            if (Wave <= 5)
            {
                MonsterCategory = 6;
                Health = 45;
            }
            else if (Wave > 5 && Wave <= 10)
            {
                MonsterCategory = 7;
                Health = 60;
            }
            else if (Wave > 10 && Wave < 16)
            {
                MonsterCategory = 10;
                Health = 75;
            }
            else if (Wave > 15 && Wave < 21)
            {
                MonsterCategory = 11;
                Health = 90;
            }
            else if (Wave == 21)
            {
                MonsterCategory = 17;
                Health = 180;
                Cost = 20;
                BossTime = true;
            }
        }
        #endregion
        #region Stage4
        if (Stage == 4)
        {
            if (Wave < 5)
            {
                MonsterCategory = 8;
                Health = 90;
                Cost = 2f;
            }
            else if (Wave == 5)
            {
                MonsterCategory = 12;
                Health = 120;
                Cost = 5;
            }
            else if (Wave > 5 && Wave < 10)
            {
                MonsterCategory = 9;
                Health = 180;
                Cost = 2f;
            }
            else if (Wave == 10)
            {
                MonsterCategory = 13;
                Health = 210;
                Cost = 5;
            }
            else if (Wave > 10 && Wave < 16)
            {
                MonsterCategory = 15;
                Health = 230;
                Cost = 2;
            }
            else if (Wave > 15 && Wave <= 20)
            {
                MonsterCategory = 16;
                Health = 260;
                Cost = 2;
            }
            else if (Wave > 20 && Wave < 25)
            {
                MonsterCategory = 11;
                Health = 280;
                Cost = 2f;
            }
            else if (Wave == 25)
            {
                MonsterCategory = 14;
                Health = 310;
                Cost = 5;
            }
            else if (Wave == 26)
            {
                MonsterCategory = 18;
                Health = 610;
                Cost = 20;
                BossTime = true;
            }
        }
        #endregion
        #region Stage5
        if (Stage == 5)
        {
            Cost = 2;
            if (Wave <= 5)
            {
                MonsterCategory = 14;
                Health = 330;
            }
            else if (Wave > 5 && Wave <= 10)
            {
                MonsterCategory = 12;
                Health = 430;
            }
            else if (Wave > 10 && Wave < 16)
            {
                MonsterCategory = 13;
                Health = 530;
            }
            else if (Wave > 15 && Wave < 21)
            {
                MonsterCategory = 17;
                Health = 630;
            }
            else if (Wave == 21)
            {
                MonsterCategory = 19;
                Health = 1000;
                Cost = 5;
                BossTime = true;
                StageBoss = true;
            }
        }
        #endregion
    }
}
