using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerModel model;

    [SerializeField] GameObject gunPrefab;
    [SerializeField] GameObject monsterSpawner;
    [SerializeField] GameObject inGameUI;
    [SerializeField] Button pickupButton;
    [SerializeField] Transform playerCam;

    [SerializeField] float repeatTime;

    private Coroutine shotcoroutine;
    private Coroutine reloadcoroutine;
    private WaitForSeconds delay;
    private WaitForSeconds reloadDelay;

    private int maxBullet = 30;
    private int curBullet = 30;
    private bool getGun = false;


    private void Start()
    {
        pickupButton.gameObject.SetActive(false);
        gunPrefab.SetActive(false);
        monsterSpawner.SetActive(false);
        inGameUI.SetActive(false);

        delay = new WaitForSeconds(repeatTime);
        reloadDelay = new WaitForSeconds(2f);
    }

    private void Update()
    {
        if(!getGun)
        {
            if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit))
            {
                Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * 10, Color.yellow);
                GameObject instance = hit.collider.gameObject;

                if(instance.CompareTag("Gun"))
                {
                    pickupButton.gameObject.SetActive(true);
                }

            }
            else
            {
                pickupButton.gameObject.SetActive(false) ;
            }
        }
        model.Bullet = curBullet;
    }

    public void PickUpGun()
    {
        if(!getGun)
        {
            if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit))
            {
                GameObject instance = hit.collider.gameObject;

                if(instance.CompareTag("Gun"))
                {
                    Destroy(instance);
                    gunPrefab.SetActive(true) ;
                    monsterSpawner.SetActive(true);
                    inGameUI.SetActive(true);
                    getGun = true ;
                    pickupButton.gameObject.SetActive(false);
                }
            }
        }
    }

    public void Fire()
    {
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward))
        {
            Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward, Color.red);
            Debug.Log("총 발사");
        }

        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit))
        {
            Debug.DrawRay(playerCam.transform.position, hit.point);
            GameObject instance = hit.collider.gameObject;
            Monster target = instance.GetComponent<Monster>();

            if (target != null)
            {
                Debug.Log("몬스터 적중");
                target.monsterHP -= 1;
            }
        }
    }

    public void OnFire()
    {
        if(shotcoroutine == null)
        {
            shotcoroutine = StartCoroutine(ShotRepeat());
        }
    }

    public void OffFire()
    {
        if(shotcoroutine != null)
        {
            StopCoroutine(shotcoroutine);
            shotcoroutine = null;
        }
    }

    public void OnReload()
    {
        if(reloadcoroutine == null)
        {
            reloadcoroutine = StartCoroutine(reload());
        }
    }

    public void OffReload()
    {
        StopCoroutine(reload());
        reloadcoroutine = null; 
    }

    private IEnumerator ShotRepeat()
    {
        while (curBullet > 0)
        {
            Fire();
            curBullet--;

            yield return delay;
        }

        Debug.Log("총알이 부족합니다. 'R'키를 눌러 재장전 하십시오.");
        shotcoroutine = null;
    }
    private IEnumerator reload()
    {
        Debug.Log("장전중...");
        yield return reloadDelay;

        curBullet = maxBullet;

        Debug.Log("장전완료");
        reloadcoroutine = null;
    }

}
