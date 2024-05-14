using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D rb;
    public Player player;

    void FixedUpdate() {
        moveUpdate();
    }

    void Update() {
        dashUpdate();
    }

    private Vector3 getInputMoveDir() {
        Vector3 dir = default;
        if (Input.GetKey("w")) dir += Vector3.up * Time.deltaTime;
        if (Input.GetKey("a")) dir += Vector3.left * Time.deltaTime;
        if (Input.GetKey("s")) dir += Vector3.down * Time.deltaTime;
        if (Input.GetKey("d")) dir += Vector3.right * Time.deltaTime;
        return dir.normalized;
    }

    void moveUpdate() {
        Vector3 dir = getInputMoveDir();
        if (Input.GetKey(KeyCode.LeftShift)) {
            rb.AddForce(dir * player.speed / 2);
        } else {
            rb.AddForce(dir * player.speed);
        }
    }

    void dashUpdate() {
        if (!Input.GetKeyDown("space")) return;
        player.dash(getInputMoveDir());
    }
}