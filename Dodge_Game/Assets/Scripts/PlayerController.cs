using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;   // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; // 이동 속력

    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //if(Input.GetKey(KeyCode.UpArrow) == true)
        //{
        //    playerRigidbody.AddForce(0f, 0f, speed);
        //}

        //if(Input.GetKey(KeyCode.DownArrow) == true)
        //{
        //    playerRigidbody.AddForce(0f, 0f, -speed);
        //}

        //if(Input.GetKey(KeyCode.RightArrow) == true)
        //{
        //    playerRigidbody.AddForce(speed, 0f, 0f);
        //}

        //if(Input.GetKey(KeyCode.LeftArrow) == true)
        //{
        //    playerRigidbody.AddForce(-speed, 0f, 0f);
        //}

        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);  // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        playerRigidbody.velocity = newVelocity; // 리지드바디의 속도에 newVelocity할당

    }

    public void Die()
    {
        gameObject.SetActive(false);    // 자신의 게임 오브젝트를 비활설화

        GameManager gameManager = FindObjectOfType<GameManager>();  // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        gameManager.EndGame();  // 가져온 GameManager 오브젝트의 EndGame() 메서드 실행
    }
}
