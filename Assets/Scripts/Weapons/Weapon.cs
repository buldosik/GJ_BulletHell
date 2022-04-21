using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public GameObject bullet;
    private int bulletCount = 1;
    public virtual void Shoot(Transform source, string tag)
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.tag = tag;
        newBullet.transform.position = source.transform.position;
        newBullet.transform.rotation = source.transform.rotation;
    }
    public virtual void AddBulletCount(int x)
    {
        bulletCount += x;
    }
}
