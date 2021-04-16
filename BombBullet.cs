using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{

    public float speed = 10f;
    int bulletNum;

    float bombTime = 0.7f;
    // float initTime;
    void Start()
    {
        // initTime = bombTime;
        //initPos = transform.position.y;
    }

    void Update()
    {
        Movement();
        // finalPos = transform.position.y;
        // if (finalPos - initPos >= 5f)
        // {
        //     Scatter();
        // }
        bombTime -= Time.deltaTime;
        if (bombTime <= 0)
        {
            Scatter();
        }

    }

    void OnEnable()
    {
        // bombTime = initTime;
        // initPos = transform.position.y;
        bombTime = 0.7f;
    }

    public void Movement()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void Scatter()
    {
        bulletNum = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().bulletIndex;
        MoreObjectPool.instance.ReturnPool(gameObject);
        Vector3 fireDirection = gameObject.transform.up;
        Quaternion left1 = Quaternion.AngleAxis(45, Vector3.forward);
        Quaternion right1 = Quaternion.AngleAxis(-45, Vector3.forward);
        Quaternion left2 = Quaternion.AngleAxis(135, Vector3.forward);
        Quaternion right2 = Quaternion.AngleAxis(-135, Vector3.forward);
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    GameObject m0 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet6_child");
                    m0.transform.position = gameObject.transform.position;
                    fireDirection = left1 * fireDirection;
                    m0.transform.up = fireDirection;
                    fireDirection = gameObject.transform.up;
                    break;
                case 1:
                    GameObject m1 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet6_child");
                    m1.transform.position = gameObject.transform.position;
                    fireDirection = right1 * fireDirection;
                    m1.transform.up = fireDirection;
                    fireDirection = gameObject.transform.up;
                    break;
                case 2:
                    if (bulletNum >= 2)
                    {
                        GameObject m2 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet6_child");
                        m2.transform.position = gameObject.transform.position;
                        fireDirection = left2 * fireDirection;
                        m2.transform.up = fireDirection;
                        fireDirection = gameObject.transform.up;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 3:
                    if (bulletNum >= 2)
                    {
                        GameObject m3 = MoreObjectPool.instance.GetGameObjectPool("PlayerBullet6_child");
                        m3.transform.position = gameObject.transform.position;
                        fireDirection = right2 * fireDirection;
                        m3.transform.up = fireDirection;
                        fireDirection = gameObject.transform.up;
                        break;
                    }
                    else
                    {
                        break;
                    }
            }
        }
    }
}