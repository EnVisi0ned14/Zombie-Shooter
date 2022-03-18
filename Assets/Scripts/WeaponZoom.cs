using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float zoomedIn = 20f;
    [SerializeField] float zoomedOut = 60f;
    [SerializeField] GameObject Player;

    [SerializeField] float zoomedInSensitivity = .5f;
    [SerializeField] float zoomedOutSensitivity = 2f;

    private void OnDisable()
    {
        ZoomOut();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ZoomGun();
    }

    private void ZoomGun()
    {
        if(Input.GetMouseButton(1))
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }

    }

    private void ZoomOut()
    {
        Player.GetComponentInParent<RigidbodyFirstPersonController>().mouseLook.XSensitivity = zoomedOutSensitivity;
        Player.GetComponentInParent<RigidbodyFirstPersonController>().mouseLook.XSensitivity = zoomedOutSensitivity;
        mainCamera.fieldOfView = zoomedOut;
    }

    private void ZoomIn()
    {
        mainCamera.fieldOfView = zoomedIn;
        Player.GetComponentInParent<RigidbodyFirstPersonController>().mouseLook.XSensitivity = zoomedInSensitivity;
        Player.GetComponentInParent<RigidbodyFirstPersonController>().mouseLook.XSensitivity = zoomedInSensitivity;
    }
}
