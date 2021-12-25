using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRectanglePlatform : Enemy 
{
    private float maxX = -2.2f; 
    private float minX = -2.8f;
    private Rigidbody2D body;
    private SpriteRenderer sr;

     private void Awake() {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public override void EnemyMovement() {
        if (body.position.x >= maxX) {
            speedX = -speedX;       // flip the direction 
            sr.flipX = true;
        } else if (body.position.x <= minX) {
            speedX = -speedX;       // flip the direction 
            sr.flipX = false;
        }
        body.velocity = new Vector2(speedX, body.velocity.y);
    }
}
