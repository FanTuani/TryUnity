using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name != "Player") {
            return;
        }

        Player player = other.GetComponent<Player>();
        player.collectCoin(gameObject);
        Destroy(gameObject);
        CoinManager.instance.spawnBallRandomly();
    }
}