using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 게임 Object의 컴포넌트 제어/변경 
    public Rigidbody playerRigidbody;
    public float speed = 50.0f;

    public void Die()
    {
       this.gameObject.SetActive(false);
    }

    // Start와 Update는 유니티가 전체로 메시지 보낼 때 Game Obj가 같은 이름의 메소드를 갖고 있으면 실행되는 방식임
    // Update가 실행되기전에 호출
    void Start()
    {
        // Q : Rigidbody 컴포넌트를 드래그&드롭 말고 할당하는 방법 ??
        // A : 게임 Obejct에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // 매 프레임마다 호출
    void Update()
    {
        // WASD입력 감지 -> Player 움직이기
        /*
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
        */

        // Q : 조작이 바로 반영 x, 반복되는 if문 해결
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동속도를 입력값과 이동 속력을 사용해 계산
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // 새로 계산된 속도를 Vector3로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        // playerRigidbody의 velocity 변경
        playerRigidbody.velocity = newVelocity;

    }


}
