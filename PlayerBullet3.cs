using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet3 : Bullet
{

    bool isDie = false;
    void Start()
    {
        startPos = transform.position;
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
}
