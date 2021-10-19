using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{   

    public float minX;
    public float maxX;

    private Transform player;
    private Vector3 tempPos;

    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate() {
        if (player == null) return;

        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x > maxX) {
            tempPos.x = maxX;
        } else if (tempPos.x < minX) {
            tempPos.x = minX;
        }

        transform.position = tempPos;
    }
}
