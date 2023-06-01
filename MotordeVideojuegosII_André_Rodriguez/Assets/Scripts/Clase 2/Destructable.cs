using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public int hp = 10;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
