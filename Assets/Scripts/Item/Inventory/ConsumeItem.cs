using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeItem : MonoBehaviour
{
    public GameObject effect;
    public GameObject item;
    private Transform player;
    private Transform breakable;
    private Transform enemy;
    private Transform weapon;
    private Transform semiShield;
    private Transform fullShield;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        breakable = GameObject.FindGameObjectWithTag("Breakable").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        weapon = GameObject.FindGameObjectWithTag("Weapon").transform;
        semiShield = GameObject.FindGameObjectWithTag("SemiShield").transform;
        fullShield = GameObject.FindGameObjectWithTag("FullShield").transform;
    }

    public void Use()
    {
        if (item.CompareTag("PlayerHealth")) // pot stew 
        {
            PlayerStats stats = player.GetComponent<PlayerStats>();
            stats.IncreaseHealth(3);
        }
        else if (item.CompareTag("PlayerSpeed")) // cake
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.IncreaseWalkSpeed(3);
        }
        else if (item.CompareTag("BulletSpeed")) // orange potion
        {
            ShootV2 shootV2 = weapon.GetComponentInChildren<ShootV2>();
            shootV2.IncreaseBulletSpeed(3);
            //GatlingShoot gatlingShoot = weapon.GetComponent<GatlingShoot>();
            //gatlingShoot.IncreaseBulletSpeed(3);
        }
        else if (item.CompareTag("BulletDamage")) // red potion
        {
            Boss1 boss1 = enemy.GetComponent<Boss1>();
            boss1.IncreaseDamage(5);
            Breakable br = breakable.GetComponent<Breakable>();
            br.IncreaseDamage(5);
        }
        else if (item.CompareTag("CompleteShield")) // blue potion
        {
            PlayerShield full = fullShield.GetComponentInChildren<PlayerShield>();
            full.FullShieldActive(true);
        }
        else // tag == "FrontShield" // green potion
        {
            PlayerShield semi = semiShield.GetComponentInChildren<PlayerShield>();
            semi.FullShieldActive(true);
        }

        GameObject temp = Instantiate(effect, player.position, Quaternion.identity);
        Destroy(temp, 0.2f);
        Destroy(gameObject);

    }
}
