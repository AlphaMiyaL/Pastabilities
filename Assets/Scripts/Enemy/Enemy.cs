using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 25;

    public void GetDamage (int damage)
    {
        hp -= damage;
        
        //Used to find the amount of damage a player has dealth in total
        PlayerStats p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        p.damageDealth += damage;
        
        if (hp <= 0)
            this.GetComponent<EnemyController>().Death();
            //Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
