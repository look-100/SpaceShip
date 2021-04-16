using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : Bullet
{
    // [Header("导弹的方向和位移控制")]
    //public float speed;
    //public float LRSpeed;
    //public Vector3 dir;
    //Vector3 startPos;
    // bool isShoot = false;
    bool isExp = false;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        // Destroy(gameObject, 3.0f);
        // Destroy(gameObject.transform.parent.gameObject, 3.0f);
        startPos = transform.position;
    }

    void Update()
    {
        if (isExp)
            return;
        //PrepareShoot();
        Movement();
        base.ReturnPoolOverDistance();
    }
    private void OnEnable()
    {
        isExp = false;
        //Debug.Log("isShoot为" + isShoot);
        //isShoot = false;
    }

    public override void Movement()
    {
        //transform.Translate(dir * Time.deltaTime * speed);
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            //打中陨石
            // case "Asiderite":
            //     Destroy(GetComponent<CapsuleCollider2D>());
            //     anim.SetTrigger("isBomb");
            //     Destroy(gameObject);
            //     Destroy(other.gameObject);
            //     Debug.Log("击中");
            //     break;
            //打到敌人
            case "Enemy":
                // Destroy(GetComponent<CapsuleCollider2D>());
                GetComponent<Collider2D>().enabled = false;
                isExp = true;
                anim.SetTrigger("isBomb");
                //Destroy(gameObject);
                //Debug.Log("击中敌人");
                break;
        }
    }



    // //准备发射导弹，移动两米后发射
    // void PrepareShoot()
    // {
    //     if (isShoot == false)
    //     {
    //         //transform.Translate(Vector2.left * Time.deltaTime * LRSpeed);
    //         transform.position = Vector3.MoveTowards(transform.position,
    //             new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z), Time.deltaTime * LRSpeed);

    //         if (Mathf.Abs(transform.position.x - startPos.x) >= 2.0f)
    //         //if(Vector2.Distance())
    //         {
    //             Debug.Log("距离为" + Mathf.Abs(transform.position.x - startPos.x));
    //             isShoot = true;
    //         }
    //     }
    //     else
    //     {
    //         Movement();
    //     }
    // }


    // void Destroy()
    // {
    //     Destroy(gameObject);
    // }

}
