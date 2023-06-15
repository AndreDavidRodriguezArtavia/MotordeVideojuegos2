using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestuctableRed : MonoBehaviour
{
    public int hp = 100;

    public void TakeDamage(int damage, BulletType bulletstype)
    {
        if (bulletstype == BulletType.Red)
        {
            damage = Mathf.RoundToInt(damage * 0f);
        }
        else if (bulletstype == BulletType.Blue)
        {
            damage = Mathf.RoundToInt(damage * 2f);
        }

        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bullets bullets = collision.collider.GetComponent<Bullets>();

        if (bullets != null)
        {
            TakeDamage(bullets.damage, bullets.bulletsType);
            Destroy(bullets.gameObject);
        }
    }
}
