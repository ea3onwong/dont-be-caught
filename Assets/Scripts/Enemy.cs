using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedX;

    public void Update() {
        EnemyMovement();
    }

    public virtual void EnemyMovement() {}
}
