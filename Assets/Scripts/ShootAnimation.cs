using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAnimation : MonoBehaviour
{
    BulletLaunch bulletLaunch;

    void Start()
    {
        bulletLaunch = GetComponentInParent<BulletLaunch>();
    }

    public void Shoot()
    {
        bulletLaunch.ShootBullet();
    }
}
