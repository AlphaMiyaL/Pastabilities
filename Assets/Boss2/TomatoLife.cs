using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoLife : MonoBehaviour
{
    private PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStats>();
        Destroy(this.gameObject, 5f);

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            stats.Damage(3);
        }
        Destroy(this.gameObject);
    }
}
