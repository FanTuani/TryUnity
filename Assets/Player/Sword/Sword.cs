using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Sword : MonoBehaviour {
    public Rigidbody2D rb;
    public SpriteRenderer sp;
    public static Sword instance;

    private Timer attackCD;
    private Vector3 direction;

    private void Start() {
        if (instance == null) {
            instance = this;
        }
    }

    private void FixedUpdate() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        var tgPosition = Player.instance.gameObject.transform.position;
        direction = mousePosition - tgPosition;
        tgPosition += direction.normalized;

        sp.flipX = direction.x < 0;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (sp.flipX) angle += 180;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        rb.AddForce(300 * (tgPosition - transform.position) +
                    20 * Player.instance.getVelocity());
    }

    public void attack() {
        int dir = direction.x > 0 ? 1 : -1;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DORotate(new Vector3(0, 0, dir * 50), 0.02f));
        sequence.Append(transform.DORotate(new Vector3(0, 0, dir * -120), 0.13f));
        sequence.Append(transform.DORotate(new Vector3(0, 0, 0), 0.05f));
    }
}