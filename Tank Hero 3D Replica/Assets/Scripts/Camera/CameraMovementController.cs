using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    private Transform _target;
    
    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        _target=GameObject.FindGameObjectWithTag("Tank").transform;
        transform.position = Vector3.Lerp(transform.position, new Vector3(_target.position.x,
            _target.position.y+30F,
            _target.position.z-10), 0.4F);
    }
}
