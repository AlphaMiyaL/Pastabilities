using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainPersist : MonoBehaviour
{
    private PlayerStats stats;
    private bool isRun;

    // Start is called before the first frame update
    void Start()
    {
        isRun = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnTriggerStay2D(Collider2D other)
    {
        GameObject col = other.gameObject;
        if(col.tag == "Player" && !isRun){
            StartCoroutine(DamageOverTime());
        }
        
    }

    

    private IEnumerator DamageOverTime(){
        //wait for two seconds
        isRun = true;
        yield return new WaitForSeconds(0.75f);

        //Deal 1 damage
        stats.Damage(1);
        isRun = false;
    }
}
