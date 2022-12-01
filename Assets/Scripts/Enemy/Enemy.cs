using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 25;
    public List<AudioClip> enemyHurtSFX = new List<AudioClip>();
    public AudioClip enemyDeathSFX;

    public void GetDamage (int damage)
    {
        hp -= damage;
        AudioManager.instance.PlaySound(enemyHurtSFX[Random.Range(0, enemyHurtSFX.Count)]);
        
        //Used to find the amount of damage a player has dealth in total
        PlayerStats p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        p.damageDealth += damage;

        if (hp <= 0)
        {
            AudioManager.instance.PlaySound(enemyDeathSFX);
            this.GetComponent<EnemyController>().Death();
            //Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
