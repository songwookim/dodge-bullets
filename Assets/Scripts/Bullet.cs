using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody; // Rigidbody ������Ʈ�� �Ҵ��Ͽ� ����� ����


    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>(); // GameObj���� Rigidbody ������Ʈ ã�� �Ҵ�
        bulletRigidbody.velocity = transform.forward * speed;  // Rigidbody �ӵ� = �� ���� ���� * ���ǵ�

        Destroy(gameObject, 3.0f); // 3�� �� �ڽ��� GameObject �ı�
    }

    private void OnTriggerEnter(Collider other)
    {   
        // �浹�� Game Obj�� Tag�� Player ���� ?
        if ( other.tag == "Player" )
        {
            // ���� Game Obj���� PlayerControllerNew ��ũ��Ʈ (<< ������Ʈ) ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null)
            {
                // ������ ������Ʈ�� ������ Die�޼��� ����
                playerController.Die();
            }

        }

    }
}
