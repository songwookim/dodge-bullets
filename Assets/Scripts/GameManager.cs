using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI���� ���̺귯��
using UnityEngine.SceneManagement; // �� ���� ���̺귯��
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // �÷��̾� ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� Obj

    public Text timeText;  // �����ð� ǥ�� �ؽ�Ʈ ������Ʈ
    public Text recordText; // �ְ��� ǥ�� �ؽ�Ʈ ������Ʈ

    private float surviveTime; // �����ð�
    private bool isGameover; // ���ӿ��� bool ����


    void Start()
    {
        // �����ð��� ���ӿ������� �ʱ�ȭ
        surviveTime = 0;
        isGameover = false;

    }

    void Update()
    {
        if(!isGameover) {
            // �����ð� ������Ʈ
            surviveTime += Time.deltaTime;
            // ������ �����ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            
            timeText.text = "Time: " + (int)surviveTime;
        } else {
            if(Input.GetKeyDown(KeyCode.R)) { // RŰ ������

                // ���������� Destroy Scene and Reload SampleScene 
                // Load�� Scene�� builds setting�� ���� ��Ͽ� ��ϵǾ� �־�� �Ѵ�.
                // SampleScene�� ���� 0���̹Ƿ� '~.LoadScene(0)' �� �����ϴ�.
                SceneManager.LoadScene("SampleScene"); 
            }
        }
    }

    // ���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        isGameover = true;  // ���� ���¸� ���ӿ��� ���·� bool�� ����
        gameoverText.SetActive(true); // Game Over �ؽ�Ʈ Ȱ��ȭ

        /*
         * PlayerPrefs (Player Preference) 
         *  - ��ųʸ� �������� �����͸� ���� �ӽſ� ����/�ҷ��� �� �ִ�.
         */

        // BestTime key������ ����� ���������� �ְ��� �������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // ���� �ְ��� < ������(�����ð�)
        if(surviveTime > bestTime)
        {
            bestTime = surviveTime; // �ְ����� ���������� ����
            PlayerPrefs.SetFloat("BestTime", bestTime); // PlayerPrefs�� ����
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }
}
