using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverPoints : MonoBehaviour
{
    public Text pointSystem;
    public int points;

    //public TextMeshProUGUI pointSystem;

    void Awake()
    {
        PointController pointController = GameObject.FindGameObjectWithTag("Points").GetComponent<PointController>();
        pointSystem.text = "" + pointController.points;
    }

}
