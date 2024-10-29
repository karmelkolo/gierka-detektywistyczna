using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    public Rigidbody2D _rb;
        
    void Start()
    {

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical");
        
        UnityEngine.Vector2 direction = new UnityEngine.Vector2 (horizontalInput, verticalInput);
        _rb.MovePosition(_rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
