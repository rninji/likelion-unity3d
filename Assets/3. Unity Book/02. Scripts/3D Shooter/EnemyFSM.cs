using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    enum EnemyState { Idle, Move, Atack, Return, Damaged, Die }

    private EnemyState m_State;

    private CharacterController cc;

    public float findDistance = 8f;
    private Transform player;

    public float attackDistance = 3.0f;
    public float moveSpeed = 5.0f;

    private float currentTime = 0;
    private float attackDelay = 2.0f;

    public int attackPower = 3;

    public int hp = 15;

    private Vector3 originPos;
    private Quaternion originRot;
    public float moveDistance = 20f;

    private int maxHp = 15;
    public Slider hpSplider;

    private Animator anim;
    
    void Start()
    {
        m_State = EnemyState.Idle;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        originPos = transform.position;
        originRot = transform.rotation;
        anim = transform.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run) 
            return;
        
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Atack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                // Damaged();
                break;
            case EnemyState.Die:
                // Die();
                break;
        }

        hpSplider.value = (float)hp / (float)maxHp;
    }

    void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            m_State = EnemyState.Move;
            
            anim.SetTrigger("IdleToMove");
        }
    }

    void Move()
    {
        // 이동 범위 벗어날 시 Move -> Return
        if (Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnemyState.Return;
        }
        // 공격 범위 이내일 시 Move -> Attack
        else if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            m_State = EnemyState.Atack;
            currentTime = attackDelay;
        }
        // 플레이어를 향해 이동
        else
        {
            Vector3 dir = (player.position - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir;
        }
    }

    void Attack()
    {
        // 공격 범위 이내일 시 공격
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            // 공격
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                currentTime = 0;
                player.GetComponent<FPSPlayerMove>().DamageAction(attackPower);
            }
        }
        // 공격 범위 벗어날 시 Attack -> Move
        else
        {
            currentTime = 0;
            m_State = EnemyState.Move;
        }
    }

    void Return()
    {
        // 원래 위치가 아닌 경우 원래 위치로 이동
        if (Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            Vector3 dir = (originPos - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir;
        }
        // 원래 위치로 돌아간 경우 hp 회복 후 Return -> Idle
        else
        {
            transform.position = originPos;
            transform.rotation = originRot;
            hp = 15;
            m_State = EnemyState.Idle;
            anim.SetTrigger("MoveToIdle");
        }
    }
    
    public void HitEnemy(int hitPower)
    {
        if (m_State == EnemyState.Die || m_State == EnemyState.Die || m_State == EnemyState.Return) 
            return;
        
        hp -= hitPower;

        if (hp > 0)
        {
            m_State = EnemyState.Damaged;
            Damaged();
        }
        else
        {
            m_State = EnemyState.Die;
            Die();
        }
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0.5f);

        // Damaged -> Move
        m_State = EnemyState.Move;
    }
    
    void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false;

        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
