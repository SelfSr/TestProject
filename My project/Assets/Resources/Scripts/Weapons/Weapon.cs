using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject weaponSprite;
    public Transform firePoint;
    public float damage;

    public float timeBtwShots;
    public float timeReload;

    public int bulletsInOneMagazine;
}