using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleShip7 : BaseMiddleShip
{

    public override void Shoot()
    {

        if (isShoot)
        {
            if (playerTrans != null)
            {
                FollowShoot(shootPoint1);
            }

            if (Time.time - lastShoot >= shootCD)
            {
                GameObject go1 = MoreObjectPool.instance.GetGameObjectPool(bulletName);
                go1.transform.position = shootPoint1.position;
                go1.transform.up = shootPoint1.transform.up;

                _shootTimes++;
                lastShoot = Time.time;
                if (_shootTimes == shootTimes)
                {
                    _shootTimes = 0;
                    isShoot = false;
                }
            }

        }
        else
        {
            MoveDown();
        }
    }
}
