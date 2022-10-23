using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointStart : MonoBehaviour {
    
    private string PLAYER_TAG = "Player";
    private string MOVE = "Move";
    private Animator anime;

    private void Start() {
        anime = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(PLAYER_TAG)) {
            anime.SetBool(MOVE, true);
        } 
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(PLAYER_TAG)) {
            anime.SetBool(MOVE, false);
        } 
    }
}
