using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormal : Enemy {

    private Rigidbody2D body;
    private SpriteRenderer sr;

    private void Start() {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public override void EnemyMovement() {
        if (body.position.x >= maxX && speedX > 0) {
            speedX = -speedX;       // flip the direction 
            sr.flipX = true;
        } else if (body.position.x <= minX && speedX < 0) {
            speedX = -speedX;       // flip the direction 
            sr.flipX = false;
        }
        body.velocity = new Vector2(speedX, body.velocity.y);
    }
}


