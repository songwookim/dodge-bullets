using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ���� Object�� ������Ʈ ����/���� 
    public Rigidbody playerRigidbody;
    public float speed = 50.0f;

    public void Die()
    {
       this.gameObject.SetActive(false);
    }

    // Start�� Update�� ����Ƽ�� ��ü�� �޽��� ���� �� Game Obj�� ���� �̸��� �޼ҵ带 ���� ������ ����Ǵ� �����
    // Update�� ����Ǳ����� ȣ��
    void Start()
    {
        // Q : Rigidbody ������Ʈ�� �巡��&��� ���� �Ҵ��ϴ� ��� ??
        // A : ���� Obejct���� Rigidbody ������Ʈ�� ã�� playerRigidbody�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // �� �����Ӹ��� ȣ��
    void Update()
    {
        // WASD�Է� ���� -> Player �����̱�
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

        // Q : ������ �ٷ� �ݿ� x, �ݺ��Ǵ� if�� �ذ�
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵��ӵ��� �Է°��� �̵� �ӷ��� ����� ���
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // ���� ���� �ӵ��� Vector3�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        // playerRigidbody�� velocity ����
        playerRigidbody.velocity = newVelocity;

    }


}
