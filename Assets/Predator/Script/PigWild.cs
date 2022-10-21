using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigWild : StrongAnimal {

    protected override void Update()
    {
        base.Update();
        if (theViewAngle.View() && !isDead && !isAttacking)
        {
            StopAllCoroutines();
            StartCoroutine(ChaseTargetCoroutine());
        }

    }
}

   
