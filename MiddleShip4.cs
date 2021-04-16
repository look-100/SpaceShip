using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleShip4 : BaseMiddleShip
{

    #region 旧脚本
    // public Transform shootPoint4;
    // public float shootCD;
    // public float stopPos;

    // private float lastShoot = -10f;

    // //Vector3 startPos;
    // bool isMove = true;
    // bool isShoot = false;

    // int shootTimes = 0;

    // void Awake()
    // {
    //     //hp = 20;
    //     initHp = hp;
    // }
    // public override void Start()
    // {

    //     base.Start();
    //     //startPos = transform.position;
    //     //playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    //     //StartCoroutine(MoveDown());
    //     //StartCoroutine(Shoot());
    //     // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    //     // if (player == null)
    //     //     return;
    // }

    // void Update()
    // {
    //     //shootPoint.Rotate(playerPos.position - transform.position);
    //     if (hp <= 0)
    //     {
    //         return;
    //     }
    //     if (playerTrans != null)
    //         FollowShoot(shootPoint4);
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
    //         if (transform.position.y <= stopPos)
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
        if (playerTrans != null)
            FollowShoot(shootPoint1);
        if (isShoot)
        {
            if (Time.time >= lastShoot + shootCD)
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

    //扇形弹幕
    void SectorBarrage()
    {
        Vector3 fireDirection = -shootPoint1.transform.up;
        Quaternion leftQuaternion1 = Quaternion.AngleAxis(15, Vector3.forward);
        Quaternion rightQuaternion1 = Quaternion.AngleAxis(-15, Vector3.forward);
        Quaternion leftQuaternion2 = Quaternion.AngleAxis(25, Vector3.forward);
        Quaternion rightQuaternion2 = Quaternion.AngleAxis(-25, Vector3.forward);
        // for (int i = 0; i < 15; i++)
        // {
        if (Time.time - lastShoot >= shootCD)
        {
            for (int j = 0; j < 5; j++)
            {
                //EnemyBullet2
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
                        fireDirection = leftQuaternion1 * fireDirection;
                        //temp.transform.rotation = Quaternion.Euler(fireDirection);
                        temp.transform.up = -fireDirection;
                        fireDirection = -shootPoint1.transform.up;
                        break;
                    case 2:
                        fireDirection = rightQuaternion1 * fireDirection;
                        //temp.transform.rotation = Quaternion.Euler(fireDirection);
                        temp.transform.up = -fireDirection;
                        fireDirection = -shootPoint1.transform.up;
                        break;
                    case 3:
                        fireDirection = leftQuaternion2 * fireDirection;
                        temp.transform.up = -fireDirection;
                        fireDirection = -shootPoint1.transform.up;
                        break;
                    case 4:
                        fireDirection = rightQuaternion2 * fireDirection;
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
    //     transform.Translate(Vector3.down * Time.deltaTime * 4f);
    // }


    // void FollowShoot()
    // {
    //     float angle = Mathf.Rad2Deg * Mathf.Atan((shootPoint4.position.y - player.position.y)
    //     / (shootPoint4.position.x - player.position.x));
    //     if (shootPoint4.position.x - player.position.x < 0)
    //         angle = angle + 90;
    //     else
    //         angle = angle - 90;
    //     shootPoint4.localEulerAngles = new Vector3(0, 0, angle);
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
