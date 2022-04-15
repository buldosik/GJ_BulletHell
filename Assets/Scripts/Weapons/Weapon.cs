using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private GameObject player => GameObject.FindWithTag("player");
    public virtual void Shoot(Vector3 target)
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = player.transform.position;
        newBullet.transform.rotation = player.transform.rotation;
    }
}
