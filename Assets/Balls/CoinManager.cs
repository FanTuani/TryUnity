using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CoinManager : MonoBehaviour {
    public static CoinManager instance;
    public int targetCoinNum;
    public GameObject coinTemplate;
    public SpriteRenderer bkgRenderer;

    [FormerlySerializedAs("AccBallTemplate")]
    public GameObject accBallTemplate;

    private int collectedCoinNum = 0;

    private void Start() {
        if (instance == null) {
            instance = this;
        }

        for (int i = 0; i < targetCoinNum; i++) {
            spawnBallRandomly();
        }
    }

    private void Update() {
        // if (Input.GetMouseButtonDown(0)) {
        //     Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     position.z = 0;
        //     spawnCoin(position);
        // }
    }

    private GameObject spawnCoin(Vector3 position) {
        GameObject coin = Instantiate(coinTemplate);
        coin.transform.position = position;
        return coin;
    }

    public GameObject spawnBallRandomly() {
        GameObject ball = default;
        if (Random.Range(0, 5) == 0) {
            ball = Instantiate(accBallTemplate);
        } else {
            ball = Instantiate(coinTemplate);
        }


        // Vector2 randomScreenPosition =
        // new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
        // Vector3 position = Camera.main.ScreenToWorldPoint(randomScreenPosition);
        Bounds bounds = bkgRenderer.bounds;
        Vector3 position = new Vector3(Random.Range(-bounds.extents.x, bounds.extents.x),
            Random.Range(-bounds.extents.y, bounds.extents.y), 0);
        ball.transform.position = position;

        return ball;
    }

    public int collectCoin(Coin coin) {
        collectedCoinNum++;
        if (collectedCoinNum == targetCoinNum) {
            // GameManager.instance.winGame();
        }

        return collectedCoinNum;
    }
}