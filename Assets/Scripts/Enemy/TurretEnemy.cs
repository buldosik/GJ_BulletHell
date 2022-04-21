using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Enemy
{
    [SerializeField] private GameObject tower;
    protected override void Rotation(Transform target)
    {
        tower.transform.LookAt(target);
    }
    protected override void Shoot()
    {
        if(!isShooting)
            return;
        temp -= Time.deltaTime;
        if(temp < 0)
        {
            weapon.Shoot(tower.transform, "bullet");
            temp = shootDelay;
        }
    }
}
