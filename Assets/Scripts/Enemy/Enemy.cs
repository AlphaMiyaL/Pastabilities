using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 25;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
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
            InstantateCoin();
        }
    }
    private void InstantateCoin()
    {
        int random = Random.Range(0, 20);
        if (random < 10) {
            Instantiate(coin1, transform.position, Quaternion.identity);
        }
        else if (random < 18) {
            Instantiate(coin2, transform.position, Quaternion.identity);
        }
        else {
            Instantiate(coin3, transform.position, Quaternion.identity);
        }
    }
}
