using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsideriteController : EnemyShips
{

    public float speed;
    public float rotateSpeed;

    public override void Start()
    {
        base.Start();
        hp = 5;
        initHp = hp;
    }

    void Update()
    {
        if (hp <= 0)
        {
            return;
        }
        transform.Rotate(new Vector3(0, 0, rotateSpeed), Space.Self);
        transform.position = transform.position - new Vector3(0, Time.deltaTime * speed, 0);
        Recovery();
    }

    public override void OnEnable()
    {
        hp = initHp;
    }

}
