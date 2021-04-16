using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

    public static BulletPool instance;
    public GameObject bulletPfb;
    public int bulletCount;
    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    private void Awake()
    {
        instance = this;
        FillPool();
    }

    //填充对象池
    public void FillPool()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            var newBullet = Instantiate(bulletPfb);
            newBullet.transform.SetParent(transform);

            ReturnPool(newBullet);
        }

    }

    //子弹返回对象池
    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        availableObjects.Enqueue(gameObject);
    }

    //从对象池获取子弹
    public GameObject GetFromPool()
    {
        if (availableObjects.Count == 0)
        {
            FillPool();
        }

        var outBullet = availableObjects.Dequeue();

        outBullet.SetActive(true);
        return outBullet;
    }

}