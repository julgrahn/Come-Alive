using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] float zoomInFOV = 20f;
    [SerializeField] float mouseSenseZoomIn = .8f;
    [SerializeField] float mouseSenseZoomOut = 2f;

    RigidbodyFirstPersonController fpsController;

    bool zoomedInToggle = false;

    private void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpsCamera.fieldOfView = zoomInFOV;
                fpsController.mouseLook.XSensitivity = mouseSenseZoomIn;
                fpsController.mouseLook.YSensitivity = mouseSenseZoomIn;
            }
            else
            {
                zoomedInToggle = false;
                fpsCamera.fieldOfView = zoomOutFOV;
                fpsController.mouseLook.XSensitivity = mouseSenseZoomOut;
                fpsController.mouseLook.YSensitivity = mouseSenseZoomOut;
            }
        }
    }

}
