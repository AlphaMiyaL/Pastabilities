using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 25;

    public void GetDamage (int damage)
    {
        hp -= damage;

        if (hp <= 0)
            this.GetComponent<EnemyController>().Death();
            //Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
