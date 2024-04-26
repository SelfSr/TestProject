using System;
using System.Collections;
using UnityEngine;

public class UnitPlayerWeaponController : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private Bullet bullet;
    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private float detectionRadius;

    private GameObject weapon_go;
    private Weapon weapon;
    private float timeSinceLastShot = 0f;
    private float bulletSpeed = 10f;
    private int bulletsLeftInMagazine;

    private Collider2D[] hitColliders;
    private Collider2D nearestEnemyCollider;
    private int maxColliders = 3;

    public void Init()
    {
        StartCoroutine(UpdateNearestEnemy());
    }

    private void OnEnable()
    {
        EventsManager.setWeapon += SetWeapon;
        EventsManager.deleteItem += RemoveWeapon;
    }

    private void FixedUpdate()
    {
        if (timeSinceLastShot > 0f)
        {
            timeSinceLastShot -= Time.deltaTime;
        }

        if (nearestEnemyCollider != null)
        {
            Vector3 direction = nearestEnemyCollider.transform.position - weaponHolder.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (direction.x < 0f)
                weaponHolder.rotation = Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.Euler(180, 0, 0);
            else
                weaponHolder.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void SetWeapon(GameObject Weapon)
    {
        if (weaponHolder != null && Weapon != null && Weapon != weapon_go)
        {
            weapon_go = Instantiate(Weapon, weaponHolder.position, weaponHolder.rotation, weaponHolder);

            weapon = weapon_go.GetComponent<Weapon>();

            bulletsLeftInMagazine = weapon.bulletsInOneMagazine;

            UIEvents.onBulletsChanged?.Invoke(bulletsLeftInMagazine, false);

            bullet.speed = bulletSpeed;
            bullet.damage = weapon.damage;
            bullet.mask = hitLayer;
        }
    }

    private void RemoveWeapon(GameObject WeaponGO)
    {
        if(weapon != null)
        {
            Destroy(weapon_go);
        }
    }

    public void Shoot()
    {
        if (timeSinceLastShot <= 0f)
        {
            if (bulletsLeftInMagazine > 0f)
            {
                Instantiate(bullet.gameObject, weapon.firePoint.position, weapon.firePoint.rotation);
                timeSinceLastShot = weapon.timeBtwShots;
                bulletsLeftInMagazine--;
                UIEvents.onBulletsChanged?.Invoke(bulletsLeftInMagazine, false);
            }
            else
            {
                UIEvents.onBulletsChanged?.Invoke(bulletsLeftInMagazine, true);
                StartCoroutine(ReloadWeapon());
            }
        }
    }

    private IEnumerator ReloadWeapon()
    {
        yield return new WaitForSeconds(weapon.timeReload);
        bulletsLeftInMagazine = weapon.bulletsInOneMagazine;
        UIEvents.onBulletsChanged?.Invoke(bulletsLeftInMagazine, false);
    }

    private IEnumerator UpdateNearestEnemy()
    {
        while (gameObject.activeSelf == true)
        {
            hitColliders = new Collider2D[maxColliders];
            int numColliders = Physics2D.OverlapCircleNonAlloc(weaponHolder.position, detectionRadius, hitColliders, hitLayer);

            float minDistance = Mathf.Infinity;
            nearestEnemyCollider = null;

            for (int i = 0; i < numColliders; i++)
            {
                float distance = Vector2.Distance(weaponHolder.position, hitColliders[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemyCollider = hitColliders[i];
                }
            }
            yield return new WaitForSeconds(2f);
        }
    }
    private void OnDisable()
    {
        EventsManager.setWeapon -= SetWeapon;
    }
}