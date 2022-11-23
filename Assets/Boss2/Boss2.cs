using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    GameObject zone;
    public int health;
    private Animator anim;
    public bool aggressive;

    public bool attacking;

    [SerializeField] GameObject projectile;
    float speedOfShot;
    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        speedOfShot = 6f;
        aggressive = false;
        health = 300;
        zone = GameObject.Find("Boss2Zone");
    }

    // Update is called once per frame
    void Update()
    {
        aggressive = zone.GetComponent<B2Zone>().aggro;
        if(health < 0){
                Die();
        }
        if(aggressive && attacking == false){
            attacking = true;
            Attack();
        }

        
        
    }

    private void OnCollisionEnter2D(Collision2D other){
        GameObject col = other.gameObject;
        if(col.tag == "Bullet"){
            health -= 2;
        }

    }
    private void Die(){
        Destroy(zone); //Destroys the object and its zone.
    }

    private void Attack(){


        int ran = Random.Range(1, 2);
        if(ran == 1){
            CircularShot();
        }
        else{
            PinPointShot();
        }
        
        StartCoroutine(TimeBetweenAttacks());


    }

    //Shoots everywhere in a circle
    void CircularShot(){
        GameObject t = this.gameObject;
        Vector2 startPoint = t.transform.position;
        int numOfProjectiles = Random.Range(9,14);
        float angleStep = 360f/numOfProjectiles;
        float angle = 0f;
        
        for(int i = 0; i <= numOfProjectiles - 1; i++){

            float projectileXpos = startPoint.x + Mathf.Sin((angle * Mathf.PI)/ 180) * 5f;
            float projectileYpos = startPoint.x + Mathf.Cos((angle * Mathf.PI)/ 180) * 5f;

            Vector2 projectileVector = new Vector2 (projectileXpos, projectileYpos);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * speedOfShot;

            var proj = Instantiate(projectile, startPoint, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;
        }
        
    }
        

    //Shoots towards the player 
    void PinPointShot(){
        //TODO
    }
    IEnumerator TimeBetweenAttacks()
    {
        float rand = Random.Range(.25f,1f);
        yield return new WaitForSeconds(rand);
        attacking = false;

    }

}

