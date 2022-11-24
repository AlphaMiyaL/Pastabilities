using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeItem : MonoBehaviour
{
    public GameObject effect;
    public GameObject item;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use()
    {
        if (item.CompareTag("PlayerHealth"))
        {
            PlayerStats stats = player.GetComponent<PlayerStats>();
            stats.IncreaseHealth(3);
        }
        else if (item.CompareTag("PlayerSpeed"))
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.IncreaseWalkSpeed(3);
        }
        else if (item.CompareTag("BulletSpeed"))
        {
            ShootV2 shootV2 = player.GetComponent<ShootV2>();
            shootV2.IncreaseBulletSpeed(2);
            GatlingShoot gatlingShoot = player.GetComponent<GatlingShoot>();
            gatlingShoot.IncreaseBulletSpeed(2);
        }
        //else if (item.CompareTag("BulletDamage"))
        //{

        //}
        //else if (item.CompareTag("CompleteShield"))
        //{

        //}
        //else // tag == "FrontShield"
        //{

        //}

        GameObject temp = Instantiate(effect, player.position, Quaternion.identity);
        Destroy(temp, 0.1f);
        Destroy(gameObject);

    }
}
