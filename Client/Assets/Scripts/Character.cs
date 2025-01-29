using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5f;   // 이동 속도
    public float rotationSpeed = 10f;  // 회전 속도

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 이동 입력 (WASD 또는 화살표)
        float horizontal = Input.GetAxis("Horizontal");  // 좌우 입력
        float vertical = Input.GetAxis("Vertical");      // 상하 입력
        
        // 이동 방향 설정
        movement = new Vector3(horizontal, 0f, vertical).normalized;

        // 캐릭터 회전
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        // 물리 기반 이동
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
