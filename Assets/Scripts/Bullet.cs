using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // 탄알 이동 속력
    private Rigidbody bulletRigidbody; // Rigidbody 컴포넌트를 할당하여 사용할 변수


    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>(); // GameObj에서 Rigidbody 컴포넌트 찾아 할당
        bulletRigidbody.velocity = transform.forward * speed;  // Rigidbody 속도 = 앞 방향 벡터 * 스피드

        Destroy(gameObject, 3.0f); // 3초 뒤 자신의 GameObject 파괴
    }

    private void OnTriggerEnter(Collider other)
    {   
        // 충돌한 Game Obj의 Tag가 Player 인지 ?
        if ( other.tag == "Player" )
        {
            // 상대방 Game Obj에서 PlayerControllerNew 스크립트 (<< 컴포넌트) 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null)
            {
                // 가져온 컴포넌트에 구현된 Die메서드 실행
                playerController.Die();
            }

        }

    }
}
