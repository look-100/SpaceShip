using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public string[] enemyName;
    [Header("每生成一个敌人的间隔")]
    public float spawnWait;
    //每一波敌人的数量
    public int waveCount;
    [Header("每波敌人间的等待时间")]
    public float waveWait;
    //启动游戏后开始生成敌人的等待时间
    public float startWait;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < waveCount; i++)
            {
                int index = Random.Range(0, enemyName.Length);
                string goName = enemyName[index];
                Vector3 pos = new Vector3(Random.Range(-4.5f, 4.5f), transform.position.y, 0);
                Quaternion rot = Quaternion.identity;
                //Instantiate(go, pos, rot);
                GameObject _go = MoreObjectPool.instance.GetGameObjectPool(goName);
                _go.transform.position = pos;
                _go.transform.rotation = rot;
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
