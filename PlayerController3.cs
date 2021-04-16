﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController3 : Player
{
    // [Header("player属性信息")]
    // public float moveSpeed;

    // public float mainShootCD;
    // float secondaryShootCD = 1.5f;

    // [Header("CD信息")]
    // private Image cdImage;

    // [Header("子弹信息")]
    // public GameObject bulletPfb;
    //public GameObject MissilePfb;
    //public GameObject barrierPfb;
    //public GameObject beamPfb;

    // [Header("子弹发射位置信息")]
    // public Transform shootPoint;
    // public Transform shootPoint_left;
    // public Transform shootPoint_right;

    [Header("瞬移技能信息")]
    public float barrierCD;
    public float lastBarrier = -15f;
    // [Space]
    // public Transform wingLeft;
    // public Transform wingRight;
    // public float wingsShootCD;
    // float wingsLastShoot = 0;
    // int bulletIndex = 0;
    // float mainLastTime = 0;
    // float secondaryLastTime = 0;

    // float missileTimer = 0;
    // Animator cameraAnim;
    // Animator playerAnim;

    //无敌闪烁参数
    // Material mat;
    // float flashLastTime;
    // public float invincibleTime;
    // public float flashDelta;
    // bool isInvincible = true;
    // bool isProtected = false;
    // Color originalColor;
    // Color alphaColor = new Color(1, 1, 1, 0);

    // float missileCD = 1.5f;

    // private enum BulletType
    // {
    //     bullet_L,
    //     bullet_S
    // }

    // BulletType bulletCurrentType = BulletType.bullet_L;
    // Barrier barrier;

    // void Start()
    // {
    //     Time.timeScale = 1;
    //     GlobalMgr.playerIsdead = false;
    //     GlobalMgr.bossIsDead = false;
    //     //InvokeRepeating("MissileShoot", 0, missileCD);
    //     //InvokeRepeating("WingsShoot", 0, 2);
    //     cameraAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    //     playerAnim = GetComponent<Animator>();
    //     mat = GetComponent<SpriteRenderer>().material;
    //     originalColor = mat.color;
    //     cdImage = GameObject.FindGameObjectWithTag("PlayerSkillCD").GetComponent<Image>();
    //     PlayerHealthBar.healthMax = hp;
    //     PlayerHealthBar.healthCurrent = hp;

    // }

    public override void Update()
    {
        base.Update();
        //Teleport();
        //Move();
        //LimitBorder();
        // if (bulletCurrentType == BulletType.bullet_L)
        // {
        //     LineShoot();
        // }
        // else if (bulletCurrentType == BulletType.bullet_S)
        // {
        //     ScatterShoot();
        // }
        // MainShoot();
        // SecondaryShoot();

        //护盾消失
        // if (GlobalMgr.barrierIsBreak)
        // {
        //     isProtected = false;
        // }
        // WingsShoot();
        cdImage.fillAmount -= 1.0f / barrierCD * Time.deltaTime;
    }


    #region 主武器与副武器
    //主武器为穿甲弹
    public override void MainShoot()
    {
        GameObject[] bulletGo = new GameObject[5];
        //子弹发射CD
        if (Time.time - mainLastTime >= mainShootCD)
        {
            for (int i = 0; i < 2; i++)
            {
                bulletGo[i] = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet3");
            }
            bulletGo[0].transform.position = new Vector3(shootPoint.position.x + 0.5f, shootPoint.position.y - 0.4f, 0);
            bulletGo[1].transform.position = new Vector3(shootPoint.position.x - 0.5f, shootPoint.position.y - 0.4f, 0);
            bulletGo[0].transform.rotation = shootPoint.rotation;
            bulletGo[1].transform.rotation = shootPoint.rotation;
            switch (bulletIndex)
            {
                case 0:
                    break;
                case 1:
                    for (int i = 2; i < 4; i++)
                    {
                        bulletGo[i] = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet3");
                    }
                    bulletGo[2].transform.position = new Vector3(shootPoint.position.x + 0.25f, shootPoint.position.y - 0.2f, 0);
                    bulletGo[3].transform.position = new Vector3(shootPoint.position.x - 0.25f, shootPoint.position.y - 0.2f, 0);
                    bulletGo[2].transform.rotation = shootPoint.rotation;
                    bulletGo[3].transform.rotation = shootPoint.rotation;
                    break;
                case 2:
                    for (int i = 2; i < 5; i++)
                    {
                        bulletGo[i] = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet3");
                    }
                    bulletGo[2].transform.position = new Vector3(shootPoint.position.x + 0.25f, shootPoint.position.y - 0.2f, 0);
                    bulletGo[3].transform.position = new Vector3(shootPoint.position.x - 0.25f, shootPoint.position.y - 0.2f, 0);
                    bulletGo[2].transform.rotation = shootPoint.rotation;
                    bulletGo[3].transform.rotation = shootPoint.rotation;
                    bulletGo[4].transform.position = new Vector3(shootPoint.position.x, shootPoint.position.y, 0);
                    bulletGo[4].transform.rotation = shootPoint.rotation;
                    break;
            }
            mainLastTime = Time.time;
        }
    }

    //副武器为六角散射球
    public override void SecondaryShoot()
    {
        if (Time.time - secondaryLastTime >= secondaryShootCD)
        {
            Vector3 fireDirection = shootPoint.transform.up;
            Quaternion leftQuaternion1 = Quaternion.AngleAxis(30, Vector3.forward);
            Quaternion leftQuaternion2 = Quaternion.AngleAxis(90, Vector3.forward);
            Quaternion leftQuaternion3 = Quaternion.AngleAxis(150, Vector3.forward);
            Quaternion rightQuaternion1 = Quaternion.AngleAxis(-30, Vector3.forward);
            Quaternion rightQuaternion2 = Quaternion.AngleAxis(-90, Vector3.forward);
            Quaternion rightQuaternion3 = Quaternion.AngleAxis(-150, Vector3.forward);
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        GameObject bulletGo0 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet4");
                        bulletGo0.transform.position = shootPoint.position;
                        fireDirection = leftQuaternion1 * fireDirection;
                        bulletGo0.transform.up = fireDirection;
                        fireDirection = transform.up;
                        break;
                    case 1:
                        GameObject bulletGo1 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet4");
                        bulletGo1.transform.position = shootPoint.position;
                        fireDirection = rightQuaternion1 * fireDirection;
                        bulletGo1.transform.up = fireDirection;
                        fireDirection = transform.up;
                        break;
                    case 2:
                        if (bulletIndex >= 1)
                        {
                            GameObject bulletGo2 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet4");
                            bulletGo2.transform.position = shootPoint.position;
                            fireDirection = leftQuaternion2 * fireDirection;
                            bulletGo2.transform.up = fireDirection;
                            fireDirection = transform.up;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 3:
                        if (bulletIndex >= 1)
                        {
                            GameObject bulletGo3 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet4");
                            bulletGo3.transform.position = shootPoint.position;
                            fireDirection = rightQuaternion2 * fireDirection;
                            bulletGo3.transform.up = fireDirection;
                            fireDirection = transform.up;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 4:
                        if (bulletIndex >= 2)
                        {
                            GameObject bulletGo4 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet4");
                            bulletGo4.transform.position = shootPoint.position;
                            fireDirection = leftQuaternion3 * fireDirection;
                            bulletGo4.transform.up = fireDirection;
                            fireDirection = transform.up;
                            break;
                        }
                        else { break; }
                    case 5:
                        if (bulletIndex >= 2)
                        {
                            GameObject bulletGo5 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet4");
                            bulletGo5.transform.position = shootPoint.position;
                            fireDirection = rightQuaternion3 * fireDirection;
                            bulletGo5.transform.up = fireDirection;
                            fireDirection = transform.up;
                            break;
                        }
                        else { break; }
                }
            }

            secondaryLastTime = Time.time;
        }
    }
    #endregion

    // void WingsShoot()
    // {
    //     if (Time.time - wingsLastShoot > wingsShootCD)
    //     {
    //         for (int i = 0; i < 2; i++)
    //         {
    //             switch (i)
    //             {
    //                 case 0:
    //                     GameObject wingL = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet8");
    //                     wingL.transform.position = wingLeft.position;
    //                     wingL.transform.rotation = wingLeft.rotation;
    //                     break;
    //                 case 1:
    //                     GameObject wingR = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet8");
    //                     wingR.transform.position = wingRight.position;
    //                     wingR.transform.rotation = wingRight.rotation;
    //                     break;
    //             }
    //         }
    //         wingsLastShoot = Time.time;
    //     }
    // }

    #region 技能
    //准备瞬移
    // void ReadyToTeleport()
    // {
    //     isTeleport = true;
    //     lastTeleport = Time.time;
    //     cdImage.fillAmount = 1;
    // }

    //护盾技能
    public override void Skill()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            //Debug.Log("按下k");
            if (Time.time >= (lastBarrier + barrierCD))
            {
                //Debug.Log("护盾");
                isProtected = true;
                cdImage.fillAmount = 1;
                GameObject _barrierGo = null;
                AudioManager.PlayBarrierAudio();
                //检查player是否存在护盾（护盾只存在一个）
                foreach (Transform child in transform)
                {
                    _barrierGo = GameObject.FindGameObjectWithTag("Barrier");
                }
                if (_barrierGo != null)
                {
                    _barrierGo.gameObject.GetComponent<Barrier>().hp = _barrierGo.gameObject.GetComponent<Barrier>().initHp;
                    return;
                }
                else
                {
                    //玩家获得护盾
                    GameObject barrierGo = MoreObjectPool.instance.GetGameObjectPool("Barrier");
                    barrierGo.transform.position = transform.position;
                    barrierGo.transform.rotation = Quaternion.identity;
                    barrierGo.transform.parent = gameObject.transform;
                }
                lastBarrier = Time.time;
            }
        }

        //     if (isTeleport)
        //     {
        //         switch (direction)
        //         {
        //             case 0:
        //                 transform.position = new Vector3(transform.position.x,
        //                     transform.position.y + 6, transform.position.z);
        //                 break;
        //             case 1:
        //                 transform.position = new Vector3(transform.position.x,
        //                     transform.position.y - 6, transform.position.z);
        //                 break;
        //             case 2:
        //                 transform.position = new Vector3(transform.position.x - 6,
        //                     transform.position.y, transform.position.z);
        //                 break;
        //             case 3:
        //                 transform.position = new Vector3(transform.position.x + 6,
        //                     transform.position.y, transform.position.z);
        //                 break;
        //         }

        //         isTeleport = false;
        //     }
    }
    #endregion

    #region 碰撞检测
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     switch (other.tag)
    //     {
    //         //触碰到陨石
    //         // case "Asiderite":
    //         // Destroy(gameObject);
    //         // Destroy(other.gameObject);
    //         // break;
    //         //触碰到敌人
    //         case "Enemy":
    //             //HpDecline(10f);
    //             if (isInvincible || isProtected)
    //                 return;
    //             HpDecline();
    //             cameraAnim.SetTrigger("isShake");
    //             break;
    //         case "EnemyBullet1":
    //             if (isInvincible || isProtected)
    //                 return;
    //             MoreObjectPool.instance.ReturnPool(other.gameObject);
    //             //Destroy(other.gameObject);
    //             //HpDecline(10f);
    //             HpDecline();
    //             cameraAnim.SetTrigger("isShake");
    //             break;
    //         //碰到激光
    //         case "EnemyBullet_laser":
    //             if (isInvincible || isProtected)
    //                 return;
    //             HpDecline();
    //             cameraAnim.SetTrigger("isShake");
    //             break;
    //         //碰到闪电球
    //         case "EnemyBullet_lightningSphere":
    //             if (isInvincible || isProtected)
    //                 return;
    //             HpDecline();
    //             cameraAnim.SetTrigger("isShake");
    //             break;

    //         //触碰到护盾道具
    //         case "Prop_Barrier":

    //             isProtected = true;

    //             GameObject barrierTextGo = MoreObjectPool.instance.GetGameObjectPool("GetBarrier");
    //             barrierTextGo.transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
    //             MoreObjectPool.instance.ReturnPool(other.gameObject);
    //             GameObject _barrierGo = null;

    //             //检查player是否存在护盾（护盾只存在一个）
    //             foreach (Transform child in transform)
    //             {
    //                 // if (child.tag == "Barrier")
    //                 // {
    //                 //     _barrierGo = child.gameObject;
    //                 // }
    //                 //Debug.Log(child.gameObject.name);
    //                 _barrierGo = GameObject.FindGameObjectWithTag("Barrier");
    //             }
    //             if (_barrierGo != null)
    //             {
    //                 _barrierGo.gameObject.GetComponent<Barrier>().hp = _barrierGo.gameObject.GetComponent<Barrier>().initHp;
    //                 //isProtected = true;
    //                 return;
    //             }
    //             else
    //             {
    //                 //玩家获得护盾
    //                 GameObject barrierGo = MoreObjectPool.instance.GetGameObjectPool("Barrier");
    //                 barrierGo.transform.position = transform.position;
    //                 barrierGo.transform.rotation = Quaternion.identity;
    //                 barrierGo.transform.parent = gameObject.transform;
    //             }

    //             break;
    //         //触碰到回血道具
    //         case "Prop_recovery":
    //             //Destroy(other.gameObject);
    //             GameObject recoverGo = MoreObjectPool.instance.GetGameObjectPool("RecoverLife");
    //             recoverGo.transform.position = transform.position;
    //             MoreObjectPool.instance.ReturnPool(other.gameObject);
    //             hp += 3;
    //             if (hp > 10)
    //             {
    //                 hp = 10;
    //             }
    //             PlayerHealthBar.healthCurrent = hp;
    //             break;
    //         //触碰到升级道具
    //         case "Prop_Up":
    //             //Instantiate(fireUp, transform.position, Quaternion.identity);
    //             GameObject fireGo = MoreObjectPool.instance.GetGameObjectPool("FireUp");
    //             fireGo.transform.position = transform.position;
    //             bulletIndex = Mathf.Clamp(++bulletIndex, 0, 2);
    //             //Debug.Log(bulletIndex);
    //             //Destroy(other.gameObject);
    //             MoreObjectPool.instance.ReturnPool(other.gameObject);

    //             switch (bulletIndex)
    //             {
    //                 case 0:
    //                     mainShootCD = 0.22f;
    //                     secondaryShootCD = 1.5f;
    //                     // missileCD = 1.5f;
    //                     break;
    //                 case 1:
    //                     mainShootCD = 0.2f;
    //                     secondaryShootCD = 1f;
    //                     // missileCD = 1f;
    //                     break;
    //                 case 2:
    //                     mainShootCD = 0.15f;
    //                     secondaryShootCD = 0.5f;
    //                     // missileCD = 0.5f;
    //                     break;
    //             }

    //             break;
    //             //直射子弹
    //             // case "Prop_L":
    //             //     MoreObjectPool.instance.ReturnPool(other.gameObject);
    //             //     //判断目前的子弹类型
    //             //     if (bulletCurrentType == BulletType.bullet_S)
    //             //     {
    //             //         bulletIndex = 0;
    //             //     }
    //             //     bulletCurrentType = BulletType.bullet_L;
    //             //     break;

    //             // //散射子弹
    //             // case "Prop_S":
    //             //     MoreObjectPool.instance.ReturnPool(other.gameObject);
    //             //     if (bulletCurrentType == BulletType.bullet_L)
    //             //     {
    //             //         bulletIndex = 0;
    //             //     }
    //             //     bulletCurrentType = BulletType.bullet_S;
    //             //     break;
    //     }
    // }
    #endregion

    #region  散射
    // void ScatterShoot()
    // {
    //     if (Time.time - timer > scatterShootCD)
    //     {
    //         Vector3 fireDirection = transform.up;
    //         Quaternion leftQuaternion1 = Quaternion.AngleAxis(10, Vector3.forward);
    //         Quaternion leftQuaternion2 = Quaternion.AngleAxis(20, Vector3.forward);
    //         Quaternion leftQuaternion3 = Quaternion.AngleAxis(30, Vector3.forward);
    //         Quaternion rightQuaternion1 = Quaternion.AngleAxis(-10, Vector3.forward);
    //         Quaternion rightQuaternion2 = Quaternion.AngleAxis(-20, Vector3.forward);
    //         Quaternion rightQuaternion3 = Quaternion.AngleAxis(-30, Vector3.forward);
    //         for (int i = 0; i < 7; i++)
    //         {
    //             // GameObject m1 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet2");
    //             // m1.transform.position = shootPoint.position;
    //             switch (i)
    //             {
    //                 case 0:
    //                     GameObject m0 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet3");
    //                     m0.transform.position = shootPoint.position;
    //                     fireDirection = transform.up;
    //                     m0.transform.up = fireDirection;
    //                     break;
    //                 case 1:
    //                     GameObject m1 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet3");
    //                     m1.transform.position = shootPoint.position;
    //                     fireDirection = leftQuaternion1 * fireDirection;
    //                     m1.transform.up = fireDirection;
    //                     fireDirection = transform.up;
    //                     break;

    //                 case 2:
    //                     GameObject m2 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet3");
    //                     m2.transform.position = shootPoint.position;
    //                     fireDirection = rightQuaternion1 * fireDirection;
    //                     m2.transform.up = fireDirection;
    //                     fireDirection = transform.up;
    //                     break;
    //                 case 3:
    //                     if (bulletIndex >= 1)
    //                     {
    //                         GameObject m3 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet2");
    //                         m3.transform.position = shootPoint.position;
    //                         fireDirection = leftQuaternion2 * fireDirection;
    //                         m3.transform.up = fireDirection;
    //                         fireDirection = transform.up;
    //                         break;
    //                     }
    //                     else
    //                     {
    //                         break;
    //                     }
    //                 case 4:
    //                     if (bulletIndex >= 1)
    //                     {
    //                         GameObject m4 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet2");
    //                         m4.transform.position = shootPoint.position;
    //                         fireDirection = rightQuaternion2 * fireDirection;
    //                         m4.transform.up = fireDirection;
    //                         fireDirection = transform.up;
    //                         break;
    //                     }
    //                     else
    //                     {
    //                         break;
    //                     }

    //                 case 5:
    //                     if (bulletIndex >= 2)
    //                     {
    //                         GameObject m5 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet3");
    //                         m5.transform.position = shootPoint.position;
    //                         fireDirection = leftQuaternion3 * fireDirection;
    //                         m5.transform.up = fireDirection;
    //                         fireDirection = transform.up;
    //                         break;
    //                     }
    //                     else
    //                     {
    //                         break;
    //                     }
    //                 case 6:
    //                     if (bulletIndex >= 2)
    //                     {
    //                         GameObject m6 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet3");
    //                         m6.transform.position = shootPoint.position;
    //                         fireDirection = rightQuaternion3 * fireDirection;
    //                         m6.transform.up = fireDirection;
    //                         fireDirection = transform.up;
    //                         break;
    //                     }
    //                     else
    //                     {
    //                         break;
    //                     }
    //             }
    //         }
    //         timer = Time.time;
    //     }
    // }
    #endregion


    //无敌状态
    // void InvincibleState()
    // {
    //     //处于无敌状态
    //     if (isInvincible)
    //     {
    //         invincibleTime -= Time.deltaTime;
    //         Invoke("Flash", 0);
    //         if (invincibleTime <= 0)
    //         {
    //             isInvincible = false;
    //             CancelInvoke("Flash");
    //             //mat.color = new Color(1, 1, 1, 1);
    //             mat.color = originalColor;
    //         }
    //     }
    // }

    // //闪烁状态
    // void Flash()
    // {
    //     if (Time.time - flashLastTime >= flashDelta)
    //     {
    //         //mat.color = new Color(1, 1, 1, 1);
    //         mat.color = originalColor;
    //         flashLastTime = Time.time;
    //     }
    //     else
    //     {
    //         //mat.color = new Color(1, 1, 1, 0);
    //         mat.color = alphaColor;
    //     }
    // }

    //Player的移动
    // void Move()
    // {
    //     if (Input.GetKey(KeyCode.W))
    //     {
    //         transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
    //     }
    //     if (Input.GetKey(KeyCode.A))
    //     {
    //         transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
    //     }
    //     if (Input.GetKey(KeyCode.S))
    //     {
    //         transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
    //     }
    //     if (Input.GetKey(KeyCode.D))
    //     {
    //         transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    //     }
    // }


    //导弹发射
    // void MissileShoot()
    // {
    //     if (shootPoint != null)
    //     {
    //         Vector3 fireDirection = shootPoint.transform.up;
    //         Quaternion leftQuaternion1 = Quaternion.AngleAxis(25, Vector3.forward);
    //         Quaternion rightQuaternion1 = Quaternion.AngleAxis(-25, Vector3.forward);
    //         Quaternion leftQuaternion2 = Quaternion.AngleAxis(90, Vector3.forward);
    //         Quaternion rightQuaternion2 = Quaternion.AngleAxis(-90, Vector3.forward);
    //         if (Time.time - missileTimer >= missileCD)
    //         {
    //             for (int i = 0; i < 4; i++)
    //             {
    //                 GameObject m1 = MoreObjectPool.instance.GetGameObjectPool("Missile1_1");
    //                 m1.transform.position = shootPoint.position;
    //                 switch (i)
    //                 {
    //                     case 0:
    //                         fireDirection = leftQuaternion1 * fireDirection;
    //                         m1.transform.up = fireDirection;
    //                         fireDirection = shootPoint.transform.up;
    //                         break;
    //                     case 1:
    //                         fireDirection = rightQuaternion1 * fireDirection;
    //                         m1.transform.up = fireDirection;
    //                         fireDirection = shootPoint.transform.up;
    //                         break;
    //                     case 2:
    //                         fireDirection = leftQuaternion2 * fireDirection;
    //                         m1.transform.up = fireDirection;
    //                         fireDirection = shootPoint.transform.up;
    //                         break;
    //                     case 3:
    //                         fireDirection = rightQuaternion2 * fireDirection;
    //                         m1.transform.up = fireDirection;
    //                         fireDirection = shootPoint.transform.up;
    //                         break;
    //                 }
    //             }
    //             missileTimer = Time.time;
    //         }
    //         // GameObject m1 = MoreObjectPool.instance.GetGameObjectPool("Missile1_1");
    //         // GameObject m2 = MoreObjectPool.instance.GetGameObjectPool("Missile1_2");
    //         // m1.transform.position = shootPoint.position;
    //         // m2.transform.position = shootPoint.position;
    //         // m1.transform.rotation = shootPoint.rotation;
    //         // m2.transform.rotation = shootPoint.rotation;
    //     }

    // }

    //僚机发射子弹
    // void WingsShoot()
    // {
    // if (shootPoint_left != null && shootPoint_right != null)
    // {
    //     Instantiate(beamPfb, shootPoint_left.position, Quaternion.identity);
    //     Instantiate(beamPfb, shootPoint_right.position, Quaternion.identity);
    // }
    // }

    //血量下降
    // public override void HpDecline()
    // {
    //     invincibleTime = 1f;
    //     isInvincible = true;
    //     InvincibleState();
    //     hp--;
    //     //将当前血量显示在血条上
    //     PlayerHealthBar.healthCurrent = hp;
    //     // PlayerHealthBar.healthCurrent = Mathf.MoveTowards(PlayerHealthBar.healthCurrent, hp, Time.deltaTime * 5);
    //     if (hp <= 0)
    //     {
    //         CancelInvoke();
    //         GetComponent<CircleCollider2D>().enabled = false;
    //         //销毁player下的所有子物体
    //         // for (int i = 0; i < transform.childCount; i++)
    //         // {
    //         //     transform.GetChild(i).gameObject.SetActive(false);
    //         // }

    //         playerAnim.SetTrigger("isBomb");
    //         GlobalMgr.playerIsdead = true;
    //         //MoreObjectPool.instance.ReturnPool(gameObject);
    //     }
    // }

    // public void PlayPlayerExpAudio()
    // {
    //     AudioManager.PlayPlayerExpAudio();
    // }

    // public override void Destroy()
    // {
    //     Destroy(gameObject);
    // }
}