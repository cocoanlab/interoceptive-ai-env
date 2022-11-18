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

    IEnumerator chaseTargetCoroutine()
    {
        CurrentChaseTime = 0;
        Chase(theViewAngle.GetTargetPos());

        while(CurrentChaseTime < ChaseTime)
        {
            Chase(theViewAngle.GetTargetPos());
            yield return new WaitForSeconds(ChaseDelayTime);
            CurrentChaseTime += ChaseDelayTime;
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

        int _random = Random.Range(0, 2); 

        if (_random == 0)
            Wait();
        else if (_random == 1)
            TryWalk();
        

    }

    // private void Walk() 
    // {
    //     currentTime = waitTime;
    //     anim.SetTrigger("Walk");
    //     Debug.Log("Walk");
    // }
    // private void Run() 
    // {
    //     currentTime = runTime;
    //     anim.SetTrigger("Run");
    //     Debug.Log("Run");
    // }
   
    private void Wait()  // 대기
    {
        currentTime = waitTime;
        Debug.Log("wait");
    }

    
}

