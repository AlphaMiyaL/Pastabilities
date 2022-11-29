using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGetter : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerStats stats;
    public int amount;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update is called once per frame
    
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            stats.GainMoney(amount);
            Destroy(this.gameObject);
        }
    
    }
}
