using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public PlayerController controller;
    public float speed;

    public void dash(Vector3 dir) {
        controller.rb.AddForce(dir * (speed * 10));
    }

    public void speedEffect(float speedOffset, float duration) {
        speed += speedOffset;
        gameObject.AddComponent<Timer>().runTaskLater(() => {
            speed -= speedOffset;
        }, duration);
    }
}