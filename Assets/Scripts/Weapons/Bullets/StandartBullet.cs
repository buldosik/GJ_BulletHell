using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBullet : MonoBehaviour
{
    protected Rigidbody _rb => GetComponent<Rigidbody>();
    [SerializeField] protected float bulletSpeed;
    public int damage;
    [SerializeField] protected float lifeTime = 5f;
    protected virtual void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0f)
            Destroy(gameObject);
        Movement();
    }
    protected virtual void Movement()
    {
        _rb.velocity = transform.forward * bulletSpeed;
    }
    public void AddDamage(int x)
    {
        damage += x;
    }
}
