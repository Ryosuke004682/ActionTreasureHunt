using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("プレイヤーのパラメーター")]
    public float _speed      = 3.0f;
    public float _runSpeed   = 6.0f;

    [Header("Playerにかかる重力パラメーター")]
    public float _gravity         = 9.8f;
    public float _groundDragPower = 5.0f; //引力とする。
    public bool _groundCheck      = true;
    public float _rayDistance     = 0.5f;

    [Header("カメラのパラメーター")]
    public float turnSmoothing = 10;
    public GameObject cameraAimPoint;

    private float _horizontal;
    private float _vertical;

    Rigidbody rb;
    Vector3 position;
    Vector3 rotation;

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
        PlayerRotate();
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
        //重力設定
        //地上にいるときは重力は掛けなくてもいいので、
        //elseの時にgravityを掛ける.

        var gravitySetting = Physics.gravity * position.y * _gravity;

        //レイの設定
        _ray = new Ray(transform.position ,Vector3.down);
        Debug.DrawRay(transform.position , Vector3.down * _rayDistance , Color.red);

        if(_hit.collider != null　&&　_hit.collider.CompareTag("Ground"))
        {
            Debug.Log("地面");
            rb.velocity *= 0;
        }
        else
        {
            Debug.Log("空中");
            rb.AddForce(gravitySetting * Time.deltaTime, ForceMode.Force); 
        }

    }
}
