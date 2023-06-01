using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tag que se crean
public enum WeaponType
{
    PISTOL,
    SHOTGUN,
    MACHINGUN
}

[System.Serializable]
public struct Weapon
{
    public WeaponType Type;
    [Range(1, 100)] public float power;
    [Range(1, 10)] public int bulletPerBurst;//Spread
    [Range(1, 10)] public int repetionAmount;//Rafaga
    [Range(0.01f, 10f)] public float bulletLifeTime;
}


public class PlayeratwinStickController : MonoBehaviour
{
    public float speed = 5.0f;
    [SerializeField]private Camera _mainCamera;

    private Weapon currentWeapon;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject prefabBullet;

    private bool canShoot = true;

    [SerializeField] private Weapon[] arsenal;

    private void Start()
    {
        _mainCamera = Camera.main;

        if(arsenal.Length > 0)
        {
            currentWeapon = arsenal[0];
        }     



    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.position += movement * speed * Time.deltaTime;

        Ray camRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            transform.rotation = newRotation;
        }

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            canShoot = false;
            StartCoroutine(Shoot());
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = arsenal[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = arsenal[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = arsenal[2];
        }
    }

    private IEnumerator Shoot()
    {
        for (int i = 0; i < currentWeapon.repetionAmount; i++)
        {
            StartCoroutine(ShootBrust());
            yield return new WaitForSeconds(0.2f);
        }
        canShoot = true;
    }

    private IEnumerator ShootBrust()
    {
        float maxSpreadAngle = 45.0f;
        for (int i = 0; i < currentWeapon.bulletPerBurst; i++)
        {
            GameObject bullet = Instantiate(prefabBullet, shootingPoint.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.speed = currentWeapon.power;

            if (currentWeapon.bulletPerBurst > 1)
            {
                float spreadAngel = (maxSpreadAngle / (currentWeapon.bulletPerBurst - 1)) * i - maxSpreadAngle / 2;
                Vector3 bulletDirection = Quaternion.Euler(0f, spreadAngel, 0) * transform.forward;
                bulletScript.SetDirection(bulletDirection);
            }
            else
            {
                Vector3 bulletDirection = Quaternion.Euler(0f, 0, 0) * transform.forward;
                bulletScript.SetDirection(bulletDirection);
            }

            bulletScript.bulletLifeTime = currentWeapon.bulletLifeTime;
        }
        yield return new WaitForSeconds(0.1f);
    }
}
