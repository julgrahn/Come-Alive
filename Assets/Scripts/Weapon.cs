﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float bulletRange = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 0.5f;

    bool canShoot = true;

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo() > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, bulletRange))
        {
            HitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void HitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
