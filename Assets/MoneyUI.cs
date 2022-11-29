using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    private PlayerStats stats;


    public TMP_Text moneyTxt;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
        moneyTxt.text = "Money: " + stats.getMoney();
    }
}
