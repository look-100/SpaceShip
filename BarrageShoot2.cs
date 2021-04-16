using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageShoot2 : MonoBehaviour
{

    public Transform leftShootPoint1;
    public Transform rightShootPoint1;


    void Start()
    {

        StartCoroutine(LineShoot());
        Debug.Log("开启协程");
    }

    IEnumerator LineShoot()
    {
        leftShootPoint1.GetComponent<Animator>().SetBool("isRotate", true);
        rightShootPoint1.GetComponent<Animator>().SetBool("isRotate", true);
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 10; i++)
        {
            GameObject bulletGo1 = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet2");
            GameObject bulletGo2 = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet2");

            bulletGo1.transform.position = leftShootPoint1.position;
            bulletGo1.transform.up = leftShootPoint1.transform.up;

            bulletGo2.transform.position = rightShootPoint1.position;
            bulletGo2.transform.up = rightShootPoint1.transform.up;

            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(Fire());
        StopCoroutine(LineShoot());
    }

    //圆形弹幕
    IEnumerator Fire()
    {
        leftShootPoint1.GetComponent<Animator>().SetBool("isRotate", false);
        rightShootPoint1.GetComponent<Animator>().SetBool("isRotate", false);
        Vector3 fireDirection = this.transform.up;
        Quaternion startQuaternion = Quaternion.AngleAxis(36, Vector3.forward);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject temp1 = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet2");
                GameObject temp2 = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet2");

                temp1.transform.position = leftShootPoint1.position;
                temp2.transform.position = rightShootPoint1.position;

                temp1.transform.up = fireDirection;
                temp2.transform.up = fireDirection;

                // temp.transform.rotation = Quaternion.Euler(fireDirection);
                fireDirection = startQuaternion * fireDirection;
            }
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;

        yield return new WaitForSeconds(2f);
        StartCoroutine(LineShoot());
        StopCoroutine(Fire());
    }
}
