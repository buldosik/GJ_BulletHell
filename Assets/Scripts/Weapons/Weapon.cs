using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    public virtual void Shoot(Transform source, string tag)
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.tag = tag;
        newBullet.transform.position = source.transform.position;
        newBullet.transform.rotation = source.transform.rotation;
    }
    public virtual void Shoot(Transform source, Vector3 target, string tag)
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.tag = tag;
        newBullet.transform.position = source.transform.position;
        newBullet.transform.rotation = source.transform.rotation;
    }
}
