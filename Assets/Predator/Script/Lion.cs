using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : StrongAnimal
{
    protected override void Update()
    {
        base.Update();
        if (theViewAngle.View() && !isDead)
        {
            StopAllCoroutines();
            StartCoroutine(ChaseTargetCoroutine());
        }
    }

    IEnumerator ChaseTargetCoroutine()
    {
        currentChaseTime = 0;
        Chase(theViewAngle.GetTargetPos());

        while(currentChaseTime < ChaseTime)
        {
            Chase(theViewAngle.GetTargetPos());
            yield return new WaitForSeconds(ChaseDelayTime);
            currentChaseTime += ChaseDelayTime;
        }

        isChasing = false;
        isRunning = false;
        anim.SetBool("Running", isRunning);
        nav.ResetPath();
    }

    protected override void ReSet()
    {
        base.ReSet();
        RandomAction();
    }

    private void RandomAction()
    {
        RandomSound();

        int _random = Random.Range(0, 2); // 대기, 걷기

        if (_random == 1)
            TryRun();
        else if (_random == 2)
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
        currentTime = waitTime;
        anim.SetTrigger("Run");
        Debug.Log("Run");
    }

    private void Wait()  // 대기
    {
        currentTime = waitTime;
        Debug.Log("대기");
    }
    // protected override void Update()
    // {
    //     base.Update();
    //     if (theViewAngle.View() && !isDead)
    //     {
    //         StopAllCoroutines();
    //         StartCoroutine(ChaseTargetCoroutine());
    //     }
    // }

    // IEnumerator ChaseTargetCoroutine()
    // {
    //     currentChaseTime = 0;
    //     Chase(theViewAngle.GetTargetPos());

    //     while(currentChaseTime < ChaseTime)
    //     {
    //         Chase(theViewAngle.GetTargetPos());
    //         yield return new WaitForSeconds(ChaseDelayTime);
    //         currentChaseTime += ChaseDelayTime;
    //     }

    //     isChasing = false;
    //     nav.ResetPath();
    // }
}

