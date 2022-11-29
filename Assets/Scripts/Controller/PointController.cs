using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointController : MonoBehaviour
{
    public TextMeshProUGUI pointSystem;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    private void Update()
    {
        pointSystem.text = "PTS: " + points;
    }
}
