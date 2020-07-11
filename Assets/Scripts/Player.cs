using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera m_camera;

    Animator m_animator;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 5f;
    Vector3 moveDirection;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveForward();
        Rotate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision detected.");
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(transform.forward, rotateSpeed * Time.deltaTime);
            m_animator.SetBool("IsSwimming", true);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(transform.forward, -rotateSpeed * Time.deltaTime);
            m_animator.SetBool("IsSwimming", true);
        }
    }

    private void MoveForward()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            m_animator.SetBool("IsSwimming", true);
        }

        if (Input.GetKeyUp(KeyCode.Space)|| Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_animator.SetBool("IsSwimming", false);
        }
    }

    void LateUpdate()
    {
        m_camera.transform.position = new Vector3(transform.position.x, transform.position.y, m_camera.transform.position.z);
    }
}
