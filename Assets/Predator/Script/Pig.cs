using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig: StrongAnimal
{
    // protected override void Update()
    // {
    //     base.Update();
    //     if(theViewAngle.View() && !isDead)
    //     {
    //         Run(theViewAngle.GetTargetPos());
    //     }
    // }

    protected override void ReSet()
    {
        base.ReSet();
        RandomAction();
    }

    private void RandomAction()
    {
        RandomSound();

        int _random = Random.Range(0, 4); // 대기, 풀뜯기, 두리번, 걷기.

        // if (_random == 0)
        //     Wait();
        // else if (_random == 2)
        //     Peek();
        if (_random == 1)
            TryRun();
        else if (_random == 2)
            TryWalk();
        else if (_random == 3)
            Eat();
    }
    private void Wait() //weak animal일때
    {
        currentTime = waitTime;
        Debug.Log("Wait");
    }
    private void Eat()
    {
        currentTime = waitTime;
        anim.SetTrigger("Eat");
        Debug.Log("Eat");
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
    private void Peek()  //weak animal일떄
    {
        currentTime = waitTime;
        anim.SetTrigger("Peek");
        Debug.Log("Peek");
    }

}
