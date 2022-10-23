using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedX;
    public float maxX;
    public float minX;

    public void Update() {
        EnemyMovement();
    }
    
    public virtual void EnemyMovement() {}
}
