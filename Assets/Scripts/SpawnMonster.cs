using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField] MonsterPool monsterPool;
    Vector3 spawnSize;

    private void Awake()
    {
        spawnSize = transform.localScale;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        InvokeRepeating("Spawn", 0f, 5f);
    }

    private void Spawn()
    {
        Vector3 randomPos =
            new Vector3(Random.Range(- spawnSize.x , spawnSize.x ),
            0,
            Random.Range( - spawnSize.z , spawnSize.z ));
        Vector3 randomPosWorld = transform.TransformPoint(randomPos);

        Monster monster = monsterPool.RespawnMonster(randomPosWorld, Quaternion.identity);

        if(monster == null)
        {
            Debug.Log("모든 몬스터가 풀에서 나옴");
            CancelInvoke("Spawn");
        }
    }

}



