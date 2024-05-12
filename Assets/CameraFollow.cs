using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform playerTrans;
    public Rigidbody2D rb;
    public int speed;

    void Update() {
        Vector3 dir = playerTrans.position - transform.position;
        dir = dir.normalized * speed;
        rb.AddForce(dir);
    }
}