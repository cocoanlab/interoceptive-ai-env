using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAnimal : Animal 
{

    [SerializeField]
    protected int attackDamage; 
    [SerializeField]
    protected float attackDelay; 
    [SerializeField]
    protected float attackDistance; 
    [SerializeField]
    protected LayerMask targetMask; 

    [SerializeField]
    protected float ChaseTime; 
    protected float CurrentChaseTime; 
    [SerializeField]
    protected float ChaseDelayTime; 

    public void Chase(Vector3 _targetPos)
    {
        destination = _targetPos;

        isChasing = true;

        isWalking = false;
        isRunning = true;
        nav.speed = runSpeed;

        anim.SetBool("Running", isRunning);

        nav.SetDestination(destination);
    }

    public override void Damage(int _dmg, Vector3 _targetPos)
    {
        base.Damage(_dmg, _targetPos);
        if (!isDead)
            Chase(_targetPos);
    
    }

    protected IEnumerator ChaseTargetCoroutine()
    {
        CurrentChaseTime = 0;
        Chase(theViewAngle.GetTargetPos());

        while (CurrentChaseTime < ChaseTime)
        {
            Chase(theViewAngle.GetTargetPos()); //충분히 가까이 있고
            if (Vector3.Distance(transform.position, theViewAngle.GetTargetPos()) <= attackDistance)           
            {
                if (theViewAngle.View()) // 눈 앞에 있을 경우
                {
                    Debug.Log("try attack");
                    StartCoroutine(AttackCoroutine());
                }
            }
            yield return new WaitForSeconds(ChaseDelayTime);
            CurrentChaseTime += ChaseDelayTime;
        }

        isChasing = false;
        isRunning = false;
        anim.SetBool("Running", isRunning);
        nav.ResetPath();
    }

    protected IEnumerator AttackCoroutine()
    {
        isAttacking = true;
        nav.ResetPath();
        CurrentChaseTime = ChaseTime;
        yield return new WaitForSeconds(0.5f);
        transform.LookAt(new Vector3(theViewAngle.GetTargetPos().x, 0f, theViewAngle.GetTargetPos().z));
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);
        RaycastHit _hit;
        if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out _hit, attackDistance, targetMask))
        {
            Debug.Log("target hit");
            // thePlayerStatus.DecreaseHP(attackDamage);
        }
        
        else
        {
            Debug.Log("target missed");
        }

        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
        StartCoroutine(ChaseTargetCoroutine());
    }
}


