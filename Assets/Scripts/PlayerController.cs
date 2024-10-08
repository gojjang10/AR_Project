using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject gunPrefab;
    [SerializeField] Button pickupButton;
    [SerializeField] Transform playerCam;
    private bool getGun = false;

    private void Start()
    {
        pickupButton.gameObject.SetActive(false);
        gunPrefab.SetActive(false);
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
                    getGun = true ;
                    pickupButton.gameObject.SetActive(false);
                }
            }
        }
    }

}
