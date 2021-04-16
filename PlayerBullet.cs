using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{

    Animator anim;
    bool isDie = false;
    void Start()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();
        //Destroy(gameObject, 3f);
        // if (gameObject.transform.parent != null)
        //     Destroy(gameObject.transform.parent.gameObject, 3f);
    }

    void Update()
    {
        if (isDie)
            return;
        Movement();
        base.ReturnPoolOverDistance();
    }

    private void OnEnable()
    {
        isDie = false;
    }

    public override void Movement()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            //打到陨石
            // case "Asiderite":
            // Destroy(gameObject);
            // Destroy(other.gameObject);
            // MoreObjectPool.instance.ReturnPool(gameObject);
            // MoreObjectPool.instance.ReturnPool(other.gameObject);
            // break;
            //打到敌人
            case "Enemy":
                // Destroy(GetComponent<CapsuleCollider2D>());
                GetComponent<Collider2D>().enabled = false;
                anim.SetTrigger("isBomb");
                isDie = true;
                break;
        }
    }

    // void ReturnPool()
    // {
    //     MoreObjectPool.instance.ReturnPool(gameObject);
    // }
    // void Destroy()
    // {
    //     Destroy(gameObject);
    // }

}
