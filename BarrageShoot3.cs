using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageShoot3 : MonoBehaviour
{

    public Transform middleShootPoint;
    public Transform leftShootPoint2;
    public Transform rightShootPoint2;
    public Transform leftShootPoint3;
    public Transform rightShootPoint3;

    private List<GameObject> Bullets = new List<GameObject>();

    void Start()
    {
        StartCoroutine(MultipleCircleFire());
    }

    void Update()
    {
        if (GlobalMgr.bossIsDead)
        {
            StopAllCoroutines();
        }
    }

    //多重圆形弹幕
    IEnumerator MultipleCircleFire()
    {
        Vector3 fireDirection = -middleShootPoint.transform.up;
        Quaternion startQuaternion = Quaternion.AngleAxis(45, Vector3.forward);
        //Quaternion secondQuaternion = Quaternion.AngleAxis(20, Vector3.forward);
        for (int i = 0; i < 8; i++)
        {
            GameObject temp = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet1");
            temp.transform.position = middleShootPoint.transform.position;
            temp.transform.up = fireDirection;
            //temp.transform.rotation = Quaternion.Euler(fireDirection);
            fireDirection = startQuaternion * fireDirection;
            Bullets.Add(temp);
        }
        yield return new WaitForSeconds(0.7f);
        for (int i = 0; i < Bullets.Count; i++)
        {
            StartCoroutine(FireAround(3, Bullets[i].transform.position));
            // Vector3 secondDirection = Bullets[i].transform.up;
            // for (int j = 0; j < 18; j++)
            // {
            //     GameObject temp = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet2");
            //     temp.transform.position = Bullets[i].transform.position;
            //     temp.transform.up = secondDirection;
            //     //temp.transform.rotation = Quaternion.Euler(secondDirection);
            //     secondDirection = secondQuaternion * secondDirection;
            // }
        }
        yield return new WaitForSeconds(5f);
        Bullets.Clear();
        StartCoroutine(TurbineFire());
        StopCoroutine(MultipleCircleFire());
    }

    //涡轮弹幕
    IEnumerator TurbineFire()
    {
        Vector3 fireDirection = -middleShootPoint.transform.up;
        Quaternion thirdQuaternion = Quaternion.AngleAxis(20, Vector3.forward);
        Quaternion thirdquaternionTwo = Quaternion.AngleAxis(24, Vector3.forward);
        float radius = 0.4f;
        float distance = 0.2f;
        for (int i = 0; i < 18; i++)
        {
            Vector3 firePoint = middleShootPoint.transform.position + radius * fireDirection;

            for (int j = 0; j < 15; j++)
            {
                GameObject go = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet1");
                go.transform.position = firePoint;
                go.transform.up = -fireDirection;
                //go.transform.rotation = Quaternion.Euler(fireDirection);
                fireDirection = thirdquaternionTwo * fireDirection;
            }
            yield return new WaitForSeconds(0.05f);
            fireDirection = thirdQuaternion * fireDirection;
            radius += distance;
        }
        yield return null;
        yield return new WaitForSeconds(3f);
        StartCoroutine(ForthFire());
        StopCoroutine(TurbineFire());
    }


    //十字旋转
    IEnumerator ForthFire()
    {
        Vector3 fireDirectionL = -leftShootPoint2.transform.up;
        Vector3 fireDirectionR = -rightShootPoint2.transform.up;
        Quaternion startQuaternionL = Quaternion.AngleAxis(90, Vector3.forward);
        Quaternion startQuaternionR = Quaternion.AngleAxis(-90, Vector3.forward);
        Quaternion rotationL = Quaternion.AngleAxis(3, Vector3.forward);
        Quaternion rotationR = Quaternion.AngleAxis(-3, Vector3.forward);

        //Quaternion rotationL = Quaternion.AngleAxis(3, Vector3.forward);
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                //GameObject temp = BulletPool.instance.GetFromPool();
                GameObject tempL = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet3");
                tempL.transform.position = leftShootPoint2.transform.position;
                tempL.transform.up = -fireDirectionL;
                fireDirectionL = startQuaternionL * rotationL * fireDirectionL;

                GameObject tempR = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet3");
                tempR.transform.position = rightShootPoint2.transform.position;
                tempR.transform.up = -fireDirectionR;
                fireDirectionR = startQuaternionR * rotationR * fireDirectionR;
                // temp.transform.rotation = Quaternion.Euler(fireDirection); 
            }
            yield return new WaitForSeconds(0.08f);
        }
        yield return null;
        yield return new WaitForSeconds(5f);
        StartCoroutine(FifthFire());
        StopCoroutine(ForthFire());
    }

    //单点漩涡
    IEnumerator FifthFire()
    {
        Vector3 fireDirectionL = -leftShootPoint3.transform.up;
        //Quaternion startQuaternion = Quaternion.AngleAxis(0, Vector3.forward);
        Quaternion rotationL = Quaternion.AngleAxis(20, Vector3.forward);

        Vector3 fireDirectionR = -rightShootPoint3.transform.up;
        Quaternion rotationR = Quaternion.AngleAxis(-20, Vector3.forward);
        for (int i = 0; i < 50; i++)
        {
            //for (int j = 0; j < 1; j++)
            // {

            GameObject tempL = MoreObjectPool.instance.GetGameObjectPool("laser1");
            tempL.transform.position = leftShootPoint3.transform.position;
            tempL.transform.up = -fireDirectionL;
            fireDirectionL = rotationL * fireDirectionL;

            GameObject tempR = MoreObjectPool.instance.GetGameObjectPool("laser1");
            tempR.transform.position = rightShootPoint3.transform.position;
            tempR.transform.up = -fireDirectionR;
            fireDirectionR = rotationR * fireDirectionR;
            // }
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
        yield return new WaitForSeconds(3f);
        StartCoroutine(SixthFire());
        StopCoroutine(FifthFire());
    }

    //扇形旋转弹幕
    IEnumerator SixthFire()
    {
        Vector3 fireDirection = -middleShootPoint.transform.up;
        Quaternion rotation = Quaternion.AngleAxis(-8, Vector3.forward);
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject temp = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet2");
                temp.transform.position = middleShootPoint.transform.position;
                temp.transform.up = -fireDirection;
                // temp.transform.rotation = Quaternion.Euler(fireDirection);
                fireDirection = rotation * fireDirection;
            }
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine(MultipleCircleFire());
        StopCoroutine(SixthFire());

    }

    //圆形弹幕
    IEnumerator FireAround(int number, Vector3 creatPoint)
    {
        Vector3 bulletDir = middleShootPoint.transform.up;
        Quaternion rotateQuate = Quaternion.AngleAxis(20, Vector3.forward);
        for (int i = 0; i < number; i++)
        {
            for (int j = 0; j < 18; j++)
            {
                GameObject go = MoreObjectPool.instance.GetGameObjectPool("EnemyBullet3");
                go.transform.position = creatPoint;
                go.transform.up = bulletDir;
                bulletDir = rotateQuate * bulletDir;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

}
