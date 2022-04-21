using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagebuff : Powerup
{
    [SerializeField] private int amount = 1;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().playerWeapon.bullet.GetComponent<StandartBullet>().AddDamage(amount);
        Destroy(gameObject);
    }
}
