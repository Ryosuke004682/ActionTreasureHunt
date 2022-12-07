using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("�v���C���[�̃p�����[�^�[")]
    public float _eventSpeed = 1.5f;
    public float _speed      = 3.0f;
    public float _runSpeed   = 6.0f;

    [Header("Player�ɂ�����d�̓p�����[�^�[")]
    public float gravity         = 9.8f;
    public float groundDragPower = 5.0f; //���͂Ƃ���B

    public bool groundCheck      = true;


    public float rayDistance = 0.5f;

    private float _horizontal;
    private float _vertical;

    Rigidbody rb;
    Vector3 position;

    RaycastHit _hit;
    Ray _ray;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        InputMove();
    }

    private void FixedUpdate()
    {

        GetGravity_Cheack();
    }

    void InputMove()
    {

        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical   = Input.GetAxisRaw("Vertical");

        position = new (-_horizontal , 0 , -_vertical);

        var moveSpeed = position.normalized;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = moveSpeed * _runSpeed;
        }
        else
        {
            if (moveSpeed.magnitude <= _speed)
            {
                rb.velocity = moveSpeed * _speed;
            }
        }

    }

    void GetGravity_Cheack()
    {
        //�d�͐ݒ�
        //�n��ɂ���Ƃ��͏d�͂͊|���Ȃ��Ă������̂ŁA
        //else�̎���gravity���|����.

        var gravitySetting = Physics.gravity * position.y * gravity;

        //���C�̐ݒ�
        _ray = new Ray(transform.position ,Vector3.down);
        Debug.DrawRay(transform.position , Vector3.down * rayDistance , Color.red);

      

    }

}
