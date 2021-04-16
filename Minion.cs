using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : EnemyShips
{

    public float waitMin;
    public float waitMax;

    public float dodgeMinTime;
    public float dodgeMaxTime;
    public float xDodgeMin;
    public float xDodgeMax;

    //闪避加速度
    public float moveSpeed;

    private float dodgeTargetSpeed;
    // Rigidbody2D rgb;


    private float angle;
    // public Transform player = null;
    public Transform shootPoint;

    void Awake()
    {
        hp = 1;
        initHp = hp;
    }
    public override void Start()
    {
        base.Start();
        // rgb = GetComponent<Rigidbody2D>();


        StartCoroutine(Shoot());
        StartCoroutine(DodgeSpeed());
        // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // if (player == null)
        //     return;

    }

    private void FixedUpdate()
    {
        // if (GameObject.FindGameObjectWithTag("Player").transform != null)
        // {
        //     player = GameObject.FindGameObjectWithTag("Player").transform;
        // }
        // else
        // {
        //     return;
        // }

        if (hp <= 0)
        {
            // Destroy(rgb);
            StopAllCoroutines();
            return;
        }

        if (playerTrans != null)
            FollowShoot(shootPoint);
        // float dodgeVal = Mathf.MoveTowards(rgb.velocity.x, dodgeTargetSpeed, Time.deltaTime * acceleration);
        float dodgeValx = Mathf.MoveTowards(transform.position.x, dodgeTargetSpeed, Time.deltaTime * moveSpeed);
        float dodgeValy = Mathf.MoveTowards(transform.position.y, transform.position.y - 10, Time.deltaTime * 2f);
        //rgb.velocity = new Vector2(dodgeVal, 0);
        transform.position = new Vector2(dodgeValx, dodgeValy);
        base.LimitBorder();


        //Movement();
        Recovery();
    }

    public override void OnEnable()
    {
        // Rigidbody2D _rb = this.gameObject.AddComponent<Rigidbody2D>();
        // _rb.gravityScale = 0;
        hp = initHp;
        StartCoroutine(Shoot());
        StartCoroutine(DodgeSpeed());
    }

    // void Movement()
    // {
    //     transform.Translate(Vector3.down * Time.fixedDeltaTime * 2f);
    // }

    IEnumerator Shoot()
    {

        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                //Instantiate(bulletPfb, transform.position, Quaternion.identity);
                GameObject go = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet1");
                go.transform.position = shootPoint.transform.position;
                //go.transform.up = -shootPoint.transform.up;
                go.transform.localEulerAngles = shootPoint.localEulerAngles;
                yield return new WaitForSeconds(0.8f);
            }
            yield return new WaitForSeconds(1f);
        }

    }

    IEnumerator DodgeSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(waitMin, waitMax));
            dodgeTargetSpeed = Random.Range(xDodgeMin, xDodgeMax);
            //Debug.Log(dodgeTargetSpeed);
            if (transform.position.x > 0)
            {
                dodgeTargetSpeed = -dodgeTargetSpeed;
            }
            yield return new WaitForSeconds(Random.Range(dodgeMinTime, dodgeMaxTime));
            // dodgeTargetSpeed = 0;
        }
    }

    // void FollowShoot()
    // {
    //     angle = Mathf.Rad2Deg * Mathf.Atan((shootPoint.position.y - player.position.y)
    //     / (shootPoint.position.x - player.position.x));
    //     if (shootPoint.position.x - player.position.x < 0)
    //         angle = angle + 90;
    //     else
    //         angle = angle - 90;
    //     shootPoint.localEulerAngles = new Vector3(0, 0, angle);
    // }

}
