using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : Player
{
    // [Header("player属性信息")]
    // public float moveSpeed;

    // public float mainShootCD;
    // public float secondaryShootCD = 1.5f;

    // // [Header("CD信息")]
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

    [Header("技能信息")]
    public float recoveryCD = 20f;
    float lastRecovery = -30f;

    // [Space]
    // public Transform wingLeft;
    // public Transform wingRight;
    // public float wingsShootCD;
    // float wingsLastShoot = 0;

    // int bulletIndex = 0;
    // float mainLastTime = 0;
    // float secondaryLastTime = 0;
    // // float missileTimer = 0;
    // float skillVal;
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
        // if (hp <= 0)
        //     return;
        // InvincibleState();
        // Teleport();
        // Move();
        // LimitBorder();
        // MissileShoot();
        // if (bulletCurrentType == BulletType.bullet_L)
        // {
        //     LineShoot();
        // }
        // else if (bulletCurrentType == BulletType.bullet_S)
        // {
        //     ScatterShoot();
        // }
        // LineShoot();
        // MainShoot();
        // SecondaryShoot();

        //护盾消失
        // if (GlobalMgr.barrierIsBreak)
        // {
        //     isProtected = false;
        // }

        cdImage.fillAmount -= 1.0f / recoveryCD * Time.deltaTime;
    }

    //散射
    public override void MainShoot()
    {
        if (Time.time - mainLastTime > mainShootCD)
        {
            Vector3 fireDirection = transform.up;
            Quaternion leftQuaternion1 = Quaternion.AngleAxis(10, Vector3.forward);
            Quaternion leftQuaternion2 = Quaternion.AngleAxis(20, Vector3.forward);
            Quaternion leftQuaternion3 = Quaternion.AngleAxis(30, Vector3.forward);
            Quaternion rightQuaternion1 = Quaternion.AngleAxis(-10, Vector3.forward);
            Quaternion rightQuaternion2 = Quaternion.AngleAxis(-20, Vector3.forward);
            Quaternion rightQuaternion3 = Quaternion.AngleAxis(-30, Vector3.forward);
            for (int i = 0; i < 7; i++)
            {
                switch (i)
                {
                    case 0:
                        GameObject m0 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet2");
                        m0.transform.position = shootPoint.position;
                        fireDirection = transform.up;
                        m0.transform.up = fireDirection;
                        break;
                    case 1:
                        GameObject m1 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet2");
                        m1.transform.position = shootPoint.position;
                        fireDirection = leftQuaternion1 * fireDirection;
                        m1.transform.up = fireDirection;
                        fireDirection = transform.up;
                        break;

                    case 2:
                        GameObject m2 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet2");
                        m2.transform.position = shootPoint.position;
                        fireDirection = rightQuaternion1 * fireDirection;
                        m2.transform.up = fireDirection;
                        fireDirection = transform.up;
                        break;
                    case 3:
                        if (bulletIndex >= 1)
                        {
                            GameObject m3 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet2");
                            m3.transform.position = shootPoint.position;
                            fireDirection = leftQuaternion2 * fireDirection;
                            m3.transform.up = fireDirection;
                            fireDirection = transform.up;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 4:
                        if (bulletIndex >= 1)
                        {
                            GameObject m4 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet2");
                            m4.transform.position = shootPoint.position;
                            fireDirection = rightQuaternion2 * fireDirection;
                            m4.transform.up = fireDirection;
                            fireDirection = transform.up;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 5:
                        if (bulletIndex >= 2)
                        {
                            GameObject m5 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet2");
                            m5.transform.position = shootPoint.position;
                            fireDirection = leftQuaternion3 * fireDirection;
                            m5.transform.up = fireDirection;
                            fireDirection = transform.up;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 6:
                        if (bulletIndex >= 2)
                        {
                            GameObject m6 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet2");
                            m6.transform.position = shootPoint.position;
                            fireDirection = rightQuaternion3 * fireDirection;
                            m6.transform.up = fireDirection;
                            fireDirection = transform.up;
                            break;
                        }
                        else
                        {
                            break;
                        }
                }
            }
            mainLastTime = Time.time;
        }
    }

    //熔浆炮直射
    public override void SecondaryShoot()
    {
        // List<GameObject> bullets = null;
        if (Time.time - secondaryLastTime >= secondaryShootCD)
        {
            GameObject bulletParent = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet6_parent");

            bulletParent.transform.position = shootPoint.position;
            bulletParent.transform.rotation = Quaternion.identity;
            // bullets.Add(bulletParent);
            // GameObject bulletChild = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet6_child");
            // GameObject bulletGo2 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet7");

            // bulletGo1.transform.position = new Vector3(shootPoint.position.x + 0.45f, shootPoint.position.y, 0);
            // bulletGo1.transform.rotation = Quaternion.identity;

            // bulletGo2.transform.position = new Vector3(shootPoint.position.x - 0.45f, shootPoint.position.y, 0);
            // bulletGo2.transform.rotation = Quaternion.identity;

            secondaryLastTime = Time.time;
        }

    }

    // void WingsShoot()
    // {
    //     if (Time.time - wingsLastShoot > wingsShootCD)
    //     {
    //         for (int i = 0; i < 2; i++)
    //         {
    //             switch (i)
    //             {
    //                 case 0:
    //                     GameObject wingL = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet9");
    //                     wingL.transform.position = wingLeft.position;
    //                     wingL.transform.rotation = wingLeft.rotation;
    //                     break;
    //                 case 1:
    //                     GameObject wingR = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet9");
    //                     wingR.transform.position = wingRight.position;
    //                     wingR.transform.rotation = wingRight.rotation;
    //                     break;
    //             }
    //         }
    //         wingsLastShoot = Time.time;
    //     }

    // }


    // void ReadyToTeleport()
    // {
    //     isTeleport = true;
    //     lastRecovery = Time.time;
    //     cdImage.fillAmount = 1;
    // }

    //恢复技能
    public override void Skill()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Debug.Log("按下k");
            if (Time.time >= (lastRecovery + recoveryCD))
            {
                //Debug.Log("恢复");
                hp += 3;
                AudioManager.PlayRecoveryAudio();
                PlayerHealthBar.healthCurrent = hp;
                cdImage.fillAmount = 1;
                lastRecovery = Time.time;
            }
        }
        // Debug.Log("调用技能方法");
        // if (Time.time - lastRecovery >= recoveryCD)
        // {
        //     if (Input.GetKeyDown(KeyCode.K))
        //     {
        //         hp += 3;
        //         cdImage.fillAmount = 1;
        //     }
        //     lastRecovery = Time.time;
        // }
        // if (isTeleport)
        // {
        //     switch (direction)
        //     {
        //         case 0:
        //             transform.position = new Vector3(transform.position.x,
        //                 transform.position.y + 6, transform.position.z);
        //             break;
        //         case 1:
        //             transform.position = new Vector3(transform.position.x,
        //                 transform.position.y - 6, transform.position.z);
        //             break;
        //         case 2:
        //             transform.position = new Vector3(transform.position.x - 6,
        //                 transform.position.y, transform.position.z);
        //             break;
        //         case 3:
        //             transform.position = new Vector3(transform.position.x + 6,
        //                 transform.position.y, transform.position.z);
        //             break;
        //     }

        //     isTeleport = false;
        // }
    }

    //直射
    // void LineShoot()
    // {
    //     GameObject[] bulletGo = new GameObject[6];
    //     //子弹发射CD
    //     if (Time.time - timer > nextFireTime)
    //     {
    //         for (int i = 0; i < 2; i++)
    //         {
    //             //bulletGo[i] = Instantiate(bulletPfb);
    //             bulletGo[i] = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet1");
    //         }
    //         // bulletGo[0] = Instantiate(bulletPfb);
    //         // bulletGo[1] = Instantiate(bulletPfb);
    //         bulletGo[0].transform.position = new Vector3(shootPoint.position.x + 0.15f, shootPoint.position.y, 0);
    //         bulletGo[1].transform.position = new Vector3(shootPoint.position.x - 0.15f, shootPoint.position.y, 0);
    //         bulletGo[0].transform.rotation = shootPoint.rotation;
    //         bulletGo[1].transform.rotation = shootPoint.rotation;
    //         //Instantiate(bulletPfb1[bulletIndex], shootPoint.position, Quaternion.identity);
    //         switch (bulletIndex)
    //         {
    //             case 0:
    //                 nextFireTime = 0.2f;
    //                 // GameObject bulletGo1 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet1_1");
    //                 // bulletGo1.transform.position = shootPoint.position;
    //                 // bulletGo1.transform.rotation = Quaternion.identity;
    //                 break;
    //             case 1:
    //                 nextFireTime = 0.2f;
    //                 for (int i = 2; i < 4; i++)
    //                 {
    //                     bulletGo[i] = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet1");
    //                 }
    //                 bulletGo[2].transform.position = new Vector3(shootPoint.position.x + 0.45f, shootPoint.position.y - 0.25f, 0);
    //                 bulletGo[3].transform.position = new Vector3(shootPoint.position.x - 0.45f, shootPoint.position.y - 0.25f, 0);
    //                 bulletGo[2].transform.rotation = shootPoint.rotation;
    //                 bulletGo[3].transform.rotation = shootPoint.rotation;
    //                 // GameObject bulletGo2 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet1_2");
    //                 // bulletGo2.transform.position = shootPoint.position;
    //                 // bulletGo2.transform.rotation = Quaternion.identity;
    //                 break;
    //             case 2:
    //                 nextFireTime = 0.15f;
    //                 for (int i = 2; i < 6; i++)
    //                 {
    //                     bulletGo[i] = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet1");
    //                 }
    //                 bulletGo[2].transform.position = new Vector3(shootPoint.position.x + 0.45f, shootPoint.position.y - 0.25f, 0);
    //                 bulletGo[3].transform.position = new Vector3(shootPoint.position.x - 0.45f, shootPoint.position.y - 0.25f, 0);
    //                 bulletGo[2].transform.rotation = shootPoint.rotation;
    //                 bulletGo[3].transform.rotation = shootPoint.rotation;
    //                 bulletGo[4].transform.position = new Vector3(shootPoint.position.x + 0.75f, shootPoint.position.y - 0.5f, 0);
    //                 bulletGo[5].transform.position = new Vector3(shootPoint.position.x - 0.75f, shootPoint.position.y - 0.5f, 0);
    //                 bulletGo[4].transform.rotation = shootPoint.rotation;
    //                 bulletGo[5].transform.rotation = shootPoint.rotation;
    //                 // GameObject bulletGo3 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet1_3");
    //                 // bulletGo3.transform.position = shootPoint.position;
    //                 // bulletGo3.transform.rotation = Quaternion.identity;
    //                 break;
    //         }
    //         timer = Time.time;
    //     }
    // }

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

    //闪烁状态
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

    //准备瞬移



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
