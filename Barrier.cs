using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    public float flashDelta;
    float flashLastTime;
    Material mat;
    Color originalColor;
    Color alphaColor = new Color(1, 1, 1, 0.5f);

    public int hp;
    internal int initHp;
    //Animator anim;
    AnimationState animState;
    private void Awake()
    {
        initHp = hp;
        mat = GetComponent<SpriteRenderer>().material;
        originalColor = mat.color;
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log(hp);
        if (hp <= 3)
        {
            mat.color = alphaColor;
        }
        else
        {
            mat.color = originalColor;
        }

        if (hp <= 0)
        {
            // anim.SetBool("isBreak", true);
            // anim.SetBool("isFlash", false);
            //anim.Play("break");
            ReturnPool();
            GlobalMgr.barrierIsBreak = true;
            //Debug.Log("护盾血量恢复");
        }
        // else if (hp > 0 && hp <= 3)
        // {
        //     anim.SetBool("isFlash", true);
        //     // anim.Play("flash");
        //     // anim.SetBool("isBreak", false);
        // }
        // else if (hp > 3)
        // {
        //     anim.SetBool("isFlash", false);
        //     //Destroy(gameObject);
        // }
        // Debug.Log(initHp);
        // Debug.Log(hp);
    }

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

    private void OnEnable()
    {
        hp = initHp;
        mat.color = originalColor;
        // anim.SetBool("isFlash", false);
        // anim.SetBool("isBreak", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "EnemyBullet1":
                //BulletPool.instance.ReturnPool(other.gameObject);
                //MoreObjectPool.instance.ReturnPool(other.gameObject);

                if (other.GetComponent<Animator>() != null)
                {
                    other.GetComponent<Animator>().SetTrigger("isHit");
                    other.GetComponent<Collider2D>().enabled = false;
                    other.GetComponent<MinionBullet>().canMove = false;
                }
                else
                {
                    MoreObjectPool.instance.ReturnPool(other.gameObject);
                }

                hp--;
                break;
            case "EnemyBullet_laser":
                // MoreObjectPool.instance.ReturnPool(other.gameObject);
                if (other.GetComponent<Animator>() != null)
                {
                    other.GetComponent<Animator>().SetTrigger("isHit");
                    other.GetComponent<Collider2D>().enabled = false;
                    other.GetComponent<MinionBullet>().canMove = false;
                }
                else
                {
                    MoreObjectPool.instance.ReturnPool(other.gameObject);
                }
                hp--;
                break;
            case "EnemyBullet_lightningSphere":
                MoreObjectPool.instance.ReturnPool(other.gameObject);
                hp--;
                break;
                // case "Enemy":
                //     HpDecline();
                //     break;
        }
    }

    // void HpDecline()
    // {
    //     hp--;

    // }

    void ReturnPool()
    {

        MoreObjectPool.instance.ReturnPool(gameObject);
    }

}
