using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XVR_PlayerCollision : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void pauseGame()
    {
        Time.timeScale = 0;
        // 게임 오버 메시지 : 메인 화면으로 돌아가기 or 다시 레벨 플레이
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"trigger : {other.gameObject.tag}");

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log($"trigger : {other.gameObject.tag}");
            pauseGame();
        }
        else if (other.gameObject.tag == "Block_Break")
        {
            Debug.Log($"trigger : {other.gameObject.tag}");
        }
        else if (other.gameObject.tag == "Block_XBreak")
        {
            Debug.Log($"trigger : {other.gameObject.tag}");
        }
    }
    
}
