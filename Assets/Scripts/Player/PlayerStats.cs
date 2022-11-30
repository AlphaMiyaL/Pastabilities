using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private int money;
    public HealthBar healthBar;

    public GameObject fullShield;
    public GameObject semiShield;
    private int shieldDamage;
    private bool cooldown = false;

    //only for game stats purposes
    public int damageDealth;
    public int roomsFinished;

    // Start is called before the first frame update
    void Start()
    {
        damageDealth = 0;
        roomsFinished = 0;
        money = 0;
        healthBar.SetMaxHealth(health);

        shieldDamage = 0;
        fullShield.SetActive(false);
        semiShield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(health);
    }

    public int getHealth(){
        return health;
    }
    public int getMaxHealth(){
        return maxHealth;
    }

    public void gainMaxHealth(int num){
        maxHealth += num;
    }

    public int getMoney(){
        return money;
    }


    public void GainMoney(int num){
        money += num;
    }

    //returns true if the transaction goes through, else its false and it doesn't do anything
    public bool SpendMoney(int num){
        if(money - num < 0){
            return false;
        }else{
            money -= num;
            return true;
        }
    }

    public void IncreaseHealth(int num){
        health += num;
        if(health > maxHealth) health = maxHealth;
    }

    public void Damage(int num){
        health -= num;
        if(health <= 0){
            health = 0;
            Die();
        }
    }

    public void Die(){
        //TODO Scene reload or something idk.
    }

    //TODO somewhere. Don't Destroy on Load

    public void activateSemiShield()
    {
        semiShield.SetActive(true);
    }

    public void activateFullShield()
    {
        fullShield.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (fullShield.activeInHierarchy)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                shieldDamage += 1;
                if (shieldDamage == 5)
                {
                    fullShield.SetActive(false);
                    shieldDamage = 0;
                }
            }
        }
        else if (semiShield.activeInHierarchy)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                shieldDamage += 1;
                if (shieldDamage == 3)
                {
                    semiShield.SetActive(false);
                    shieldDamage = 0;
                }
            }
        }
        //else if (collision.gameObject.tag == "Enemy")
        //{
        //    Damage(1);
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !cooldown)
        {
            Debug.Log("enemy damage");
            cooldown = true;
            StartCoroutine(DamageOverTime());
        }
    }

    private IEnumerator DamageOverTime()
    {
        //Deal 1 damage
        Damage(1);
        //wait for second
        yield return new WaitForSeconds(0.5f);
        cooldown = false;
    }
}
