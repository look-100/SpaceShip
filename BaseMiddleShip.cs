using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMiddleShip : EnemyShips
{

    public string bulletName;
    public Transform shootPoint1;
    public float shootCD;
    public int shootTimes = 3;

    //默认为3
    public float moveDownSpeed;
    public float moveSpeed = 3f;
    [Tooltip("敌人出现后所停位置")]
    public float stopPos = 5f;

    internal bool isMove = true;
    internal bool isShoot = false;

    internal float lastShoot = 0;
    internal int _shootTimes;

    void Awake()
    {
        initHp = hp;
    }

    public override void Start()
    {
        base.Start();
    }

    internal void Update()
    {
        if (hp <= 0)
            return;
        base.LimitBorder();
        Move();
        Recovery();
    }

    public override void OnEnable()
    {
        hp = initHp;
        isMove = true;
        isShoot = false;
    }

    public void Move()
    {
        if (isMove)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                new Vector3(transform.localPosition.x, transform.localPosition.y - 3,
                transform.localPosition.z), Time.deltaTime * moveSpeed);
            if (transform.position.y <= stopPos)
            {
                isMove = false;
                isShoot = true;
            }
        }
        else
        {
            Shoot();
        }
    }

    public virtual void Shoot()
    {

    }

    public void MoveDown()
    {
        transform.Translate(Vector3.down * Time.deltaTime * moveDownSpeed);
    }

}
