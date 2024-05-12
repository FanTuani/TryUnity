using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name != "Player") {
            return;
        }

        Animator animator = other.gameObject.GetComponent<Animator>();
        animator.SetTrigger("GetCoin");

        Destroy(this.gameObject);
        CoinManager.instance.collectCoin(1);
    }
}