using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float monsterHP;
    public MonsterPool returnMonster;


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
    }
}
