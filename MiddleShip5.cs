using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleShip5 : BaseMiddleShip
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
    //         CircleShoot();
    //     }
    // }
    #endregion

    //圆形弹幕
    public override void Shoot()
    {
        if (isShoot)
        {
            // if (playerTrans != null)
            // {
            //     FollowShoot(shootPoint);
            // }
            Vector3 fireDirection = this.transform.up;
            Quaternion startQuaternion = Quaternion.AngleAxis(10, Vector3.forward);
            if (Time.time - lastShoot >= shootCD)
            {
                for (int j = 0; j < 36; j++)
                {
                    //EnemyBullet3
                    GameObject go1 = MoreObjectPool.instance.GetGameObjectPool(bulletName);
                    go1.transform.position = shootPoint1.position;
                    go1.transform.up = fireDirection;
                    fireDirection = startQuaternion * fireDirection;
                }
                _shootTimes++;
                lastShoot = Time.time;
                if (_shootTimes == shootTimes)
                {
                    _shootTimes = 0;
                    isShoot = false;
                }
            }

            #region 旧脚本
            // if (Time.time >= lastShoot + shootCD)
            // {
            //     GameObject go1 = MoreObjectPool.instance.GetGameObjectPool("MiddleBullet1");
            //     go1.transform.position = shootPoint1.position;
            //     go1.transform.rotation = shootPoint1.rotation;
            //     //Instantiate(bulletPfb, shootPoint1.position, shootPoint1.rotation);
            //     if (shootPoint2 != null)
            //     {
            //         GameObject go2 = MoreObjectPool.instance.GetGameObjectPool("MiddleBullet1");
            //         go2.transform.position = shootPoint2.position;
            //         go2.transform.rotation = shootPoint2.rotation;
            //         //Instantiate(bulletPfb, shootPoint2.position, shootPoint2.rotation);
            //     }
            //     shootTimes++;
            //     lastShoot = Time.time;
            //     if (shootTimes == 3)
            //     {
            //         shootTimes = 0;
            //         isShoot = false;
            //     }

            // }
            #endregion

        }
        else
        {
            MoveDown();
        }
    }

    // void MoveDown()
    // {
    //     transform.Translate(Vector3.down * Time.deltaTime * 4f);
    // }

}
