using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : BaseBoss
{

    // public float speed;
    // public float startWaitTime;
    // private float waitTime;
    // private Vector3 movePos;

    // public Transform leftShootPoint1;
    // public Transform rightShootPoint1;

    public Transform leftShootPoint2;
    public Transform rightShootPoint2;
    public Transform middleShootPoint;
    public float laserCDTime;
    public float vortexCDTime;
    public float lineCDTime;

    float rotateSpeed;
    private float timeDelta1;
    private float timeDelta2;
    private float timeDelta3;

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
                GetComponent<BarrageShoot2>().enabled = true;
                LaserShoot();
                VortexShoot();
            }
        }

    }

    void LineShoot()
    {
        if (Time.time - timeDelta3 > lineCDTime)
        {
            GameObject bulletGo1 = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet1");
            GameObject bulletGo2 = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet1");

            bulletGo1.transform.position = leftShootPoint1.transform.position;
            bulletGo2.transform.position = rightShootPoint1.transform.position;

            timeDelta3 = Time.time;
        }
    }

    //激光跟随目标
    void LaserShoot()
    {
        if (playerTrans != null)
        {
            FollowShoot(leftShootPoint2);
            FollowShoot(rightShootPoint2);
        }
        if (Time.time - timeDelta1 > laserCDTime)
        {
            GameObject leftBullet2 = MoreObjectPool.instance.GetGameObjectPool("laser1");
            GameObject rightBullet2 = MoreObjectPool.instance.GetGameObjectPool("laser1");
            leftBullet2.transform.position = leftShootPoint2.position;
            leftBullet2.transform.up = leftShootPoint2.transform.up;

            rightBullet2.transform.position = rightShootPoint2.position;
            rightBullet2.transform.up = rightShootPoint2.transform.up;

            timeDelta1 = Time.time;
        }

    }

    //漩涡式弹幕
    void VortexShoot()
    {
        rotateSpeed = Random.Range(400, 700);
        middleShootPoint.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
        if (Time.time - timeDelta2 >= vortexCDTime)
        {
            GameObject bulletGo = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet3");
            bulletGo.transform.position = middleShootPoint.position;
            bulletGo.transform.up = -middleShootPoint.transform.up;
            timeDelta2 = Time.time;
        }

    }


}
