using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Predator : StrongAnimal
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
