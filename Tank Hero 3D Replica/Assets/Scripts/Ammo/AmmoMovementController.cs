using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMovementController : MonoBehaviour
{
    [Header("Values")]
    public float MoveSpeed;
    public float LeftSideBarrelAngle, RightSideBarrelAngle;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrel"))
        {
            _rigidbody.velocity = Vector3.forward * MoveSpeed * Time.deltaTime;
        }
        else if (other.gameObject.CompareTag("LeftSideBarrel"))
        {
            float angle = LeftSideBarrelAngle * Mathf.Deg2Rad;

            float horizontalDirection = Mathf.Cos(angle);
            float verticalDirection = Mathf.Sin(angle);
            
            Vector3 movementDirection = new Vector3(horizontalDirection*-1, 0f, verticalDirection*-1).normalized;
            
            Vector3 movementAmount = movementDirection * MoveSpeed * Time.deltaTime;
            
            _rigidbody.velocity = movementAmount;
        }
        else if (other.gameObject.CompareTag("RightSideBarrel"))
        {
            float angle = RightSideBarrelAngle * Mathf.Deg2Rad;

            float horizontalDirection = Mathf.Cos(angle);
            float verticalDirection = Mathf.Sin(angle);
            
            Vector3 movementDirection = new Vector3(horizontalDirection, 0f, verticalDirection).normalized;
            
            Vector3 movementAmount = movementDirection * MoveSpeed * Time.deltaTime;
            
            _rigidbody.velocity = movementAmount;
        }
        
        
    }
}
