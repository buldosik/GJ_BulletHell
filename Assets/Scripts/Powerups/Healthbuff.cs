using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbuff : Powerup
{
    [SerializeField] private int amount = 5;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().AddHP(amount);
        Destroy(gameObject);
    }
}
