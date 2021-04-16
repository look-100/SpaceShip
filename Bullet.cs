using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{

    public float speed;
    [HideInInspector] public Vector3 startPos;
    public abstract void Movement();

    public virtual void ReturnPoolOverDistance()
    {
        Vector3 finalPos = transform.position;
        if ((finalPos - startPos).magnitude >= 20)
        {
            MoreObjectPool.instance.ReturnPool(gameObject);
        }
    }
    void ReturnPoolAfterDied()
    {
        MoreObjectPool.instance.ReturnPool(gameObject);
    }

}
