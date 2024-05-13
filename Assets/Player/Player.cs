using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour {
    public PlayerController controller;
    public new SpriteRenderer renderer;
    public float speed;

    public void dash(Vector3 dir) {
        controller.rb.drag -= 5;
        gameObject.AddComponent<Timer>().runTaskLater(() => { controller.rb.drag += 5; }, 0.2f);
        speedEffect(100, 0.2f);
        controller.rb.AddForce(dir * (speed * 10));

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScaleY(0.7f, 0.08f));
        sequence.Append(transform.DOScaleX(1.2f, 0.08f));
        sequence.Append(transform.DOScaleY(1, 0.1f));
        sequence.Append(transform.DOScaleX(1f, 0.08f));
    }

    public void speedEffect(float speedOffset, float duration) {
        speed += speedOffset;
        gameObject.AddComponent<Timer>().runTaskLater(() => { speed -= speedOffset; }, duration);
    }

    public void collectCoin(Coin coin) {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(renderer.DOColor(Color.yellow, 0.08f));
        sequence.Append(renderer.DOColor(Color.green, 1f));
        CoinManager.instance.collectCoin(coin);
    }
}