using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int damage;
    public float bulletsSpeed;
    private Vector3 bulletsDirection;
    public float bulletsLifeTime;
    public BulletType bulletsType;

    public void SetDirection(Vector3 newDirection)
    {
        bulletsDirection = newDirection;
    }

    private void Start()
    {
        Destroy(this.gameObject, bulletsLifeTime);
    }

    private void Update()
    {
        transform.position += bulletsDirection * bulletsSpeed * Time.deltaTime;
    }
}
