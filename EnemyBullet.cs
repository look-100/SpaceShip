using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    public Vector3 angle;


    void Start()
    {
        startPos = transform.position;
        //Destroy(gameObject, 3f);
        Destroy(gameObject.transform.parent.gameObject, 3f);
    }


    void Update()
    {
        Movement();
        base.ReturnPoolOverDistance();

    }

    public override void Movement()
    {
        transform.Translate(angle * speed * Time.deltaTime);
    }


}
