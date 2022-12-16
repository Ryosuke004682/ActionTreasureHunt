using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("プレイヤーのパラメーター")]
    public float _speed      = 3.0f;
    public float _runSpeed   = 6.0f;

    const float _fallSpeed = 1.0f;


    [Header("Playerにかかる重力パラメーター")]
    public float _groundDragPower = 5.0f; //引力とする。
    public bool _groundCheck      = true;
    public float _rayDistance     = 0.5f;

    const float _gravity = -9.8f;

    [Header("カメラのパラメーター")]
    public float turnSmoothing = 10;
    public GameObject cameraAimPoint;



    Rigidbody rb;
    Animator _anim;

    Vector3 position;
    Vector3 rotation;

    RaycastHit _hit;
    Ray _ray;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update()
    {
        InputMove();
        PlayerRotate();
    }

    private void FixedUpdate()
    {
        GetGravity_Cheack();
    }
    void InputMove()
    {
        _anim.SetBool("Walk",false);
        _anim.SetBool("Run", false);


        var _horizontal = Input.GetAxisRaw("Horizontal");
        var _vertical   = Input.GetAxisRaw("Vertical");
        
        position    = new (-_horizontal , 0 , -_vertical);

        var moveSpeed = position.normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = moveSpeed * _runSpeed;

            _anim.SetBool("Walk", false);
            _anim.SetBool("Run", true);
        }
        else
        {
            if (moveSpeed.magnitude <= _speed)
            {
                rb.velocity = moveSpeed * _speed;

                _anim.SetBool("Walk", true);
                _anim.SetBool("Run", false);
            }
        }
    }

    void PlayerRotate()
    {
        if (cameraAimPoint != null)
        {
            Vector3 targetRotation = new(rotation.x, 0, rotation.z);

            if (targetRotation.magnitude > 0.1f)
            {
            Quaternion lookRotation = Quaternion.LookRotation(targetRotation);
            transform.rotation = Quaternion.Lerp(lookRotation , transform.rotation, turnSmoothing);
            }
        }
    }


    void GetGravity_Cheack()
    {
       //ジャンプの処理

        Vector3 acceleration = new Vector3(0 ,(_fallSpeed * _gravity) * 2 , 0);

        var gravitySetting = Physics.gravity.y * acceleration;

        //レイの設定
        _ray = new Ray(transform.position ,Vector3.down);
        Debug.DrawRay(transform.position , Vector3.down * _rayDistance , Color.red);

        //接地判定
        if(Physics.Raycast(_ray, out _hit, _rayDistance))
        {
            if (_hit.collider.CompareTag("Ground"))
            {
                Debug.Log("地面");
                rb.AddForce(gravitySetting * 0);
            }
        }
        else
        {
            Debug.Log("空中");
            rb.AddForce(-gravitySetting / 1.5f ,ForceMode.Acceleration);
           
        }
    }
}
