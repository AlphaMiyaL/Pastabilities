using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ReplayStairs : MonoBehaviour
{
    
    public TMP_Text gameStats;

    // Start is called before the first frame update
    void Start()
    {
        //Only for gameStat purposes within this method
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerStats stats = player.GetComponent<PlayerStats>();
        string txt = "GameStats\n";
        txt += "Damage Dealth: " + stats.damageDealth + "\n";
        txt += "Rooms Done: " + stats.roomsFinished;
        gameStats.text = txt;

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            SceneManager.LoadScene("TopFloorMain");
        }
    
    }
}
