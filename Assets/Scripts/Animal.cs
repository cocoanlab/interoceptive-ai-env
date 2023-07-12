using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    // protected PlayerController thePlayerStatus;
    [SerializeField] public string animalName; 
    [SerializeField] protected int hp; // 체력
   
    [SerializeField] protected float walkSpeed; 
    [SerializeField] protected float runSpeed; 
    [SerializeField] protected float turningSpeed; 
    protected Vector3 destination; 
    protected float applySpeed ;
    protected Vector3 direction ;

    // 상태 변수 
    protected bool isAction ; 
    protected  bool isWalking ;
    protected bool isRunning ; 
    protected bool isChasing; 
    protected bool isAttacking;
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
    protected NavMeshAgent nav;
    public Transform AgentStatus;
    protected FieldOfViewAngle theViewAngle;

    [SerializeField] protected AudioClip[] sound_Normal;
    [SerializeField] protected AudioClip sound_Hurt;
    [SerializeField] protected AudioClip sound_Dead;
    
    // Start is called before the first frame update
     void Start()
    {   
        // AgentStatus = GameObject.FindGameObjectsWithTag("Player").transform
        theViewAngle = GetComponent<FieldOfViewAngle>();
        nav = GetComponent<NavMeshAgent>();
        theAudio = GetComponent<AudioSource>();
        currentTime = waitTime;
        isAction = true;
    }
    protected virtual void Update()
    {   
        nav.SetDestination(AgentStatus.position);
        
        if (!isDead)
        {
            Move();
            ElapseTime();
        }
    }
 

    protected void Move()
    {
        if (isWalking || isRunning)
            rigid.MovePosition(transform.position + (transform.forward * applySpeed * Time.deltaTime));
            nav.SetDestination(transform.position + destination * 5f);
    
    }
    
    protected void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0 && !isChasing && !isAttacking)  // 랜덤하게 다음 행동을 개시
                ReSet();
        }
    }
    protected void Rotation()
    {
        if (isWalking || isRunning)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, direction.y, 0f), turningSpeed);
            rigid.MoveRotation(Quaternion.Euler(_rotation));
        }
    }

 protected virtual void ReSet()  //virtual -> Pig script에서 완성가능
    {
        isWalking = false; isRunning = false; isAction = true;
        nav.speed = walkSpeed;
        nav.ResetPath();
        anim.SetBool("Walking", isWalking); anim.SetBool("Running", isRunning);
        destination.Set(Random.Range(-0.2f, 0.2f), 0f, Random.Range(0.5f, 1f));
    }
    protected void TryWalk()
    {
        isWalking = true;
        anim.SetBool("Walking", isWalking);
        currentTime = walkTime;
        applySpeed = walkSpeed;
        Debug.Log("Walk");
    }
    protected void TryRun()
    {
        isRunning = true;
        anim.SetBool("Running", isRunning);
        currentTime = runTime;
        applySpeed = runSpeed;
        Debug.Log("Run");
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
        isChasing = false;
        isAttacking = false;
        isDead = true;
        nav.ResetPath();
        anim.SetTrigger("Dead");
    }

    protected void RandomSound()
    {
        int _random = Random.Range(0, 3); // 일상 사운드 3개
    //    PlaySE(sound_Normal[_random]);
    }

    // protected void PlaySE(AudioClip _clip)
    // {
    //     theAudio.clip = _clip;
    // theAudio.Play();
    // }
    //    public Item GetItem()
    // {
    //     this.gameObject.tag = "Untagged";
    //     Destroy(this.gameObject, 3f);
    //     return item_Prefab;
    // }
   
}


