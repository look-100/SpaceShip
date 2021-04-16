using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBoss : EnemyShips
{

    public float speed;
    public float startWaitTime;

    public Transform leftShootPoint1;
    public Transform rightShootPoint1;
    internal float waitTime;
    internal Vector3 movePos;
    public override void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movePos = new Vector3(0, 4.5f, 0);
        GameMgr.bossHealthBar.SetActive(true);
        BossHealthBar.healthMax = hp;
        BossHealthBar.healthCurrent = hp;
    }

    public void Update()
    {
        if (hp <= 0)
        {
            GlobalMgr.bossIsDead = true;
            return;
        }
        MoveToRandomPos();
        BossHealthBar.healthCurrent = hp;
    }

    public virtual void MoveToRandomPos()
    {

    }

    public Vector2 GetRandomPos()
    {
        Vector2 randomPos = new Vector2(Random.Range(-2.5f, 2.5f),
         Random.Range(1f, 6f));
        return randomPos;
    }

    void PlayBossExpAudio()
    {
        AudioManager.PlayEnemyExpAudio();
    }

    public override void Destroy()
    {
        GameMgr.bossHealthBar.SetActive(false);
        Destroy(gameObject);
    }

}
