using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    public float hp;
    internal float initHp;

    //x -4.6   y  -7.3
    public Boundary bound;
    public abstract void HpDecline();

    public virtual void Destroy()
    {
        MoreObjectPool.instance.ReturnPool(gameObject);
    }
    public virtual void LimitBorder()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bound.xMin, bound.xMax),
             Mathf.Clamp(transform.position.y, bound.yMin, bound.yMax), transform.position.z);
    }

}
