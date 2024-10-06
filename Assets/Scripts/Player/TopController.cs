using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    public float speed = 6f;
    private Camera MainCamera;
    private Vector3 MoveDirection = Vector3.zero;
    
    // Update is called once per frame

    private void Start()
    {
        MainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        GatherInput();
        Look();
    }

    void GatherInput()
    {
        MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if (MoveDirection != Vector3.zero)
        {
            var relative = (transform.position + MoveDirection) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = rot;
        }
       
    }

    void Move()
    {
        Vector3 frwd = this.transform.forward;
        controller.Move(frwd * speed * Time.deltaTime * MoveDirection.magnitude);
    }
}
