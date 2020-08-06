using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpnSwitcher : MonoBehaviour
{
    [SerializeField] int currentWpn = 0;

    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        int previousWpn = currentWpn;

        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWpn != currentWpn)
        {
            SetWeaponActive();
        }
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(currentWpn >= transform.childCount - 1)
            {
                currentWpn = 0;
            }
            else
            {
                currentWpn++;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currentWpn <= 0)
            {
                currentWpn = transform.childCount - 1;
            }
            else
            {
                currentWpn--;
            }
        }
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWpn = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWpn = 1;
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWpn)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }


}
