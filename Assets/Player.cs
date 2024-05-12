using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;
    public Rigidbody2D rb;
    private bool onMagic = false;

    void Start() {
    }

    void FixedUpdate() {
        moveUpdate();
    }

    void Update() {
        dashUpdate();
        magicUpdate();
    }

    Vector3 getMoveDir() {
        Vector3 dir = default;
        if (Input.GetKey("w")) dir += Vector3.up * Time.deltaTime;
        if (Input.GetKey("a")) dir += Vector3.left * Time.deltaTime;
        if (Input.GetKey("s")) dir += Vector3.down * Time.deltaTime;
        if (Input.GetKey("d")) dir += Vector3.right * Time.deltaTime;
        return dir.normalized;
    }

    void moveUpdate() {
        Vector3 dir = getMoveDir();
        rb.AddForce(dir * speed);
    }

    void dashUpdate() {
        if (!Input.GetKeyDown("space")) return;
        Vector3 dir = getMoveDir();
        rb.AddForce(dir * (speed * 10));
    }

    void magicUpdate() {
        if (Input.GetKeyDown("r")) {
            onMagic = !onMagic;
        }

        if (onMagic) {
            Coin[] coins = GameObject.FindObjectsOfType<Coin>();
            foreach (var coin in coins) {
                Rigidbody2D coinRb = coin.GetComponent<Rigidbody2D>();
                coinRb.AddForce((transform.position - coin.transform.position) * 10f);
            }
        }
    }
}