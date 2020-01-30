using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public int jumpHeight;
    private int score;
    public Text scoreText;
    public Text winText;
    public float speed;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        winText.text = "";
    }
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }
    }
     void SetScoreText() {
        scoreText.text = "Score: " + score.ToString();
        if(score >= 12) {
            winText.text = "You Win";
        }
    }
}
