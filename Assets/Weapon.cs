using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = Mathf.Infinity;
    [SerializeField] float Damage = 20f;

    [SerializeField] GameObject hitEffectFX;
    [SerializeField] ParticleSystem muzzleFX;

    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 2f;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProccessRayCast();
            ammoSlot.AmmoDecreaser(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFX.Play();
    }

    private void ProccessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            //TODO Add Visual Feedback
            CreateHitImpact(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(Damage);
            //call a method to decrease enemy health
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffectFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }

    
}
