using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{

    public float speed;
    public float radius = 2;
    public float attractSpeed = 8;
    // bool isAttract = false;
    void Update()
    {
        Move();
        if (transform.position.y <= -9.5f)
        {
            MoreObjectPool.instance.ReturnPool(gameObject);
            //Debug.Log("回收道具");
        }
        TestObjectInArea();
    }

    void TestObjectInArea()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Player"));
        if (collider != null)
        {
            // isAttract = true;
            transform.position = Vector2.MoveTowards(transform.position, collider.transform.position, Time.deltaTime * attractSpeed);
        }
    }
    void Move()
    {
        // if (isAttract)
        //     return;
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
    // private void OnEnable()
    // {
    //     isAttract = false;
    // }
}
