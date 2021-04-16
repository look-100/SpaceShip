using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBullet : Bullet
{

    internal bool canMove = true;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        if (canMove == false)
            return;
        Movement();
        //超出屏幕边界回收子弹
        base.ReturnPoolOverDistance();
    }

    void OnEnable()
    {
        canMove = true;
        if (GetComponent<Collider2D>() != null)
            GetComponent<Collider2D>().enabled = true;
    }

    public override void Movement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

}
