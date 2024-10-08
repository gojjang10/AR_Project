using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GunSpawn : MonoBehaviour
{
    public GameObject gunPrefab;
    private ARPlaneManager aRPlaneManager;
    private bool gunCreated = false;

    private void Start()
    {
        aRPlaneManager = GetComponent<ARPlaneManager>();
        aRPlaneManager.planesChanged += OnPlaneChange;          // AR플레인매니저의 이벤트에 함수 추가
    }

    private void OnPlaneChange(ARPlanesChangedEventArgs args)
    {
        if (gunCreated)             // 총을 한번만 생성해주기 위한 조건
            return;

        foreach (ARPlane plane in args.added)
        {
            Vector3 planeCenter = plane.center;
            Quaternion rotation = Quaternion.Euler(0, 0, -90);
            Instantiate(gunPrefab, planeCenter, rotation);
            gunCreated = true;
            break;
        }
    }
}
