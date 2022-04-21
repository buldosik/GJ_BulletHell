using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletbuff : Powerup
{
    [SerializeField] private int amount = 1;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().playerWeapon.AddBulletCount(amount);
        Destroy(gameObject);
    }
}
