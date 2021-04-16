using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleShip2 : BaseMiddleShip
{

    #region 旧脚本
    // public float shootCD;

    // private float lastShoot = -10f;

    // bool isMove = true;
    // bool isShoot = false;

    // int shootTimes = 0;

    // void Awake()
    // {
    //     initHp = hp;
    // }
    // public override void Start()
    // {
    //     base.Start();
    // }

    // void Update()
    // {
    //     if (hp <= 0)
    //     {
    //         return;
    //     }
    //     base.LimitBorder();
    //     Move();
    //     Recovery();
    // }


    // public override void OnEnable()
    // {
    //     hp = initHp;
    //     isMove = true;
    //     isShoot = false;
    // }

    // void Move()
    // {
    //     if (isMove)
    //     {
    //         transform.localPosition = Vector3.MoveTowards(transform.localPosition,
    //             new Vector3(transform.localPosition.x, transform.localPosition.y - 4,
    //             transform.localPosition.z), Time.deltaTime * 3);
    //         if (transform.position.y <= 5.0f)
    //         {
    //             isMove = false;
    //             isShoot = true;
    //         }
    //     }
    //     else
    //     {
    //         Shoot();
    //     }
    // }
    #endregion

    //射击
    public override void Shoot()
    {
        if (isShoot)
        {
            if (Time.time - lastShoot >= shootCD)
            {
                SectorBarrage();
                _shootTimes++;
                lastShoot = Time.time;
                if (_shootTimes == shootTimes)
                {
                    _shootTimes = 0;
                    isShoot = false;
                }
            }
        }
        else
        {
            MoveDown();
        }
    }

    //三点扇形弹幕
    void SectorBarrage()
    {
        Vector3 fireDirection = -shootPoint1.transform.up;
        Quaternion leftQuaternion = Quaternion.AngleAxis(15, Vector3.forward);
        Quaternion rightQuaternion = Quaternion.AngleAxis(-15, Vector3.forward);
        // for (int i = 0; i < 15; i++)
        // {
        if (Time.time - lastShoot >= shootCD)
        {
            for (int j = 0; j < 3; j++)
            {
                //EnemyBullet1
                GameObject temp = MoreObjectPool.instance.GetGameObjectPool(bulletName);
                temp.transform.position = shootPoint1.position;
                switch (j)
                {
                    case 0:
                        fireDirection = -shootPoint1.transform.up;
                        //temp.transform.rotation = Quaternion.Euler(fireDirection);
                        temp.transform.up = -fireDirection;
                        break;
                    case 1:
                        fireDirection = leftQuaternion * fireDirection;
                        //temp.transform.rotation = Quaternion.Euler(fireDirection);
                        temp.transform.up = -fireDirection;
                        fireDirection = -shootPoint1.transform.up;
                        break;
                    case 2:
                        fireDirection = rightQuaternion * fireDirection;
                        //temp.transform.rotation = Quaternion.Euler(fireDirection);
                        temp.transform.up = -fireDirection;
                        fireDirection = -shootPoint1.transform.up;
                        break;
                }
            }
            lastShoot = Time.time;
        }
        // }
    }

    // void MoveDown()
    // {
    //     transform.Translate(Vector3.down * Time.deltaTime * 3f);
    // }

    // IEnumerator Shoot()
    // {

    //     yield return new WaitForSeconds(0.5f);
    //     while (true)
    //     {
    //         for (int i = 0; i < 3; i++)
    //         {
    //             Instantiate(bulletPfb, shootPoint.position, transform.rotation);
    //             yield return new WaitForSeconds(0.3f);
    //         }
    //         yield return new WaitForSeconds(0.8f);
    //     }

    // }

}
