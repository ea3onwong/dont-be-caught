using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRino : Enemy 
{   
    public float argoSpeedX; 
    public float argoRangeX; 
    public float argoRangeY;

    private Transform player;
    private Rigidbody2D body;
    private SpriteRenderer sr;
    private float curSpeedX;

    private void Start() {
        curSpeedX = speedX;
        player = GameObject.FindWithTag("Player").transform;
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public override void EnemyMovement() {   
        if (player == null) 
            return;
        
        if (isArgo()) {
            curSpeedX = argoSpeedX;
        } else {
            curSpeedX = speedX;
        }

        if (body.position.x >= maxX && curSpeedX > 0) {
            curSpeedX = -curSpeedX;    
            speedX = -speedX;
            argoSpeedX = -argoSpeedX;
            sr.flipX = false;
        } else if (body.position.x <= minX && curSpeedX < 0) {
            curSpeedX = -curSpeedX; 
            speedX = -speedX;
            argoSpeedX = -argoSpeedX;           
            sr.flipX = true;
        }

        body.velocity = new Vector2(curSpeedX, body.velocity.y);
    }

    private bool isArgo() {
        float disXToPlayer = transform.position.x - player.position.x;
        float disYToPlayer = transform.position.y - player.position.y;
        bool isInSight;

        if (curSpeedX < 0 && transform.position.x > player.position.x) {
            isInSight = true;
        } else if (curSpeedX > 0 && transform.position.x < player.position.x) {
            isInSight = true;
        } else {
            isInSight = false;
        }
        
        if (isInSight && Mathf.Abs(disXToPlayer) < argoRangeX && Mathf.Abs(disYToPlayer) < argoRangeY) {       
            return true;
        } 

        return false;
    }
}
