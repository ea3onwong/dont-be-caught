using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{   

    public float minX;      // -1.17
    public float maxX;      // 4.7
    public float minY;      // -1.58

    private Transform player;
    private Vector3 tempPos;
    private Vector3 offset;

    [Range(1, 10)]
    public float smoothFactor;

    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate() {
        CameraFollow();
    }   

    private void CameraFollow() {
        if (player == null) return;

        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;

        if (tempPos.x > maxX) {
            tempPos.x = maxX;
        } else if (tempPos.x < minX) {
            tempPos.x = minX;
        }

        if (tempPos.y < minY) {
            tempPos.y = minY;
        }
        
        Vector3 smoothPos = Vector3.Lerp(transform.position, tempPos, smoothFactor * Time.deltaTime);

        transform.position = smoothPos;
    }
}
