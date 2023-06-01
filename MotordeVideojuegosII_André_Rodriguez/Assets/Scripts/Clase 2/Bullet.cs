using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;
    private Vector3 direction;
    public float bulletLifeTime;

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    private void Start()
    {
        Destroy(this.gameObject, bulletLifeTime);
    }


    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Destructable>())
        {
            collision.gameObject.GetComponent<Destructable>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
