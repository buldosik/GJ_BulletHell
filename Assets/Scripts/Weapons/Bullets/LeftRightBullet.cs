using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightBullet : StandartBullet
{
    
    [SerializeField] private float radius;
    [SerializeField] private float offsetSpeed;
    private float _temp = 0f;
    public float staringDirection = 1; // 1 - right //-1 - left
    protected override void Movement()
    {
        //base.Movement();
        Vector3 offset = new Vector3(transform.forward.z , transform.forward.y, -transform.forward.x);
        if(_temp > radius && staringDirection != -1)
            staringDirection = -1;
        else if (_temp < radius * -1f && staringDirection != 1)
            staringDirection = 1;
        _temp += offsetSpeed * Time.deltaTime * staringDirection;
        _rb.velocity = transform.forward * bulletSpeed + offset * _temp;
    }
}
