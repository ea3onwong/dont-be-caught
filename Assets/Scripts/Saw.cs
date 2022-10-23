using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speedY;
    public float maxY;
    public float minY;

    private Rigidbody2D body;

    private void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        SawMovement();
    }

    public void SawMovement() {
        if (body.position.y >= maxY && speedY > 0) {
            speedY = -speedY;  
        } else if (body.position.y <= minY && speedY < 0) {
            speedY = -speedY;     
        }
        body.velocity = new Vector2(body.velocity.x, speedY);
    }
}
