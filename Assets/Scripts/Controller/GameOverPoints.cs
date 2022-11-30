using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPoints : MonoBehaviour
{
    public Text pointSystem;
    //public int points;

    void Awake()
    {
        PointController pointController = GameObject.FindGameObjectWithTag("Points").GetComponent<PointController>();
        pointSystem.text = "" + pointController.points;
    }

}
