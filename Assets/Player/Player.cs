using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour {
    public PlayerController controller;
    public Rigidbody2D rb;
    public new SpriteRenderer renderer;
    public float speed;

    private void FixedUpdate() {
        motionStretch();
    }

    private void motionStretch() {
        float angle = Mathf.Atan2(getVelocity().y, getVelocity().x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        // float mappedRatio = (float)Math.Log10(10 + getVelocity().magnitude) - 1;
        float mappedRatio = getVelocity().magnitude;
        mappedRatio /= 100;
        transform.localScale = new Vector3(1 + mappedRatio, 1 - mappedRatio, 0);
    }

    public Vector3 getVelocity() {
        return rb.velocity;
    }

    public void dash(Vector3 dir) {
        controller.rb.drag -= 5;
        addSpeed(100, 0.2f);
        controller.rb.AddForce(dir * (speed * 10));
        new Timer(gameObject).runTaskLater(() => {
            controller.rb.drag += 5;
        }, 0.2f);
    }

    public void addSpeed(float speedOffset, float duration) {
        speed += speedOffset;
        new Timer(gameObject).runTaskLater(() => { speed -= speedOffset; }, duration);
    }

    public void collectCoin(GameObject coinObj) {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(renderer.DOColor(Color.yellow, 0.08f));
        sequence.Append(renderer.DOColor(Color.green, 1f));
        CoinManager.instance.collectCoin(coinObj, getVelocity());
        CoinTextManager.instance.updateCoinText();
    }
}