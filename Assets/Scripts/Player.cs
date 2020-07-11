using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Camera m_camera;

    Animator m_animator;
    Rigidbody2D m_rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 5f;

    int _knowledge = 0;
    float _mood = 5f;
    float _fullMood = 10f;
    [SerializeField] TextMeshProUGUI knowledgeText;
    [SerializeField] Slider moodSlider;


    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
        knowledgeText.text = knowledgeText.text + _knowledge.ToString();
        moodSlider.value = (float)_mood / (float)_fullMood;
    }

    void Update()
    {
        MoveForward();
        Rotate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DiscoveryEvent discoveryEvent = collision.gameObject.GetComponent<DiscoveryEvent>();

        if (collision.gameObject.CompareTag("Knowledge"))
        {
            if (!discoveryEvent.GetHasOpened())
            {
                discoveryEvent.SetHasOpened(true);
                discoveryEvent.ActivateThePanel();
                _knowledge++;
                knowledgeText.text = "Knowledge: " + _knowledge.ToString();
            }
        }
        if (collision.gameObject.CompareTag("Mood"))
        {
            if (!discoveryEvent.GetHasOpened())
            {
                discoveryEvent.SetHasOpened(true);
                discoveryEvent.ActivateThePanel();
                _mood += 0.5f;
                moodSlider.value = _mood / _fullMood;
            }
        }
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
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // it shakes
            m_rb.AddForce(transform.right * -moveSpeed);
            //m_rb.velocity = transform.right * -moveSpeed; // it does not have the feeling of zero gravity
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
