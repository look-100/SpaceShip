using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropTips : MonoBehaviour
{


    public void Destroy()
    {
        //Destroy(gameObject);
        MoreObjectPool.instance.ReturnPool(gameObject.transform.parent.gameObject);
    }
}
