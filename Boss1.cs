using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : BaseBoss
{
    #region 旧脚本
    // public float speed;
    // public float startWaitTime;
    // private float waitTime;

    // private Vector3 movePos;
    //public Transform leftDownPos;
    //public Transform rightUpPos;
    //public GameObject[] bulletPfb;
    // public Transform leftShootPoint;
    // public Transform rightShootPoint;

    //public GameObject bossHealthBar;


    // public override void Start()
    // {
    //     base.Start();
    //     waitTime = startWaitTime;
    //     movePos = new Vector3(0, 4.5f, 0);
    //     GameMgr.bossHealthBar.SetActive(true);
    //     BossHealthBar.healthMax = hp;
    //     BossHealthBar.healthCurrent = hp;
    // }

    // void Update()
    // {
    //     if (hp <= 0)
    //     {
    //         GlobalMgr.bossIsDead = true;
    //         return;
    //     }

    //     MoveToRandomPos();
    //     // Debug.Log(hp);
    //     BossHealthBar.healthCurrent = hp;
    // }
    #endregion
    private float timeDelta;
    public float CDTime;


    public override void MoveToRandomPos()
    {
        // if (isMove)
        // {
        transform.position = Vector2.MoveTowards(transform.position, movePos, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
                //Shoot();
                int randShoot = Random.Range(0, 2);
                switch (randShoot)
                {
                    case 0:
                        Shoot();
                        break;
                    case 1:
                        ScatterShoot();
                        break;
                }
            }
        }

    }

    void Shoot()
    {
        if (playerTrans != null)
        {
            FollowShoot(leftShootPoint1);
            FollowShoot(rightShootPoint1);
        }

        if (Time.time - timeDelta > CDTime)
        {
            GameObject leftBullet = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet1");
            GameObject rightBullet = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet1");
            leftBullet.transform.position = leftShootPoint1.position;
            leftBullet.transform.up = leftShootPoint1.transform.up;
            // leftBullet.transform.rotation = Quaternion.identity;

            rightBullet.transform.position = rightShootPoint1.position;
            rightBullet.transform.up = rightShootPoint1.transform.up;
            // rightBullet.transform.rotation = Quaternion.identity;
            timeDelta = Time.time;
        }
    }

    //扇形弹幕
    void ScatterShoot()
    {

        if (Time.time - timeDelta > CDTime)
        {
            Vector3 fireDirection = -transform.up;
            Quaternion leftQuaternion1 = Quaternion.AngleAxis(10, Vector3.forward);
            Quaternion leftQuaternion2 = Quaternion.AngleAxis(20, Vector3.forward);
            Quaternion rightQuaternion1 = Quaternion.AngleAxis(-10, Vector3.forward);
            Quaternion rightQuaternion2 = Quaternion.AngleAxis(-20, Vector3.forward);
            for (int i = 0; i < 4; i++)
            {
                GameObject bulletGo1 = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet2");
                GameObject bulletGo2 = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet2");
                bulletGo1.transform.position = leftShootPoint1.position;
                bulletGo2.transform.position = rightShootPoint1.position;
                switch (i)
                {
                    case 0:
                        fireDirection = leftQuaternion1 * fireDirection;
                        bulletGo1.transform.up = -fireDirection;
                        bulletGo2.transform.up = -fireDirection;
                        fireDirection = -transform.up;
                        break;
                    case 1:
                        fireDirection = leftQuaternion2 * fireDirection;
                        bulletGo1.transform.up = -fireDirection;
                        bulletGo2.transform.up = -fireDirection;
                        fireDirection = -transform.up;
                        break;
                    case 2:
                        fireDirection = rightQuaternion1 * fireDirection;
                        bulletGo1.transform.up = -fireDirection;
                        bulletGo2.transform.up = -fireDirection;
                        fireDirection = -transform.up;
                        break;
                    case 3:
                        fireDirection = rightQuaternion2 * fireDirection;
                        bulletGo1.transform.up = -fireDirection;
                        bulletGo2.transform.up = -fireDirection;
                        fireDirection = -transform.up;
                        break;
                }

            }
            timeDelta = Time.time;

        }
    }
}
