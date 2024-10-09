using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float monsterHP;
    public float moveSpeed = 2f;
    public float stopDistance = 2f;
    public GameObject player;

    public MonsterPool returnMonster;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

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
        }
    }
}
