using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleShip1 : BaseMiddleShip
{

    public Transform shootPoint2;
    #region 旧脚本
    // public Transform shootPoint2;
    // public float shootCD;

    // private float lastShoot = -10f;

    //Vector3 startPos;
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
    //             new Vector3(transform.localPosition.x, transform.localPosition.y - 3,
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
                //MiddleBullet1
                GameObject go1 = MoreObjectPool.instance.GetGameObjectPool(bulletName);
                go1.transform.position = shootPoint1.position;
                go1.transform.rotation = shootPoint1.rotation;
                if (shootPoint2 != null)
                {
                    GameObject go2 = MoreObjectPool.instance.GetGameObjectPool(bulletName);
                    go2.transform.position = shootPoint2.position;
                    go2.transform.rotation = shootPoint2.rotation;
                }
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

    #region 旧脚本
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
    #endregion


}
