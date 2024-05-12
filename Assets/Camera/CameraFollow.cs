using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Player player;
    public Rigidbody2D rb;
    public new Camera camera;

    public int speed;
    public float basicViewSize;

    void FixedUpdate() {
        Vector3 dir = player.transform.position - transform.position;
        dir = dir.normalized * speed;
        rb.AddForce(dir * 10);

        float targetViewSize = basicViewSize + player.speed / 100;
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetViewSize, 0.1f);
    }
}