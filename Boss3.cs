using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : BaseBoss
{
    // public float speed;

    // public float startWaitTime;

    // 
    // private float waitTime;
    // private Vector3 movePos;

    public float lightningSphereCD;
    public Transform middleShootPoint;
    // public Transform leftShootPoint3;
    // public Transform rightShootPoint3;
    public float rotateSpeed;
    float lastTime;
    float lastTime1;

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
    //     BossHealthBar.healthCurrent = hp;
    // }

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
                GetComponent<BarrageShoot3>().enabled = true;
                LightningSphereShoot();
                //SunShoot();
            }
        }

    }

    //发射闪电球
    void LightningSphereShoot()
    {
        if (playerTrans != null)
        {
            FollowShoot(leftShootPoint1);
            FollowShoot(rightShootPoint1);
        }
        if (Time.time - lastTime1 >= lightningSphereCD)
        {
            GameObject bulletGoL = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet6");
            GameObject bulletGoR = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet6");

            bulletGoL.transform.position = leftShootPoint1.position;
            bulletGoR.transform.position = rightShootPoint1.position;

            bulletGoL.transform.up = leftShootPoint1.transform.up;
            bulletGoR.transform.up = rightShootPoint1.transform.up;

            lastTime1 = Time.time;
        }


    }

    void SunShoot()
    {
        middleShootPoint.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        Vector3 fireDirection = -middleShootPoint.transform.up;
        Quaternion left1 = Quaternion.AngleAxis(90, Vector3.forward);

        Quaternion right1 = Quaternion.AngleAxis(-90, Vector3.forward);
        // for (int i = 0; i < 5; i++)
        // {
        if (Time.time - lastTime >= 0.05f)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject bulletGo = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet3");
                bulletGo.transform.position = middleShootPoint.position;
                // bulletGo.transform.up = -shootPoint.transform.up;
                switch (j)
                {
                    case 0:
                        fireDirection = -middleShootPoint.transform.up;
                        bulletGo.transform.up = -fireDirection;
                        break;
                    case 1:
                        fireDirection = left1 * fireDirection;
                        bulletGo.transform.up = -fireDirection;
                        fireDirection = -middleShootPoint.transform.up;
                        break;
                    case 2:
                        fireDirection = right1 * fireDirection;
                        bulletGo.transform.up = -fireDirection;
                        fireDirection = -middleShootPoint.transform.up;
                        break;
                    case 3:
                        fireDirection = middleShootPoint.transform.up;
                        bulletGo.transform.up = -fireDirection;
                        fireDirection = -middleShootPoint.transform.up;
                        break;
                }
            }
            lastTime = Time.time;
        }
    }
}
