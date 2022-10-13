using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{   [SerializeField] protected string animalName ;
    [SerializeField] protected int hp ;  // 체력 

    [SerializeField] protected float walkSpeed ;
    [SerializeField] protected float runSpeed ;

    protected float applySpeed ;
    protected Vector3 direction ; 

    // 상태 변수 
    protected bool isAction ; 
    protected  bool isWalking ;
    protected bool isRunning ; 
    protected bool isDead;

    [SerializeField] protected float walkTime ; 
    [SerializeField] protected float waitTime ; 
    [SerializeField] protected float runTime ; 
    protected float currentTime ; 


    // necessary components
    [SerializeField] protected Animator anim ; 
    [SerializeField] protected Rigidbody rigid ; 
    [SerializeField] protected BoxCollider boxcol ; 
    protected AudioSource theAudio;
    [SerializeField] protected AudioClip[] sound_Normal;
    [SerializeField] protected AudioClip sound_Hurt;
    [SerializeField] protected AudioClip sound_Dead;
    // Start is called before the first frame update
     void Start()
    {
        currentTime = waitTime;
        isAction = true;
    }
    void Update () 
    {
        if (!isDead) 
        {
            Move();
            Rotation();
            ElapseTime();
        }
    }
    protected void Move()
    {
        if (isWalking || isRunning)
            rigid.MovePosition(transform.position + (transform.forward * applySpeed * Time.deltaTime));
    }
    protected void Rotation()
    {
        if (isWalking || isRunning)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, direction.y, 0f), 0.01f);
            rigid.MoveRotation(Quaternion.Euler(_rotation));
        }
    }

    protected void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
                ReSet();
        }
    }
    protected virtual void ReSet()  //virtual -> Pig script에서 완성가능
    {
        isWalking = false; isRunning = false; isAction = true;
        applySpeed = walkSpeed;
        anim.SetBool("Walking", isWalking); anim.SetBool("Running", isRunning);
        direction.Set(0f, Random.Range(0f, 360f), 0f);
    }
    

    protected void TryWalk()
    {
        isWalking = true;
        anim.SetBool("Walking", isWalking);
        currentTime = walkTime;
        applySpeed = walkSpeed;
        Debug.Log("걷기");
    }

    public virtual void Damage(int _dmg, Vector3 _targetPos)
    {
        if (!isDead)
        {
            hp -= _dmg;

            if (hp <= 0)
            {
                Dead();
                return;
            }
            // PlaySE(sound_Hurt);
            anim.SetTrigger("Hurt");
         }
    }

    protected void Dead()
    {
        // PlaySE(sound_Dead);
        isWalking = false;
        isRunning = false;
        isDead = true;
        anim.SetTrigger("Dead");
    }

    protected void RandomSound()
    {
        int _random = Random.Range(0, 3); // 일상 사운드 3개
        // PlaySE(sound_Normal[_random]);
    }

    // protected void PlaySE(AudioClip _clip)
//     {
//         theAudio.clip = _clip;
//         theAudio.Play();
//     }
}
