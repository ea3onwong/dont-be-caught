using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveForce;
    public float jumpForce;

    private Rigidbody2D rb;
    private Animator anime;
    private SpriteRenderer sr;
    private bool isOnGround;
    private float movementX;

    private string RUN = "Run";
    private string JUMP = "Jump";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        isOnGround = true;
    }

    private void Update() {
        PlayerMovement();
        RunAnimation();
        PlayerJump();
        JumpAnimation();
    }

    private void PlayerMovement() {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    private void PlayerJump() {
        if (isOnGround && Input.GetButtonDown("Jump")) {
            isOnGround = false;
            anime.SetBool(JUMP, true);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        } 
    }

    private void RunAnimation() {
        if (movementX > 0) { 
            anime.SetBool(RUN, true);
            sr.flipX = false;
        } else if (movementX < 0) { 
            anime.SetBool(RUN, true);
            sr.flipX = true;
        } else {
            anime.SetBool(RUN, false);
        }
    }

    private void JumpAnimation() {
        if (isOnGround) {
            anime.SetBool(JUMP, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(GROUND_TAG)) {
            isOnGround = true;
        } else {
            isOnGround = false;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverMenu");
        } 
    }

}
