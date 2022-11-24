using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 3;
    public float line = 5;
    public float shootingLine = 2;
    public float fireSpeed = 2f;
    private float nextFireTime;

    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Get distance between player and boss
        float distance = Vector2.Distance(player.position, transform.position);

        //Boss moves when player is between line and shooting line.
        if(distance < line && distance > shootingLine)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        //Boss stops moving when player is inside shooting line, and starts to shoot. 
        else if(distance <= shootingLine && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireSpeed;
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, line);
        Gizmos.DrawWireSphere(transform.position, shootingLine);
    }
}
