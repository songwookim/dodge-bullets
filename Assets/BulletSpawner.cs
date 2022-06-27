using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;   // 생성할 탄알의 prefab을 할당해 줄 변수
    public float spawnRateMin = 0.5f; // 탄알 생성을 위한 Random range의 Min값
    public float spawnRateMax = 3.0f; // 탄알 생성을 위한 Random range의 Max값

    private Transform target; // 탄알이 향할 대상의 transform component 저장을 위한 변수
    private float spawnRate; // 탄알 생성주기
    private float timeAfterSpawn; // 탄알 생성 후 흐른 시간

    void Start()
    {
        timeAfterSpawn = 0f; // 탄알 생성 후 누적 시간을 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 탄알 생성 주기 랜덤으로 지정

        PlayerController playerController = FindObjectOfType<PlayerController>(); 
        target = playerController.transform;  // 탄알이 향할 대상을 찾아 transform component를 저장

    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        
        if(timeAfterSpawn >= spawnRate) // 탄알 생성 후 시간이 탄알 생성주기보다 커지면
        {
            timeAfterSpawn = 0f; // 누적시간 0으로 리셋

            //bullet frefab의 복제본을 정의된 transform.position과 transform.rotation을 가지고 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // 생성된 bullet Game Obj의 정면 방향이 target을 바라보도록 함
            bullet.transform.LookAt(target);

            // 다음 탄알 생성 주기 랜덤으로 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
