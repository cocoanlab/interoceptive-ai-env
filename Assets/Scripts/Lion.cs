using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lion : StrongAnimal
{
    protected override void Update()
    {
        base.Update();
        // Debug.Log(theViewAngle.View());
        if (theViewAngle.View() && !isDead)
        {
            StopAllCoroutines();
            Debug.Log("stop");
            StartCoroutine(ChaseTargetCoroutine());
            Debug.Log("start chasing");
        }
    }

    // IEnumerator chaseTargetCoroutine()
    // {
    //     CurrentChaseTime = 0;
    //     Chase(theViewAngle.GetTargetPos());

    //     while(CurrentChaseTime < ChaseTime)
    //     {
    //         Chase(theViewAngle.GetTargetPos());
    //         yield return new WaitForSeconds(ChaseDelayTime);
    //         CurrentChaseTime += ChaseDelayTime;
    //         Debug.Log("chasing");
    //     }

    //     isChasing = false;
    //     isRunning = false;
    //     anim.SetBool("Running", isRunning);
    //     nav.ResetPath();
    // }

    // IEnumerator AttackCoroutine()
    // {
    //     isAttacking = true;
    //     nav.ResetPath();
    //     CurrentChaseTime = ChaseTime;
    //     yield return new WaitForSeconds(0.5f);
    //     transform.LookAt(new Vector3(theViewAngle.GetTargetPos().x, 0f, theViewAngle.GetTargetPos().z));
    //     anim.SetTrigger("Attack");
    //     yield return new WaitForSeconds(0.5f);
    //     RaycastHit _hit;
    //     if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out _hit, attackDistance, targetMask))
    //     {
    //         Debug.Log("target hit");
    //         // thePlayerStatus.DecreaseHP(attackDamage);
    //     }

    //     else
    //     {
    //         Debug.Log("target missed");
    //     }

    protected override void ReSet()
    {
        base.ReSet();
        RandomAction();
    }

    private void RandomAction()
    {
        RandomSound();

        int _random = Random.Range(0, 2);

        if (_random == 0)
            TryRun();
        else if (_random == 1)
            TryWalk();

    }

    private void Walk()
    {
        currentTime = waitTime;
        anim.SetTrigger("Walk");
        Debug.Log("Walk");
    }
    private void Run()
    {
        currentTime = runTime;
        anim.SetTrigger("Run");
        Debug.Log("Run");
    }

    private void Wait()  // 대기
    {
        currentTime = waitTime;
        Debug.Log("wait");
    }

}
