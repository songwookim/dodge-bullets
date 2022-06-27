using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관련 라이브러리
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 플레이어 사망 시 활성화할 텍스트 게임 Obj

    public Text timeText;  // 생존시간 표시 텍스트 컴포넌트
    public Text recordText; // 최고기록 표시 텍스트 컴포넌트

    private float surviveTime; // 생존시간
    private bool isGameover; // 게임오버 bool 상태


    void Start()
    {
        // 생존시간과 게임오버상태 초기화
        surviveTime = 0;
        isGameover = false;

    }

    void Update()
    {
        if(!isGameover) {
            // 생존시간 업데이트
            surviveTime += Time.deltaTime;
            // 업뎃된 생존시간을 timeText 텍스트 컴포넌트를 이용해 표시
            
            timeText.text = "Time: " + (int)surviveTime;
        } else {
            if(Input.GetKeyDown(KeyCode.R)) { // R키 누르면

                // 직전까지의 Destroy Scene and Reload SampleScene 
                // Load할 Scene는 builds setting의 빌드 목록에 등록되어 있어야 한다.
                // SampleScene는 순번 0번이므로 '~.LoadScene(0)' 도 가능하다.
                SceneManager.LoadScene("SampleScene"); 
            }
        }
    }

    // 현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        isGameover = true;  // 현재 상태를 게임오버 상태로 bool값 설정
        gameoverText.SetActive(true); // Game Over 텍스트 활성화

        /*
         * PlayerPrefs (Player Preference) 
         *  - 딕셔너리 형식으로 데이터를 로컬 머신에 저장/불러올 수 있다.
         */

        // BestTime key값으로 저장된 이전까지의 최고기록 갖고오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 이전 최고기록 < 현재기록(생존시간)
        if(surviveTime > bestTime)
        {
            bestTime = surviveTime; // 최고기록을 현재기록으로 변경
            PlayerPrefs.SetFloat("BestTime", bestTime); // PlayerPrefs에 저장
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }
}
