using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{
    public Rigidbody _rb;
    public bool isUseCameraDirection;    // �J�����̌����ɍ��킹�Ĉړ����������ꍇ��true
    public float moveSpeed;              // �ړ����x
    public float moveForceMultiplier;    // �ړ����x�̓��͂ɑ΂���Ǐ]�x
    public GameObject mainCamera;
    float _horizontalInput;
    float _verticalInput;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        if (mainCamera == null)
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 moveVector = Vector3.zero;    // �ړ����x�̓���

        if (isUseCameraDirection)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;
            cameraForward.y = 0.0f;    // ���������Ɉړ����������ꍇ��y����������0�ɂ���
            cameraRight.y = 0.0f;

            moveVector = moveSpeed * (cameraRight.normalized * _horizontalInput + cameraForward.normalized * _verticalInput);
        }
        else
        {
            moveVector.x = moveSpeed * _horizontalInput;
            moveVector.z = moveSpeed * _verticalInput;
        }

        _rb.AddForce(moveForceMultiplier * (moveVector - _rb.velocity));
    }
}

