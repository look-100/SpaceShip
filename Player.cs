using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [Header("玩家属性信息")]
    public float moveSpeed;
    public float mainShootCD;
    public float secondaryShootCD = 1.5f;
    // public float skillCD;
    public float invincibleTime;
    public float flashDelta;
    public Transform shootPoint;

    [Header("僚机属性信息")]
    public Transform wingLeft;
    public Transform wingRight;
    public float wingsShootCD;
    public string bulletName;
    internal float wingsLastShoot = 0;

    internal int bulletIndex = 0;
    internal float mainLastTime = 0;
    internal float secondaryLastTime = 0;
    internal float flashLastTime;

    Animator cameraAnim;
    Animator playerAnim;

    Material mat;
    Color originalColor;
    Color alphaColor = new Color(1, 1, 1, 0);

    Barrier barrier;

    bool isInvincible = true;
    internal bool isProtected = false;

    // [Header("CD信息")]
    internal Image cdImage;

    public void Start()
    {
        Time.timeScale = 1;
        initHp = hp;
        GlobalMgr.playerIsdead = false;
        GlobalMgr.bossIsDead = false;
        //InvokeRepeating("WingsShoot", 0, 2);
        cameraAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        playerAnim = GetComponent<Animator>();
        mat = GetComponent<SpriteRenderer>().material;
        originalColor = mat.color;
        cdImage = GameObject.FindGameObjectWithTag("PlayerSkillCD").GetComponent<Image>();
        PlayerHealthBar.healthMax = hp;
        PlayerHealthBar.healthCurrent = hp;
    }

    public virtual void Update()
    {
        hp = Mathf.Clamp(hp, 0, initHp);
        //Debug.Log(hp);
        if (hp <= 0)
            return;
        InvincibleState();
        Skill();
        Move();
        LimitBorder();
        MainShoot();
        SecondaryShoot();
        WingsShoot();

        switch (bulletIndex)
        {
            case 0:
                mainShootCD = 0.22f;
                secondaryShootCD = 1.5f;
                wingsShootCD = 1.8f;
                break;
            case 1:
                mainShootCD = 0.2f;
                secondaryShootCD = 1f;
                wingsShootCD = 1.2f;
                break;
            case 2:
                mainShootCD = 0.15f;
                secondaryShootCD = 0.5f;
                wingsShootCD = 0.6f;
                break;
        }
        bulletIndex = Mathf.Clamp(bulletIndex, 0, 2);
        //Debug.Log(bulletIndex);

        //护盾消失
        if (GlobalMgr.barrierIsBreak)
        {
            isProtected = false;
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Enemy":
                if (isInvincible || isProtected)
                    return;
                HpDecline();
                cameraAnim.SetTrigger("isShake");
                break;
            case "EnemyBullet1":
                if (isInvincible || isProtected)
                    return;
                MoreObjectPool.instance.ReturnPool(other.gameObject);
                HpDecline();
                cameraAnim.SetTrigger("isShake");
                break;
            //碰到激光
            case "EnemyBullet_laser":
                if (isInvincible || isProtected)
                    return;
                HpDecline();
                cameraAnim.SetTrigger("isShake");
                break;
            //碰到闪电球
            case "EnemyBullet_lightningSphere":
                if (isInvincible || isProtected)
                    return;
                HpDecline();
                cameraAnim.SetTrigger("isShake");
                break;

            //触碰到护盾道具
            case "Prop_Barrier":
                AudioManager.PlayBarrierAudio();
                isProtected = true;

                GameObject barrierTextGo = MoreObjectPool.instance.GetGameObjectPool("GetBarrier");
                barrierTextGo.transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
                MoreObjectPool.instance.ReturnPool(other.gameObject);
                GameObject _barrierGo = null;

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
                break;
            //触碰到回血道具
            case "Prop_recovery":
                AudioManager.PlayRecoveryAudio();
                GameObject recoverGo = MoreObjectPool.instance.GetGameObjectPool("RecoverLife");
                recoverGo.transform.position = transform.position;
                MoreObjectPool.instance.ReturnPool(other.gameObject);
                hp += 3;
                PlayerHealthBar.healthCurrent = hp;
                break;
            //触碰到升级道具
            case "Prop_Up":
                AudioManager.PlayUpGradeAudio();
                GameObject fireGo = MoreObjectPool.instance.GetGameObjectPool("FireUp");
                fireGo.transform.position = transform.position;
                bulletIndex++;
                MoreObjectPool.instance.ReturnPool(other.gameObject);
                break;
            case "Prop_upFull":
                AudioManager.PlayUpFullAudio();
                GameObject upFullGo = MoreObjectPool.instance.GetGameObjectPool("UpFull");
                upFullGo.transform.position = transform.position;
                MoreObjectPool.instance.ReturnPool(other.gameObject);
                bulletIndex = 2;
                break;
        }

    }

    public virtual void MainShoot()
    {

    }
    public virtual void SecondaryShoot()
    {

    }
    public virtual void WingsShoot()
    {
        if (Time.time - wingsLastShoot > wingsShootCD)
        {
            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        GameObject wingL = MoreObjectPool.instance.GetGameObjectPool(bulletName);
                        wingL.transform.position = wingLeft.position;
                        wingL.transform.rotation = wingLeft.rotation;
                        break;
                    case 1:
                        GameObject wingR = MoreObjectPool.instance.GetGameObjectPool(bulletName);
                        wingR.transform.position = wingRight.position;
                        wingR.transform.rotation = wingRight.rotation;
                        break;
                }
            }
            wingsLastShoot = Time.time;
        }
    }
    public virtual void Skill()
    {

    }

    public override void HpDecline()
    {
        //玩家受伤时暂时处于无敌状态
        invincibleTime = 1f;
        isInvincible = true;
        InvincibleState();

        bulletIndex--;
        hp--;
        //将当前血量显示在血条上
        PlayerHealthBar.healthCurrent = hp;
        if (hp <= 0)
        {
            CancelInvoke();
            GetComponent<CircleCollider2D>().enabled = false;
            playerAnim.SetTrigger("isBomb");
            GlobalMgr.playerIsdead = true;
        }
    }

    void InvincibleState()
    {
        //处于无敌状态
        if (isInvincible)
        {
            invincibleTime -= Time.deltaTime;
            Invoke("Flash", 0);
            if (invincibleTime <= 0)
            {
                isInvincible = false;
                CancelInvoke("Flash");
                //mat.color = new Color(1, 1, 1, 1);
                mat.color = originalColor;
            }
        }
    }

    //闪烁状态
    void Flash()
    {
        if (Time.time - flashLastTime >= flashDelta)
        {
            //mat.color = new Color(1, 1, 1, 1);
            mat.color = originalColor;
            flashLastTime = Time.time;
        }
        else
        {
            //mat.color = new Color(1, 1, 1, 0);
            mat.color = alphaColor;
        }
    }

    public void PlayPlayerExpAudio()
    {
        AudioManager.PlayPlayerExpAudio();
    }

    public override void Destroy()
    {
        Destroy(gameObject);
    }

}