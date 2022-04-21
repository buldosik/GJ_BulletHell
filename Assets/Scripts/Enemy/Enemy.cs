using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int healthPoints;
    private GameObject player => GameObject.FindWithTag("player");

    void Update()
    {
        CheckIsPlayerInVision();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "missile")
        {
            AddHP(-collision.gameObject.GetComponent<StandartBullet>().damage);
            Destroy(collision.gameObject);
        }
    }

    private void AddHP(int x)
    {
        healthPoints += x;
        if(healthPoints < 0)
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] private float visionRange;
    protected virtual void CheckIsPlayerInVision()
    {
        Vector3 direction = player.transform.position - transform.position;
        int layerMask = ~(1 << 8);
        RaycastHit hit;
        Physics.Raycast(transform.position, direction, out hit, visionRange, layerMask);
        Debug.DrawRay(transform.position, direction * visionRange, Color.yellow);
        if(hit.transform.tag == "player")
        {
            Rotation(player.transform);
            Shoot();
        }
    }
    protected virtual void Rotation(Transform target)
    {
        transform.LookAt(player.transform);
    }
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected Weapon weapon;
    [SerializeField] protected float shootDelay;
    protected bool isReloading = false;
    protected float temp = 0f;
    protected virtual void Shoot()
    {
        if(isShooting)
            return;
        temp -= Time.deltaTime;
        if(temp < 0)
        {
            weapon.Shoot(transform, "bullet");
            temp = shootDelay;
        }
    }
}
