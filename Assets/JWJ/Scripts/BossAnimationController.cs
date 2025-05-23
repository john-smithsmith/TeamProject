using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    private Animator animator;
    private BossController BossController;
    private float attackRange = 2.5f;
    private bool isAttacking = false;
    private Transform player;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        BossController = GetComponentInParent<BossController>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;
    }

    private void Update()
    {
        

        float distance = Vector3.Distance(transform.position, player.position); //플레이어까지 거리
       // Debug.Log("플레이어까지 거리: " + distance);

        if (distance < attackRange && isAttacking == false && BossController.isDashing == false)
        {
            RandomAttack();
            isAttacking = true;
            Invoke(nameof(AttackDelay), 2f); // 공격 딜레이
        }


    }

    public void BossDied()
    {
        Debug.Log("보스 죽음");
        
        animator.SetTrigger("Die");
        AudioManager.instance.PlaySfx(AudioManager.Sfx.BossDead); //오디오 재생
    }


//스폰애니
public void BossSpawn()
    {
        
        animator.SetTrigger("Spawn");
       AudioManager.instance.PlaySfx(AudioManager.Sfx.BossSpawn);
    }


    //공격 리스트
    public void Dash()
    {
        
        animator.SetTrigger("Dash");
        AudioManager.instance.PlaySfx(AudioManager.Sfx.BossDash); // 오디오 재생
    }

    public void RightAttack()
    {
        animator.SetTrigger("RightAttack");
        AudioManager.instance.PlaySfx(AudioManager.Sfx.BossAttack); // 오디오 재생
    }

    public void LeftAttack()
    {
        animator.SetTrigger("LeftAttack");
        AudioManager.instance.PlaySfx(AudioManager.Sfx.BossAttack); // 오디오 재생
    }

    public void BiteAttack()
    {
        animator.SetTrigger("BiteAttack");
       AudioManager.instance.PlaySfx(AudioManager.Sfx.BossAttack); // 오디오 재생
    }


    
    private void AttackDelay()  // 공격 딜레이
    {
        isAttacking = false;
    }

    private void RandomAttack()
    {
        if (BossController.isDead == true)
        {
            return;
        }

        else
        {
            int random = UnityEngine.Random.Range(0, 3); // 0, 1, 2 중 하나

            switch (random)
            {
                case 0:
                    
                    RightAttack();
                    break;
                case 1:
                    
                    LeftAttack();
                    break;
                case 2:
                    
                    BiteAttack();
                    break;
            }
        }
        
    }
}



