using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D rb;
    public Player player;
    public static PlayerController instance;

    private void Start() {
        if (instance == null) {
            instance = this;
        }
    }

    private void FixedUpdate() {
        moveUpdate();
    }

    private void Update() {
        dashUpdate();
        if (Input.GetMouseButton(0)) {
            Player.instance.attack();
        }
    }

    private void moveUpdate() {
        Vector3 dir = getInputMoveDir();
        if (Input.GetKey(KeyCode.LeftShift)) {
            rb.AddForce(dir * player.speed / 2);
        } else {
            rb.AddForce(dir * player.speed);
        }
    }

    public Vector3 getInputMoveDir() {
        Vector3 dir = default;
        if (Input.GetKey("w")) dir += Vector3.up * Time.deltaTime;
        if (Input.GetKey("a")) dir += Vector3.left * Time.deltaTime;
        if (Input.GetKey("s")) dir += Vector3.down * Time.deltaTime;
        if (Input.GetKey("d")) dir += Vector3.right * Time.deltaTime;
        return dir.normalized;
    }


    void dashUpdate() {
        if (!Input.GetKeyDown("space")) return;
        player.dash(getInputMoveDir());
    }
}