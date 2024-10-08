using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    [SerializeField] List<Monster> pool = new List<Monster>();
    [SerializeField] Monster prefab;
    private Coroutine Respawn;
    int size = 10;

    private void Awake()
    // Start 이전에 몬스터 size 만큼 미리 생성
    {
        for (int i = 0; i < size; i++)
        {
            Monster monster = Instantiate(prefab);
            monster.gameObject.SetActive(false);
            monster.returnMonster = this;
            pool.Add(monster);
        }
    }

    public Monster RespawnMonster(Vector3 position, Quaternion rotation)
    // 오브젝트 풀 패턴 적용하여 생성되어있는 풀에서 빌려오기
    {
        if (pool.Count > 0)
        {
            Monster monster = pool[pool.Count - 1];
            monster.transform.position = position;
            monster.transform.rotation = rotation;
            monster.returnMonster = this;
            monster.gameObject.SetActive(true);

            pool.RemoveAt(pool.Count - 1);

            return monster;
        }
        else
        {
            return null;
        }
    }

    public void ReturnMonster(Monster monster)
    // 몬스터가 삭제될때 다시 오브젝트 풀로 돌아가게 만드는 함수
    {
        monster.gameObject.SetActive(false);
        pool.Add(monster);
        //Respawn = StartCoroutine(RespawnDelay(3));
        //// 몬스터가 사라진뒤 다시 재생성
    }

    //private IEnumerator RespawnDelay(float delay)
    //// 코루틴을 위한 IEnumerator 타입 함수 선언
    //{
    //    yield return new WaitForSeconds(delay);
    //    RespawnMonster();
    //}

    //private void Start()
    //{
    //    // 시작하자마자 몬스터 생성해두기
    //    for (int i = 0; i < size; i++)
    //    {
    //        RespawnMonster();
    //    }
    //}


}
