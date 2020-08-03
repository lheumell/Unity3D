using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movespeed = 15 ; 
    private Vector3 moveDirection ;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized ;
    }
    
    private void FixedUpdate() {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * movespeed * Time.fixedDeltaTime ) ;
    }
}
