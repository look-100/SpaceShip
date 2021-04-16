using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleShip6 : BaseMiddleShip
{
    #region 旧脚本
    // public Transform shootPoint;
    // public float shootCD;

    // bool isMove = true;
    // bool isShoot = false;
    // int shootTimes = 0;
    // float lastShoot = 0;
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
    //         return;
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
    //             new Vector3(transform.localPosition.x, transform.localPosition.y - 3,
    //             transform.localPosition.z), Time.deltaTime * 4f);
    //         if (transform.position.y <= 5.0f)
    //         {
    //             isMove = false;
    //             isShoot = true;
    //         }
    //     }
    //     else
    //     {
    //         LightningSphereShoot();
    //     }
    // }
    #endregion

    //闪电球子弹
    public override void Shoot()
    {

        if (isShoot)
        {
            if (playerTrans != null)
            {
                FollowShoot(shootPoint1);
            }

            if (Time.time - lastShoot >= shootCD)
            {
                //EnemyBullet6
                GameObject go1 = MoreObjectPool.instance.GetGameObjectPool(bulletName);
                go1.transform.position = shootPoint1.position;
                go1.transform.up = shootPoint1.transform.up;

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

    // void MoveDown()
    // {
    //     transform.Translate(Vector3.down * Time.deltaTime * 3.5f);
    // }
}
