using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour {
    public Rigidbody2D rb;
    public new SpriteRenderer renderer;

    public float speed;

    // public StateMachine state;
    public static Player instance;

    public bool isAttacking, isDashing;

    private void Start() {
        instance = this;
    }

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
        PlayerController.instance.rb.drag -= 5;
        addSpeed(100, 0.2f);
        PlayerController.instance.rb.AddForce(dir * (speed * 10));
        new Timer().runTaskLater(() => { PlayerController.instance.rb.drag += 5; },
            gameObject, 0.2f);
    }

    public void addSpeed(float speedOffset, float duration) {
        speed += speedOffset;
        new Timer().runTaskLater(() => { speed -= speedOffset; }, gameObject, duration);
    }

    public void collectCoin(GameObject coinObj) {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(renderer.DOColor(Color.yellow, 0.08f));
        sequence.Append(renderer.DOColor(Color.green, 1f));
        CoinManager.instance.collectCoin(coinObj, getVelocity());
        CoinTextManager.instance.updateCoinText();
    }

    private Timer combat2RelaxTimer;

    public void attack() {
        if (isAttacking) return;
        // state.changeState(PlayerStates.COMBAT);
        isAttacking = true;
        new Timer().runTaskLater(() => { isAttacking = false; }, gameObject, 0.2f);
        Sword.instance.attack();
    }
}