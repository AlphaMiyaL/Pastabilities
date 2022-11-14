using TMPro;
using UnityEngine;

public class PlayerController2 : MonoBehaviour{
    public float speed;
    public TextMeshProUGUI collectedText;
    public static int collectedAmount=0;

    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        Move();
        // collectedText.text = "Items Collected: " + collectedAmount; 
    }

    private void Move() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
    }
}
