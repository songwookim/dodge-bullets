using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;   // ������ ź���� prefab�� �Ҵ��� �� ����
    public float spawnRateMin = 0.5f; // ź�� ������ ���� Random range�� Min��
    public float spawnRateMax = 3.0f; // ź�� ������ ���� Random range�� Max��

    private Transform target; // ź���� ���� ����� transform component ������ ���� ����
    private float spawnRate; // ź�� �����ֱ�
    private float timeAfterSpawn; // ź�� ���� �� �帥 �ð�

    void Start()
    {
        timeAfterSpawn = 0f; // ź�� ���� �� ���� �ð��� 0���� �ʱ�ȭ
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // ź�� ���� �ֱ� �������� ����

        PlayerController playerController = FindObjectOfType<PlayerController>(); 
        target = playerController.transform;  // ź���� ���� ����� ã�� transform component�� ����

    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        
        if(timeAfterSpawn >= spawnRate) // ź�� ���� �� �ð��� ź�� �����ֱ⺸�� Ŀ����
        {
            timeAfterSpawn = 0f; // �����ð� 0���� ����

            //bullet frefab�� �������� ���ǵ� transform.position�� transform.rotation�� ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // ������ bullet Game Obj�� ���� ������ target�� �ٶ󺸵��� ��
            bullet.transform.LookAt(target);

            // ���� ź�� ���� �ֱ� �������� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
