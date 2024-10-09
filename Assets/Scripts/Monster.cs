using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float monsterHP;
    public float moveSpeed = 2f;
    public float stopDistance = 2f;
    public GameObject player;

    public Animator animator;

    public MonsterPool returnMonster;

    public Coroutine attackCotoutine;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        animator = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        monsterHP = 3;
        
    }


    private void Update()
    {
        if (monsterHP <= 0)
        {
            Debug.Log("몬스터 HP가 0 이하로 내려감");
            returnMonster.ReturnMonster(this);
        }
        else
        {
            MoveMonster();
        }
    }

    private void MoveMonster()
    {
        transform.LookAt(player.transform);
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance > stopDistance)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else
        {
            Debug.Log("몬스터 도착함");

            if(attackCotoutine == null)
            {
                attackCotoutine = StartCoroutine(Attck());
            }

        }
    }

    private IEnumerator Attck()
    {
        PlayerController player = this.player.GetComponent<PlayerController>();
        animator.Play("FlyingBiteAttack");
        // 애니메이션 추가
        player.hp--;
        Debug.Log($"현재 플레이어 체력 {player.hp}");
        yield return new WaitForSeconds(1f);
        attackCotoutine = null;
    }
}
