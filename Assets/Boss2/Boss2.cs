using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public GameObject stairs;
    GameObject zone;
    public int health;
    private Animator anim;
    public bool aggressive;

    public bool attacking;

    [SerializeField]private GameObject shootPoint1;
    [SerializeField]private GameObject shootPoint2;
    [SerializeField]private GameObject shootPoint3;

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
        if(health <= 0){
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
            health -= col.GetComponent<Bullet>().damage;
            PlayerStats p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            p.damageDealth += 2;
        }

    }
    private void Die(){
        Vector2 t = gameObject.transform.position;
        Instantiate(stairs, t, Quaternion.identity);
        Destroy(zone); //Destroys the object and its zone.
    }

    private void Attack(){

        if(health <= 150) speedOfShot = 20f;

        int ran = Random.Range(1, 4);
        if(ran == 1){
            CircularShot();
        } else if(ran == 2){
            MoveBody();
        }
        else{
            PinPointShot();
        }
        
        StartCoroutine(TimeBetweenAttacks());


    }

    //Shoots everywhere in a circle
    void CircularShot(){
        Vector2 startPoint = chooseShootingPoint();
        int numOfProjectiles = Random.Range(9,14);
        float angleStep = 360f/numOfProjectiles;
        float angle = 0f;
        
        for(int i = 0; i < numOfProjectiles; i++){

            float projectileXpos = startPoint.x + Mathf.Sin((angle * Mathf.PI)/ 180) * 5f;
            float projectileYpos = startPoint.y + Mathf.Cos((angle * Mathf.PI)/ 180) * 5f;

            Vector2 projectileVector = new Vector2 (projectileXpos, projectileYpos);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * speedOfShot;

            var proj = Instantiate(projectile, startPoint, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;
        }
        
    }
    void MoveBody(){
        B2Zone obj = zone.GetComponent<B2Zone>();
        obj.Move();
    }
        

    //Shoots towards the player 
    void PinPointShot(){
        Vector2 target = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 startPoint = chooseShootingPoint();
        GameObject proj = Instantiate(projectile, startPoint, Quaternion.identity);
        Vector2 direction = startPoint - target;
        proj.GetComponent<Rigidbody2D>().velocity = target * speedOfShot;
        Destroy(proj, 2);
    }

    Vector2 chooseShootingPoint(){
        int ran = Random.Range(1,4);
        if(ran == 1){
            return shootPoint1.transform.position;
        } else if(ran == 2){
            return shootPoint2.transform.position;
        } else{
            return shootPoint3.transform.position;
        }
    }
    IEnumerator TimeBetweenAttacks()
    {
        float rand = Random.Range(.25f,.56f);
        if(health <= 150) rand -= .2f;
        yield return new WaitForSeconds(rand);
        attacking = false;

    }

}

