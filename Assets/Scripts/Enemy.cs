using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public float speed = 1f;
    public float jumpForce = 0.2f;
    public bool doJumping = false;

    private Rigidbody2D rb;
    private bool isOnGround = false;
    private string GROUND_TAG = "Ground";

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (isOnGround && doJumping) {
            isOnGround = false;
            jumpForce = Random.Range(0.2f, 0.6f);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        } 

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(GROUND_TAG)) {
            isOnGround = true;
        } else {
            isOnGround = false;
        }
    }

}
