using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBullet : MonoBehaviour
{
    private Rigidbody _rb => GetComponent<Rigidbody>();
    [SerializeField] private float bulletSpeed;
    public int damage;
    void Update()
    {
        _rb.velocity = transform.forward * bulletSpeed;
        if(Mathf.Abs(transform.position.x) > 15f || Mathf.Abs(transform.position.z) > 15f)
            Destroy(gameObject);
    }
}
