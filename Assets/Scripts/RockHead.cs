using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockHead : MonoBehaviour {   
    public float argoRangeY;        
    public float argoRangeX;        

    private Transform player;
    private Rigidbody2D body;
    private Animator anime;
    private bool isOnGround = false;

    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
        body = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    private void Update() {
        triggerEvent();
    }

    private void triggerEvent() {
        if (player == null) return;

        float disXToPlayer = transform.position.x - player.position.x;
        float disYToPlayer = transform.position.y - player.position.y;

        if (!isOnGround && Mathf.Abs(disXToPlayer) < argoRangeX && Mathf.Abs(disYToPlayer) < argoRangeY) {
            body.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            Destroy(player.gameObject);
            SceneManager.LoadScene("GameOverMenu");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            anime.SetBool("Hit", true);
            isOnGround = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            anime.SetBool("Hit", false);
            body.bodyType = RigidbodyType2D.Static;
        }
    }
}
