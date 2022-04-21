using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb => GetComponent<Rigidbody>();
    [SerializeField] private Camera cam;
    [SerializeField] private bool enabledMovement;
    [SerializeField] private bool enabledRotation;
    [SerializeField] private bool enabledDash;
    [SerializeField] private bool enabledShooting;
    [SerializeField] private Weapon playerWeapon;
    [SerializeField] private Transform weaponSource;
    private void Update()
    {
        if(enabledMovement)
            Movement(); 

        Vector3 _direction = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, _direction * 5, Color.yellow);

        int layerMask = 1 << 6;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray, out hit, 1000, layerMask)) {
            Vector3 target = hit.point;
            target = new Vector3(target.x, transform.position.y, target.z);
            if(enabledRotation && hit.transform.tag == "floor")
                Rotate(target);
            if(enabledShooting && Input.GetButtonDown("Fire1"))
                playerWeapon.Shoot(weaponSource, "missile");
            if(enabledDash && Input.GetButtonDown("Jump"))
                Dash();
        }
    }

    private float _forcePower = 30f;
    [SerializeField] private float _maxMovementSpeed;
    private void Movement()
    {
        float movementVertical = Input.GetAxis("Vertical");
        float movementHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(movementHorizontal, 0, movementVertical);
        
        //movement = movement.normalized;
        
        if(movementVertical == 0 && movementHorizontal == 0)
            return;


        _rb.AddForce(movement * _forcePower);
        if(_rb.velocity.magnitude > _maxMovementSpeed)
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxMovementSpeed);
    }

    private void Rotate(Vector3 target)
    {
        
        if(target == new Vector3(0f, 0.25f, 0f))
            return;
        transform.LookAt(target, Vector3.up);
    }

    [SerializeField] private float dashDistance;
    private void Dash()
    {
        float movementVertical = Input.GetAxis("Vertical");
        float movementHorizontal = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(movementHorizontal, 0, movementVertical);
        
        //movement = movement.normalized;
        
        if(movementVertical == 0 && movementHorizontal == 0)
            return;

        transform.position += Vector3.ClampMagnitude(direction * dashDistance, dashDistance);
    }
    
}
